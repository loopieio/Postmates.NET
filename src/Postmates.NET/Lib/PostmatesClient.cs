//-----------------------------------------------------------------------------
// FILE:	    PostmatesClient.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2017-2018 by Loopie, LLC.  All rights reserved.

using GeoJSON.Net.Feature;
using Neon.Collections;
using Neon.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Postmates.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Postmates.API
{
    /// <summary>
    /// The Postmates Client.
    /// https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md
    /// https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/framework-design-guidelines-digest.md
    /// https://github.com/loopieio/Postmates.NET
    /// </summary>
    public class PostmatesClient : IDisposable
    {
        //----------------------------------------------------
        // Static members

        //---------------------------------------------------------------------
        // Instance members

        private readonly JsonClient _jsonClient;
        private readonly JsonSerializerSettings _jsonSettings;
        private readonly string _customerId;
        private readonly string _apiKey;
        private readonly string _serviceUrl;
        private bool _isDisposed;



        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="account"></param>
        /// <param name="serviceUri"></param>
        public PostmatesClient(PostmatesAccount account, string serviceUri = "https://api.postmates.com/")
        {
            _customerId = account.CustomerId;
            _apiKey = account.ApiKey;
            _serviceUrl = serviceUri;
            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_apiKey}:{string.Empty}")); // password is blank
            _jsonClient = new JsonClient()
            {
                BaseAddress = new Uri(serviceUri),
                DocumentType = "application/x-www-form-urlencoded"
            };

            _jsonClient.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);

            _jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "yyy-MM-ddTHH:mm:ss.ffZ"
            };

            // Submit a request to verify that the token is valid.
            VerifyTokenAsync().Wait();
        }



        /// <summary>
        /// Returns the relative URI for an operation path and optional query arguments.
        /// </summary>
        /// <param name="path">The operation path.</param>
        /// <returns></returns>
        private string FormatPath(string path)
        {
            return $"/v1/customers/{_customerId}/{path}";
        }

        /// <summary>
        /// Verifies that the API token works by calling a simple API method.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task VerifyTokenAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await GetOngoingDeliveriesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_object"></param>
        /// <returns></returns>
        public IDictionary<string, Object> FormatJson(dynamic _object)
        {
            var postObject = new System.Dynamic.ExpandoObject() as IDictionary<string, Object>;

            foreach (var descriptor in TypeDescriptor.GetProperties(_object))
            {

                foreach (var attribute in descriptor.Attributes)
                {
                    if (attribute is JsonPropertyAttribute)
                    {
                        var jsonProperty = (JsonPropertyAttribute)attribute;
                        postObject.Add(jsonProperty.PropertyName, _object.GetType().GetProperty(descriptor.DisplayName).GetValue(_object));
                        break;
                    }
                }
            }
            return postObject;
        }

        /// <summary>
        /// Converts JSON to a application/x-www-form-urlencoded before POSTing to the Postmates API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="_object"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<T> PostFormAsync<T>(string url, dynamic _object, CancellationToken cancellationToken = default)
        {
            var payloadString = "";
            var first = true;

            //dynamic data = JObject.Parse(_object);

            dynamic data = JObject.FromObject(_object);

            foreach (var descriptor in TypeDescriptor.GetProperties(data))
            {
                var key = descriptor.Name;
                var value = descriptor.GetValue(data).Value;
                if (value is null)
                {
                    continue;
                }
                if (!(value is string))
                {
                    value = (descriptor.GetValue(data) == null) ? null : JsonConvert.SerializeObject(descriptor.GetValue(data),
                        Newtonsoft.Json.Formatting.None,
                        _jsonSettings);
                    value = (string)value.Trim('"');
                }
                if (!string.IsNullOrEmpty(value))
                {
                    if (!first)
                    {
                        payloadString += "&";
                    }
                    payloadString += $"{key}={value}";
                    first = false;
                }
            }

            var payload = new JsonClientPayload("application/x-www-form-urlencoded", payloadString);

            return await _jsonClient.PostAsync<T>(url, payload);
        }

        /// <summary>
        /// Returns all data from an api endpoint from all pages.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetListAsync<T>(string url, ArgDictionary args = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = new List<T>();
            var response = await _jsonClient.GetAsync<dynamic>(url, args, cancellationToken: cancellationToken);

            while (response != null)
            {
                foreach (dynamic elem in response.data)
                {
                    T elemObject = JsonConvert.DeserializeObject<T>(Convert.ToString(elem));
                    data.Add(elemObject);
                }

                var nextPage = (string)response.next_href;

                // get the next page
                if (string.IsNullOrWhiteSpace(nextPage) == false)
                {
                    response = await _jsonClient.GetAsync<dynamic>(nextPage, cancellationToken: cancellationToken);
                }
                else
                {
                    response = null;
                }
            }

            return data;
        }

        /// <summary>
        /// The first step in using the Postmates API is get a quote on a delivery. 
        /// This allows you to make decisions about the appropriate cost and availability 
        /// for using the Postmates platform, which can vary based on distance and demand.
        /// 
        /// A Delivery Quote provides an estimate for a potential delivery.This includes 
        /// the amount the delivery is expected to cost as well as an estimated delivery 
        /// window.As demand on our platform changes over time, the fee amount and ETA may 
        /// increase beyond what your use-case can support.
        /// 
        /// A Delivery Quote can only be used once and is only valid for a limited duration.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="cancellationToken">The optional cancellation token.</param>
        /// <returns></returns>
        public async Task<PostmatesDeliveryQuote> GetDeliveryQuoteAsync(PostmatesDeliveryQuoteArgs args, CancellationToken cancellationToken = default)
        {
            args.Validate();

            var deliveryQuoteArguments = new
            {
                pickup_address = args.PickupAddress.ToString(),
                pickup_latitude = args.PickupLatitude,
                pickup_longitude = args.PickupLongitude,
                pickup_phone_number = args.PickupPhoneNumber,
                dropoff_address = args.DropoffAddress.ToString(),
                dropoff_latitude = args.DropoffLatitude,
                dropoff_longitude = args.DropoffLongitude,
                dropoff_phone_number = args.DropoffPhoneNumber,
                dropoff_ready_dt = args.DropOffReady,
                pickup_deadline_dt = args.PickupDeadline,
                pickup_ready_dt = args.PickupReady
            };

            var result = await PostFormAsync<PostmatesDeliveryQuote>(FormatPath("delivery_quotes"), deliveryQuoteArguments, cancellationToken: cancellationToken);

            return result;
        }

        /// <summary>
        /// This endpoint returns a list of GeoJSON-valid FeatureCollection objects representing all of our active delivery zones.
        /// 
        /// Coordinates will be in the format[longitude, latitude].
        /// 
        /// Our zones are not bound by zip code borders.If you need to check to see if an address is within a given zone, use the Delivery Quote endpoint.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<FeatureCollection>> GetDeliveryZonesAsync(CancellationToken cancellationToken = default)
        {
            return await _jsonClient.GetAsync<IEnumerable<FeatureCollection>>("/v1/delivery_zones", cancellationToken: cancellationToken);
        }

        /// <summary>
        /// After you've successfully created a delivery quote, it's time to create an actual delivery on the Postmates platform. 
        /// It's recommended that you include the previously generated quote_id to ensure the costs and ETAs are consistent with 
        /// the quote. Once a delivery is accepted, the delivery fee will be deducted from your account.
        /// 
        /// To ensure your deliveries are being picked up and dropped off on time, you can specify a pickup window and a dropoff 
        /// window.Our dispatch system will send a courier to pick up the order within the pickup window, and will make sure that 
        /// the order is given to the customer during the dropoff window. Pickup and dropoff windows are specified using 
        /// pickup_ready_dt, pickup_deadline_dt, dropoff_ready_dt, and dropoff_deadline_dt.These timestamps have the 
        /// following requirements:
        /// 
        ///     - pickup_ready_dt must be less than 30 days in the future.
        /// 
        ///     - pickup_deadline_dt must be at least 10 mins later than pickup_ready_dt 
        ///     and at least 20 minutes in the future, thus providing a realistic pickup window.
        ///     
        ///     - dropoff_ready_dt must be less than or equal to pickup_deadline_dt.This is to prevent a scenario where a courier 
        ///     has to hold onto an order between the pickup and dropoff windows.
        ///     
        ///     - dropoff_deadline_dt must be at least 20 mins later than dropoff_ready_dt, thus providing a realistic 
        ///     dropoff window.
        ///     
        ///     - dropoff_deadline_dt must be greater than or equal to pickup_deadline_dt.
        ///     
        /// </summary>
        /// <param name="args">The postmates delivery quote arguments</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PostmatesDelivery> CreateDeliveryAsync(PostmatesCreateDeliveryArgs args, CancellationToken cancellationToken = default)
        {

            args.Validate();

            // Create the arguments to be sent to Postmates.
            // Address needs to be formatted as a string, etc.
            dynamic jsonObject = new JObject();
            jsonObject.quote_id = args.QuoteId;
            jsonObject.manifest = args.Manifest;
            jsonObject.manifest_reference = args.ManifestReference;
            jsonObject.manifest_items = (args.ManifestItems == null) ? null : JsonConvert.SerializeObject(args.ManifestItems);
            jsonObject.pickup_name = args.PickupName;
            jsonObject.pickup_address = args.PickupAddress.ToString();
            jsonObject.pickup_latitude = args.PickupLatitude;
            jsonObject.pickup_longitude = args.PickupLongitude;
            jsonObject.pickup_phone_number = args.PickupPhoneNumber;
            jsonObject.pickup_business_name = args.PickupBusinessName;
            jsonObject.pickup_notes = args.PickupNotes;
            jsonObject.dropoff_name = args.DropoffName;
            jsonObject.dropoff_address = args.DropoffAddress.ToString();
            jsonObject.dropoff_latitude = args.DropoffLatitude;
            jsonObject.dropoff_longitude = args.DropoffLongitude;
            jsonObject.dropoff_phone_number = args.DropoffPhoneNumber;
            jsonObject.dropoff_business_name = args.DropoffBusinessName;
            jsonObject.dropoff_notes = args.DropoffNotes;
            jsonObject.requires_id = args.RequiresId;
            jsonObject.requires_dropoff_signature = args.RequiresDropoffSignature;
            jsonObject.pickup_ready_dt = args.PickupReady;
            jsonObject.pickup_deadline_dt = args.PickupDeadline;
            jsonObject.dropoff_ready_dt = args.DropoffReady;
            jsonObject.dropoff_deadline_dt = args.DropofffDeadline;

            var result = await PostFormAsync<PostmatesDelivery>(FormatPath("deliveries"), jsonObject, cancellationToken);
            return result;
        }

        /// <summary>
        /// Gets all deliveries for the customer.
        /// </summary>
        /// <param name="cancellationToken">The optional cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<PostmatesDelivery>> GetDeliveriesAsync(CancellationToken cancellationToken = default)
        {
            return await GetListAsync<PostmatesDelivery>(FormatPath("deliveries"), cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets the ongoing deliveries for the customer.
        /// </summary>
        /// <param name="cancellationToken">The optional cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<PostmatesDelivery>> GetOngoingDeliveriesAsync(CancellationToken cancellationToken = default)
        {
            var arguments = new ArgDictionary
            {
                { "filter", "ongoing" }
            };

            return await GetListAsync<PostmatesDelivery>(FormatPath("deliveries"), arguments, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieve updated details about a delivery.
        /// </summary>
        public async Task<PostmatesDelivery> GetDeliveryAsync(string deliveryId, CancellationToken cancellationToken = default)
        {
            return await _jsonClient.GetAsync<PostmatesDelivery>(FormatPath($"deliveries/{deliveryId}"));
        }

        /// <summary>
        /// Cancel an ongoing delivery. A delivery can only be canceled prior to a courier completing pickup. 
        /// Delivery fees still apply.
        /// </summary>
        public async Task<PostmatesDelivery> CancelDeliveryAsync(string deliveryId, CancellationToken cancellationToken = default)
        {
            return await _jsonClient.PostAsync<PostmatesDelivery>(FormatPath($"deliveries/{deliveryId}/cancel"), null);
        }

        /// <summary>
        /// After an order has completed, you can add a tip for the courier.
        /// </summary>
        public async Task<PostmatesDelivery> TipCourierAsync(string deliveryId, PostmatesDeliveryTipArgs args, CancellationToken cancellationToken = default)
        {
            var postArgs = FormatJson(args);
            return await PostFormAsync<PostmatesDelivery>(FormatPath($"deliveries/{deliveryId}"), postArgs);
        }

        /// <summary>
        /// Releases all resources associated with the instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all associated resources.
        /// </summary>
        /// <param name="disposing">Pass <c>true</c> if we're disposing, <c>false</c> if we're finalizing.</param>
        protected virtual void Dispose(bool disposing)
        {
            lock (_jsonClient)
            {
                if (!_isDisposed)
                {
                    _jsonClient.Dispose();
                    _isDisposed = true;
                }
            }
        }
    }
}
