//-----------------------------------------------------------------------------
// FILE:	    PostmatesDeliveryQuoteArgs.cs
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

namespace Postmates.Model
{
    /// <summary>
    /// Arguments passed to the get delivery quote endpoint.
    /// </summary>
    public class PostmatesDeliveryQuoteArgs
    {
        //---------------------------------------------------------------------
        // Static members

        /// <summary>
        /// Constructor.
        /// </summary>
        public PostmatesDeliveryQuoteArgs()
        {

        }

        /// <summary>
        /// The pickup address for a potential delivery.
        /// </summary>
        [JsonProperty(PropertyName = "pickup_address", Required = Required.Always)]
        public PostmatesAddress PickupAddress { get; set; }

        /// <summary>
        /// Optional latitude of pickup location, will be used instead of geocoding address if passed. 
        /// Example: "37.778307"
        /// </summary>
        [JsonProperty(PropertyName = "pickup_latitude", Required = Required.Default)]
        public double PickupLatitude { get; set; }

        /// <summary>
        /// Optional longitude of pickup location, will be used instead of geocoding address if passed. 
        /// Example: "-122.413524"
        /// </summary>
        [JsonProperty(PropertyName = "pickup_longitude", Required = Required.Default)]
        public double PickupLongitude { get; set; }

        /// <summary>
        /// Optional phone number of the pickup location. If passed, the phone number will be validated.
        /// Example: "415-555-8484"
        /// </summary>
        [JsonProperty(PropertyName = "pickup_phone_number", Required = Required.Default)]
        public string PickupPhoneNumber { get; set; }

        /// <summary>
        /// The dropoff address for a potential delivery.
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_address", Required = Required.Always)]
        public PostmatesAddress DropoffAddress { get; set; }

        /// <summary>
        /// Optional latitude of dropoff location, will be used instead of geocoding address if passed.
        /// Example: "37.778307"
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_latitude", Required = Required.Default)]
        public double DropoffLatitude { get; set; }

        /// <summary>
        /// Optional longitude of dropoff location, will be used instead of geocoding address if passed. 
        /// Example: "-122.413524"
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_longitude", Required = Required.Default)]
        public double DropoffLongitude { get; set; }

        /// <summary>
        /// Optional phone number of the dropoff location. If passed, the phone number will be validated. 
        /// Example: "415-555-8484"
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_phone_number", Required = Required.Always)]
        public string DropoffPhoneNumber { get; set; }

        /// <summary>
        /// Validates the devlivery quote arguments are ready to be sent to postmates
        /// </summary>
        public void Validate()
        {
            PickupPhoneNumber = PickupPhoneNumber.ToSimplePhoneNumber();
            DropoffPhoneNumber = DropoffPhoneNumber.ToSimplePhoneNumber();
            PickupAddress.Validate();
            DropoffAddress.Validate();
        }
    }
}
