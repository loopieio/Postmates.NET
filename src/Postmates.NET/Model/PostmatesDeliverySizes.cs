﻿//-----------------------------------------------------------------------------
// FILE:	    PostmatesItemSizes.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2018-2020 by Loopie, Inc.  All rights reserved.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Postmates
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
        Large,

        /// <summary>
        /// Extra Large
        /// </summary>
        [EnumMember(Value = "xlarge")]
        ExtraLarge
    }
}
