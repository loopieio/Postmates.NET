using Postmates.API;
using Postmates.Model;
using Postmates.Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test.Postmates
{
    /// <summary>
    /// XUnit test for testing the Postmates Manager service.
    /// </summary>
    public class Test_Postmates
    {
        public PostmatesClient client { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="fixture">The startup class of the service to be tested.</param>
        public Test_Postmates()
        {
            var customerId = Environment.GetEnvironmentVariable("POSTMATES_CUSTOMER_ID");
            var signatureSecret = Environment.GetEnvironmentVariable("POSTMATES_SIGNATURE_SECRET");
            client = new PostmatesClient(new PostmatesAccount(customerId, signatureSecret));
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

            var deliveryQuote = await client.GetDeliveryQuoteAsync(deliveryQuoteArgs);

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
            var result = await client.GetDeliveryZonesAsync();
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
            var result = await client.CreateDeliveryAsync(delivery);
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
            var result = await client.GetDeliveriesAsync();
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
                DropofffDeadline = DateTime.UtcNow.AddMinutes(60)
            };

            var ongoingDelivery = await client.CreateDeliveryAsync(deliveryCreateArgs);

            var result = await client.GetOngoingDeliveriesAsync();
            
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
            var deliveries = await client.GetDeliveriesAsync();
            var id = deliveries.FirstOrDefault().Id;
            var result = await client.GetDeliveryAsync(id);
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
                DropofffDeadline = DateTime.UtcNow.AddMinutes(60)
            };

            var deliveryToCancel = await client.CreateDeliveryAsync(deliveryCreateArgs);

            var result = await client.CancelDeliveryAsync(deliveryToCancel.Id);
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

            var deliveries = await client.GetDeliveriesAsync();

            var deliveryToTip = deliveries.Where(d => d.Status == PostmatesDeliveryStatuses.Delivered
                                                    && d.Tip is null).FirstOrDefault();

            var tipArgs = new PostmatesDeliveryTipArgs()
            {
                TipByCustomer = tipAmount
            };

            var result = await client.TipCourierAsync(deliveryToTip.Id, tipArgs);

            Assert.True(result.Tip == tipAmount);
            Assert.True(result.Id == deliveryToTip.Id);
        }

    }
}
