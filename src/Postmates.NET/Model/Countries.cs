//-----------------------------------------------------------------------------
// FILE:	    Countries.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2017-2018 by Loopie, LLC.  All rights reserved.

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using System.Runtime.Serialization;

namespace Postmates.Model
{
    /// <summary>
    /// Enumerates country codes.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Countries
    {
        /// <summary>
        /// No country code is specified.
        /// </summary>
        [EnumMember(Value = "unspecified")]
        Unspecified = 0,

        //-------------------------------------------------
        // Countries

        /// <summary>
        /// United States
        /// </summary>
        [EnumMember(Value = "US")]
        US
    }
}
