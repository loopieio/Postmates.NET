//-----------------------------------------------------------------------------
// FILE:	    Integration.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2018-2020 by Loopie, Inc.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using Postmates;
using Postmates.Xunit;

using Xunit;

namespace Test.Postmates
{
    /// <summary>
    /// XUnit test for testing the Postmates Manager service.
    /// </summary>
    public class Test_Postmates
    {
        public PostmatesClient PostmatesClient { get; }

        public IConfiguration Configuration { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fixture">The startup class of the service to be tested.</param>
        public Test_Postmates()
        {
            // https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=windows
            // https://patrickhuber.github.io/2017/07/26/avoid-secrets-in-dot-net-core-tests.html
            // In project directory cmd:
            // dotnet user-secrets init
            // dotnet user-secrets set "Postmates.ServiceApiKey" "[Sandbox Key]"
            // dotnet user-secrets set "Postmates.CustomerId" [Customer Id]"

            var builder = new ConfigurationBuilder()
              .AddUserSecrets<Test_Postmates>();

            Configuration = builder.Build();
            var customerId = Configuration.GetValue<string>("Postmates.CustomerId");
            var apiKey = Configuration.GetValue<string>("Postmates.ServiceApiKey");
            PostmatesClient = new PostmatesClient(new PostmatesAccount(customerId, apiKey));
        }

        

        /// <summary>
        /// Test the delivery quote endpoint. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        [Trait(TestCategory.CategoryTrait, TestCategory.Sample)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Integration)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Daily)]
        public async Task GetDeliveryQuoteAsync()
        {
            var deliveryQuoteArgs = new PostmatesDeliveryQuoteArgs()
            {
                PickupAddress = new PostmatesAddress()
                {
                    StreetAddress1 = "229 1st AVE N",
                    StreetAddress2 = "",
                    City = "Seattle",
                    State = UsStates.WA,
                    ZipCode = "98109"
                },
                PickupLatitude = 47.6698608,
                PickupLongitude = -122.3004016,
                PickupPhoneNumber = "3155140118",
                DropoffAddress = new PostmatesAddress()
                {
                    StreetAddress1 = "3958 6th AVE NW",
                    StreetAddress2 = "",
                    City = "Seattle",
                    State = UsStates.WA,
                    ZipCode = "98107"
                },
                DropoffLatitude = 47.6554918,
                DropoffLongitude = -122.3633574,
                DropoffPhoneNumber = "+1 (315) 514-0118"
            };

            var deliveryQuote = await PostmatesClient.GetDeliveryQuoteAsync(deliveryQuoteArgs);

            Assert.IsType<PostmatesDeliveryQuote>(deliveryQuote);
        }

        /// <summary>
        /// Test the delivery zone endpoint. 
        /// </summary>
        /// <returns></returns>
        [Fact]
        [Trait(TestCategory.CategoryTrait, TestCategory.Sample)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Integration)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Daily)]
        public async Task GetDeliveryZonesAsync()
        {
            var result = await PostmatesClient.GetDeliveryZonesAsync();
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Test creating a delivery.
        /// 
        /// $todo(marcus.bowyer):
        ///     Figure out why the list of manifest items is never returned when 
        ///     getting the delivery. This shouldn't really be a problem for us
        ///     as the manifest description still works.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [Trait(TestCategory.CategoryTrait, TestCategory.Sample)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Integration)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Daily)]
        public async Task CreateDeliveryAsync()
        {
            var manifestItems = new List<PostmatesManifestItem>();
            manifestItems.Add(new PostmatesManifestItem()
            {
                Name = "Loopie Laundry bag",
                Quantity = 1,
                Size = PostmatesItemSizes.Medium
            });

            var delivery = new PostmatesCreateDeliveryArgs()
            {
                Manifest = "Laundry in a Loopie bag.",
                ManifestItems = manifestItems,
                PickupName = "Marcus",
                PickupAddress = new PostmatesAddress()
                {
                    StreetAddress1 = "229 1st AVE N",
                    City = "Seattle",
                    State = UsStates.WA,
                    Country = Countries.US,
                    ZipCode = "98109"
                },
                PickupPhoneNumber = "3155140118",
                PickupNotes = "Ring doorbell",
                DropoffName = "Loopie HQ",
                DropoffAddress = new PostmatesAddress()
                {
                    StreetAddress1 = "3958 6th AVE NW",
                    StreetAddress2 = "",
                    City = "Seattle",
                    State = UsStates.WA,
                    Country = Countries.US,
                    ZipCode = "98107"
                },
                DropoffPhoneNumber = "3155140118",
                DropoffNotes = "Ring doorbell/Call"
            };
            var result = await PostmatesClient.CreateDeliveryAsync(delivery);
            Assert.IsType<PostmatesDelivery>(result);
        }

        /// <summary>
        /// Get the current list of deliveries.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [Trait(TestCategory.CategoryTrait, TestCategory.Sample)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Integration)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Daily)]
        public async Task ListDeliveriesAsync()
        {
            var result = await PostmatesClient.GetDeliveriesAsync();
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Get the current list of deliveries.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [Trait(TestCategory.CategoryTrait, TestCategory.Sample)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Integration)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Daily)]
        public async Task ListOngoingDeliveriesAsync()
        {

            var deliveryCreateArgs = new PostmatesCreateDeliveryArgs()
            {
                Manifest = "Laundry in a Loopie bag.",
                PickupName = "Marcus",
                PickupAddress = new PostmatesAddress()
                {
                    StreetAddress1 = "229 1st AVE N",
                    City = "Seattle",
                    State = UsStates.WA,
                    Country = Countries.US,
                    ZipCode = "98109"
                },
                PickupPhoneNumber = "3155140118",
                PickupNotes = "Ring doorbell",
                DropoffName = "Loopie HQ",
                DropoffAddress = new PostmatesAddress()
                {
                    StreetAddress1 = "3958 6th AVE NW",
                    StreetAddress2 = "",
                    City = "Seattle",
                    State = UsStates.WA,
                    Country = Countries.US,
                    ZipCode = "98107"
                },
                DropoffPhoneNumber = "3155140118",
                DropoffNotes = "Ring doorbell/Call",
                PickupReady = DateTime.UtcNow.AddMinutes(10),
                PickupDeadline = DateTime.UtcNow.AddMinutes(25),
                DropoffReady = DateTime.UtcNow.AddMinutes(20),
                DropoffDeadline = DateTime.UtcNow.AddMinutes(60)
            };

            var ongoingDelivery = await PostmatesClient.CreateDeliveryAsync(deliveryCreateArgs);

            var result = await PostmatesClient.GetOngoingDeliveriesAsync();
            
            /// $todo(marcus.bowyer)
            ///     figure out how to make this actually return something
            
        }

        /// <summary>
        /// Get a specific Postmates Delivery.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [Trait(TestCategory.CategoryTrait, TestCategory.Sample)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Integration)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Daily)]
        public async Task GetDeliveryAsync()
        {
            var deliveries = await PostmatesClient.GetDeliveriesAsync();
            var id = deliveries.FirstOrDefault().Id;
            var result = await PostmatesClient.GetDeliveryAsync(id);
            Assert.True(result.Id == id);
        }


        /// $todo(marcus.bowyer):
        ///     This test is failing until the JsonClient 
        ///     PostAsync method allows posting null in the body\
        ///     
        /// <summary>
        /// Cancel a Postmates Delivery.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [Trait(TestCategory.CategoryTrait, TestCategory.Sample)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Integration)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Daily)]
        public async Task CancelDeliveryAsync()
        {
            var deliveryCreateArgs = new PostmatesCreateDeliveryArgs()
            {
                Manifest = "Laundry in a Loopie bag.",
                PickupName = "Marcus",
                PickupAddress = new PostmatesAddress()
                {
                    StreetAddress1 = "229 1st AVE N",
                    City = "Seattle",
                    State = UsStates.WA,
                    Country = Countries.US,
                    ZipCode = "98109"
                },
                PickupPhoneNumber = "3155140118",
                PickupNotes = "Ring doorbell",
                DropoffName = "Loopie HQ",
                DropoffAddress = new PostmatesAddress()
                {
                    StreetAddress1 = "3958 6th AVE NW",
                    StreetAddress2 = "",
                    City = "Seattle",
                    State = UsStates.WA,
                    Country = Countries.US,
                    ZipCode = "98107"
                },
                DropoffPhoneNumber = "3155140118",
                DropoffNotes = "Ring doorbell/Call",
                PickupReady = DateTime.UtcNow.AddMinutes(10),
                PickupDeadline = DateTime.UtcNow.AddMinutes(25),
                DropoffReady = DateTime.UtcNow.AddMinutes(20),
                DropoffDeadline = DateTime.UtcNow.AddMinutes(60)
            };

            var deliveryToCancel = await PostmatesClient.CreateDeliveryAsync(deliveryCreateArgs);

            var result = await PostmatesClient.CancelDeliveryAsync(deliveryToCancel.Id);
            Assert.True(deliveryToCancel.Id == result.Id);
            Assert.True(result.Status == PostmatesDeliveryStatuses.Canceled);
        }



        /// <summary>
        /// Get a specific Postmates Delivery.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [Trait(TestCategory.CategoryTrait, TestCategory.Sample)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Integration)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Daily)]
        public async Task TipDeliveryAsync()
        {

            Random rnd = new Random();
            var tipAmount = rnd.Next(1, 1000);

            var deliveries = await PostmatesClient.GetDeliveriesAsync();

            var deliveryToTip = deliveries.Where(d => d.Status == PostmatesDeliveryStatuses.Delivered
                                                    && d.Tip is null).FirstOrDefault();

            var tipArgs = new PostmatesDeliveryTipArgs()
            {
                TipByCustomer = tipAmount
            };

            var result = await PostmatesClient.TipCourierAsync(deliveryToTip.Id, tipArgs);

            Assert.True(result.Tip == tipAmount);
            Assert.True(result.Id == deliveryToTip.Id);
        }

        /// <summary>
        /// Delivery quote for unknown location.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [Trait(TestCategory.CategoryTrait, TestCategory.Sample)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Integration)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Daily)]
        public async Task UnknownLocationAsync()
        {
            var deliveryQuoteArgs = new PostmatesDeliveryQuoteArgs()
            {
                PickupAddress = new PostmatesAddress()
                {
                    StreetAddress1 = "34 Antarctica Avenue",
                    StreetAddress2 = "",
                    City = "Antarctica",
                    State = UsStates.WA,
                    ZipCode = "90000"
                },
                PickupPhoneNumber = "3155140118",
                DropoffAddress = new PostmatesAddress()
                {
                    StreetAddress1 = "00 Not a real Ave",
                    StreetAddress2 = "",
                    City = "Fake",
                    State = UsStates.WA,
                    ZipCode = "00000"
                },
                DropoffPhoneNumber = "+1 (315) 514-0118"
            };
            try
            {
                var deliveryQuote = await PostmatesClient.GetDeliveryQuoteAsync(deliveryQuoteArgs);
            }
            catch(Exception e)
            {
                Assert.IsType<UnknownLocationException>(e);
            }
        }


        /// <summary>
        /// Request a delivery for an address that is undeliverable.
        /// </summary>
        /// <returns></returns>
        [Fact]
        [Trait(TestCategory.CategoryTrait, TestCategory.Sample)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Integration)]
        [Trait(TestCategory.CategoryTrait, TestCategory.Daily)]
        public async Task AddressUndeliverableAsync()
        {
            var deliveryQuoteArgs = new PostmatesDeliveryQuoteArgs()
            {
                PickupAddress = new PostmatesAddress()
                {
                    StreetAddress1 = "405 1st St NW, Towner, ND 58788",
                    StreetAddress2 = "",
                    City = "Towner",
                    State = UsStates.ND,
                    ZipCode = "58788"
                },
                PickupLatitude = 47.6698608,
                PickupLongitude = -100.406688,
                PickupPhoneNumber = "3155140118",
                DropoffAddress = new PostmatesAddress()
                {
                    StreetAddress1 = "3958 6th AVE NW",
                    StreetAddress2 = "",
                    City = "Seattle",
                    State = UsStates.WA,
                    ZipCode = "98107"
                },
                DropoffLatitude = 47.6554918,
                DropoffLongitude = -122.3633574,
                DropoffPhoneNumber = "+1 (315) 514-0118"
            };

            try
            {
                var deliveryQuote = await PostmatesClient.GetDeliveryQuoteAsync(deliveryQuoteArgs);
            }
            catch (Exception e)
            {
                Assert.IsType<AddressUndeliverableException>(e);
            }
        }
    }
}
