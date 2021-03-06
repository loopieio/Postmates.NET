﻿//-----------------------------------------------------------------------------
// FILE:	    PostmatesKinds.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2018-2020 by Loopie, Inc.  All rights reserved.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Postmates
{
    /// <summary>
    /// Enumerates the postmates kinds.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PostmatesKinds
    {
        /// <summary>
        /// Delivery quote
        /// </summary>
        [EnumMember(Value = "delivery_quote")]
        DeliveryQuote,

        /// <summary>
        /// Delivery
        /// </summary>
        [EnumMember(Value = "delivery")]
        Delivery
    }
}
