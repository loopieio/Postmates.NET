//-----------------------------------------------------------------------------
// FILE:	    PostmatesCourier.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2018-2020 by Loopie, Inc.  All rights reserved.

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;

using Neon.Common;

using Postmates.Model;
using Postmates.API;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Postmates.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class PostmatesCourier
    {
        //---------------------------------------------------------------------
        // Static members

        /// <summary>
        /// Constructor.
        /// </summary>
        public PostmatesCourier()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "rating", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string Rating { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "vehicle_type", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string VehicleType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "phone_number", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "location", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public PostmatesLocation Location { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "img_href", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string ImgHref { get; set; }

    }
}
