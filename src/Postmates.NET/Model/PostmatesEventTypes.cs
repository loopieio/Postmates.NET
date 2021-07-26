//-----------------------------------------------------------------------------
// FILE:	    PostmatesEventTypes.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2018-2020 by Loopie, Inc.  All rights reserved.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Postmates
{
    /// <summary>
    /// Enumerates the Postmates Webhook event types.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PostmatesEventTypes
    {
        /// <summary>
        /// Delivery status update event
        /// </summary>
        [EnumMember(Value = "event.delivery_status")]
        DeliveryStatus,

        /// <summary>
        /// Courier update event
        /// </summary>
        [EnumMember(Value = "event.courier_update")]
        CourierUpdate,

        /// <summary>
        /// Delivery return event
        /// </summary>
        [EnumMember(Value = "event.delivery_return")]
        DeliveryReturn
    }
}
