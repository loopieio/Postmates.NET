//-----------------------------------------------------------------------------
// FILE:	    PostmatesItemSizes.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2017-2018 by Loopie, LLC.  All rights reserved.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Postmates.Model
{
    /// <summary>
    /// Enumerates Postmates delivery item sizes.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PostmatesItemSizes
    {
        /// <summary>
        /// Small
        /// </summary>
        [EnumMember(Value = "small")]
        Small,

        /// <summary>
        /// Medium
        /// </summary>
        [EnumMember(Value = "medium")]
        Medium,

        /// <summary>
        /// Large
        /// </summary>
        [EnumMember(Value = "large")]
        Large
    }
}
