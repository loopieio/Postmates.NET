//-----------------------------------------------------------------------------
// FILE:	    PostmatesCreateDeliveryArgs.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2019 by Loopie, LLC.  All rights reserved.

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;

using Neon.Common;

using Postmates.Model;
using Postmates.API;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace Postmates.Model
{
    /// <summary>
    /// Class to define the arguments used when creating a Postmates Delivery
    /// via the PostmatesManager service.
    /// </summary>
    public class PostmatesCreateDeliveryArgs
    {
        //---------------------------------------------------------------------
        // Static members

        /// <summary>
        /// Constructor.
        /// </summary>
        public PostmatesCreateDeliveryArgs()
        {

        }

        /// <summary>
        /// The ID of a previously generated delivery quote. Optional, but recommended. 
        /// Example: "del_KSsT9zJdfV3P9k"
        /// </summary>
        [JsonProperty(PropertyName = "quote_id", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string QuoteId { get; set; }

        /// <summary>
        /// A detailed description of what the courier will be delivering. 
        /// Example: "A box of gray mittens"
        /// </summary>
        [JsonProperty(PropertyName = "manifest", Required = Required.Always)]
        public string Manifest { get; set; }

        /// <summary>
        /// Optional reference that identifies the manifest. Example: "Order #690"
        /// </summary>
        [JsonProperty(PropertyName = "manifest_reference", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string ManifestReference { get; set; }

        /// <summary>
        /// Optional JSON encoded array with a breakdown of the items being delivered. 
        /// Example: 
        ///     [
        ///         {"name": "Bubble Tea", "quantity": 2, "size": "small"}, 
        ///         {"name": "Milk Tea", "quantity": 1, "size": "small"}
        ///     ]
        /// </summary>
        [JsonProperty(PropertyName = "manifest_items", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public List<PostmatesManifestItem> ManifestItems { get; set; }

        /// <summary>
        /// Name of the place where the courier will make the pickup. Example: "Kitten Warehouse"
        /// </summary>
        [JsonProperty(PropertyName = "pickup_name", Required = Required.Always)]
        public string PickupName { get; set; }

        /// <summary>
        /// The pickup address for the delivery. This is passed as a <see cref="PostmatesAddress"/>
        /// and then converted to a string by the PostmatesManager service.
        /// </summary>
        [JsonProperty(PropertyName = "pickup_address", Required = Required.Always)]
        public PostmatesAddress PickupAddress { get; set; }

        /// <summary>
        /// Optional latitude of the pickup location. If passed, this will be used 
        /// instead of the geocoded coordinate as long as they are less than 
        /// 1km apart as a crow flies. Example: "37.778307"
        /// </summary>
        [JsonProperty(PropertyName = "pickup_latitude", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public double? PickupLatitude { get; set; }

        /// <summary>
        /// Optional longitude of the pickup location. If passed, this will be used 
        /// instead of the geocoded coordinate as long as they are less than 
        /// 1km apart as a crow flies. Example: "-122.413524"
        /// </summary>
        [JsonProperty(PropertyName = "pickup_longitude", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public double? PickupLongitude { get; set; }

        /// <summary>
        /// The phone number of the pickup location. Example: "415-555-4242"
        /// </summary>
        [JsonProperty(PropertyName = "pickup_phone_number", Required = Required.Always)]
        public string PickupPhoneNumber { get; set; }

        /// <summary>
        /// Optional business name of the pickup location. Example: "Feline Enterprises, Inc."
        /// </summary>
        [JsonProperty(PropertyName = "pickup_business_name", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string PickupBusinessName { get; set; }

        /// <summary>
        /// Additional instructions for the courier at the pickup location. 
        /// Example: "Ring the doorbell twice, and only deliver the package if a human answers."
        /// </summary>
        [JsonProperty(PropertyName = "pickup_notes", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string PickupNotes { get; set; }

        /// <summary>
        /// Name of the place where the courier will make the dropoff. Example: "Alice"
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_name", Required = Required.Always)]
        public string DropoffName { get; set; }

        /// <summary>
        /// The dropoff address for the delivery. This is passed as a <see cref="PostmatesAddress"/>
        /// and then converted to a string by the PostmatesManager service.        
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_address", Required = Required.Always)]
        public PostmatesAddress DropoffAddress { get; set; }

        /// <summary>
        /// Optional latitude of the dropoff location. If passed, this will be used 
        /// instead of the geocoded coordinate as long as they are less than 1km 
        /// apart. Example: "37.778307"
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_latitude", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public double? DropoffLatitude { get; set; }

        /// <summary>
        /// Optional longitude of the dropoff location. If passed, this will be used 
        /// instead of the geocoded coordinate as long as they are less than 1km 
        /// apart. Example: "-122.413524"
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_longitude", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public double? DropoffLongitude { get; set; }

        /// <summary>
        /// The phone number of the dropoff location. Example: "415-555-8484"
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_phone_number", Required = Required.Always)]
        public string DropoffPhoneNumber { get; set; }

        /// <summary>
        /// Optional business name of the dropoff location. Example: "Alice's Cat Cafe"
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_business_name", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string DropoffBusinessName { get; set; }

        /// <summary>
        /// Additional instructions for the courier at the dropoff location. 
        /// Example: "Tell the security guard that you're here to see Alice."
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_notes", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string DropoffNotes { get; set; }

        /// <summary>
        /// Optional flag to indicate this delivery requires ID verification
        /// </summary>
        [JsonProperty(PropertyName = "requires_id", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(false)]
        public bool RequiresId { get; set; }

        /// <summary>
        /// Optional flag to indicate this delivery requires signature capture at dropoff
        /// </summary>
        [JsonProperty(PropertyName = "requires_dropoff_signature", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(false)]
        public bool RequiresDropoffSignature { get; set; }

        /// <summary>
        /// Optional ISO8601 datetime to specify when a delivery is ready for pickup. 
        /// Example: 2028-03-24T18:00:00.00Z. Omitting this field will result in a 
        /// default pickup_ready_dt of now
        /// </summary>
        [JsonProperty(PropertyName = "pickup_ready_dt", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [JsonConverter(typeof(PostmatesDateTimeConverter))]
        [DefaultValue(null)]
        public DateTime? PickupReady { get; set; }

        /// <summary>
        /// Optional ISO8601 datetime to specify by when a delivery must be picked up. 
        /// Example: 2028-03-24T19:00:00.00Z
        /// </summary>
        [JsonProperty(PropertyName = "pickup_deadline_dt", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [JsonConverter(typeof(PostmatesDateTimeConverter))]
        [DefaultValue(null)]
        public DateTime? PickupDeadline { get; set; }

        /// <summary>
        /// Optional ISO8601 datetime to specify when a delivery is ready to be dropped off. 
        /// Example: 2028-03-24T18:30:00.00Z
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_ready_dt", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [JsonConverter(typeof(PostmatesDateTimeConverter))]
        [DefaultValue(null)]
        public DateTime? DropoffReady { get; set; }

        /// <summary>
        /// Optional ISO8601 datetime to specify by when a delivery must be dropped off. 
        /// Example: 2028-03-24T19:30:00.00Z
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_deadline_dt", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [JsonConverter(typeof(PostmatesDateTimeConverter))]
        [DefaultValue(null)]
        public DateTime? DropoffDeadline { get; set; }

        /// <summary>
        /// Validates the devlivery create arguments are ready to be sent to postmates
        /// </summary>
        public void Validate()
        {
            PickupAddress.Validate();
            DropoffAddress.Validate();
        }



    }
}
