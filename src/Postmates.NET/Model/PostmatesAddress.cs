//-----------------------------------------------------------------------------
// FILE:	    PostmatesAddress.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2018-2020 by Loopie, Inc.  All rights reserved.

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;

using Neon.Common;

using Postmates;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Postmates
{
    /// <summary>
    /// 
    /// </summary>
    public class PostmatesAddress
    {
        //---------------------------------------------------------------------
        // Static members

        /// <summary>
        /// Constructor.
        /// </summary>
        public PostmatesAddress()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "street_address_1", Required = Required.Always)]
        public string StreetAddress1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "street_address_2", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string StreetAddress2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "city", Required = Required.Always)]
        public string City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "state", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public UsStates State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "zip_code", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string ZipCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "country", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public Countries Country { get; set; }

        /// <summary>
        /// Validates that the address is 
        /// </summary>
        public void Validate()
        {
            
        }

        /// <summary>
        /// Returns the address as a string as it should be formatted when sending to the
        /// Postmates API.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{StreetAddress1} {StreetAddress2}, {City}, {State}, {ZipCode}";
        }

    }
}
