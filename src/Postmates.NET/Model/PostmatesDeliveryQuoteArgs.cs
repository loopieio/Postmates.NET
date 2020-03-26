//-----------------------------------------------------------------------------
// FILE:	    PostmatesDeliveryQuoteArgs.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2019 by Loopie, LLC.  All rights reserved.

using Newtonsoft.Json;
using System;
using System.ComponentModel;

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
        [JsonProperty(PropertyName = "pickup_latitude", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public double PickupLatitude { get; set; }

        /// <summary>
        /// Optional longitude of pickup location, will be used instead of geocoding address if passed. 
        /// Example: "-122.413524"
        /// </summary>
        [JsonProperty(PropertyName = "pickup_longitude", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public double PickupLongitude { get; set; }

        /// <summary>
        /// Optional phone number of the pickup location. If passed, the phone number will be validated.
        /// Example: "415-555-8484"
        /// </summary>
        [JsonProperty(PropertyName = "pickup_phone_number", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
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
        [JsonProperty(PropertyName = "dropoff_latitude", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public double DropoffLatitude { get; set; }

        /// <summary>
        /// Optional longitude of dropoff location, will be used instead of geocoding address if passed. 
        /// Example: "-122.413524"
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_longitude", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public double DropoffLongitude { get; set; }

        /// <summary>
        /// Optional phone number of the dropoff location. If passed, the phone number will be validated. 
        /// Example: "415-555-8484"
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_phone_number", Required = Required.Always)]
        public string DropoffPhoneNumber { get; set; }

        /// <summary>
        /// Date/Time for when a delivery is ready to be dropped off.
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_ready_dt", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public DateTime? DropOffReady { get; set; }

        /// <summary>
        /// Date/Time for when a delivery must be picked up by.
        /// </summary>
        [JsonProperty(PropertyName = "pickup_deadline_dt", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public DateTime? PickupDeadline { get; set; }

        /// <summary>
        /// Date/Time for when order will be ready for pickup
        /// </summary>
        [JsonProperty(PropertyName = "pickup_ready_dt", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public DateTime? PickupReady { get; set; }

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
