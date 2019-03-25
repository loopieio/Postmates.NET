//-----------------------------------------------------------------------------
// FILE:	    PostmatesDeliveryStatuses.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2017-2018 by Loopie, LLC.  All rights reserved.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Postmates.Model
{
    /// <summary>
    /// Enumerates the postmates delivery statuses.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PostmatesDeliveryStatuses
    {
        /// <summary>
        /// Pickup
        /// </summary>
        [EnumMember(Value = "pickup")]
        Pickup,

        /// <summary>
        /// Pending
        /// </summary>
        [EnumMember(Value = "pending")]
        Pending,

        /// <summary>
        /// Delivered
        /// </summary>
        [EnumMember(Value = "delivered")]
        Delivered,

        /// <summary>
        /// Canceled
        /// </summary>
        [EnumMember(Value = "canceled")]
        Canceled,

        /// <summary>
        /// Returned
        /// </summary>
        [EnumMember(Value = "returned")]
        Returned,

        /// <summary>
        /// Dropoff
        /// </summary>
        [EnumMember(Value = "dropoff")]
        Dropoff,

        /// <summary>
        /// Pickup Complete
        /// </summary>
        [EnumMember(Value = "pickup_complete")]
        PickupComplete


            
    }
}
