//-----------------------------------------------------------------------------
// FILE:	    PostmatesTypes.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2017-2018 by Loopie, LLC.  All rights reserved.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Postmates.Model
{
    /// <summary>
    /// Enumerates the postmates kinds.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PostmatesTypes
    {
        /// <summary>
        /// Delivery quote
        /// </summary>
        [EnumMember(Value = "Feature")]
        Feature
    }
}
