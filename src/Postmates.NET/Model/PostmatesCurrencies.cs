//-----------------------------------------------------------------------------
// FILE:	    PostmatesCurrencies.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2017-2018 by Loopie, LLC.  All rights reserved.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Postmates.Model
{
    /// <summary>
    /// Enumerates the postmates currencies.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PostmatesCurrencies
    {
        /// <summary>
        /// US Dollars.
        /// </summary>
        [EnumMember(Value = "usd")]
        USD
    }
}
