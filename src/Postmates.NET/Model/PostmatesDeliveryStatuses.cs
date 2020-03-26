//-----------------------------------------------------------------------------
// FILE:	    PostmatesDeliveryStatuses.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2018-2020 by Loopie, Inc.  All rights reserved.

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
        /// Pending
        /// </summary>
        [EnumMember(Value = "pending")]
        Pending,

        /// <summary>
        /// Pickup
        /// </summary>
        [EnumMember(Value = "pickup")]
        Pickup,

        /// <summary>
        /// Pickup Complete
        /// </summary>
        [EnumMember(Value = "pickup_complete")]
        PickupComplete,

        /// <summary>
        /// Dropoff
        /// </summary>
        [EnumMember(Value = "dropoff")]
        Dropoff,

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
        /// Ongoing
        /// </summary>
        [EnumMember(Value = "ongoing")]
        Ongoing
    }
}
