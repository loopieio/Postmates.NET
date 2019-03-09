//-----------------------------------------------------------------------------
// FILE:	    PostmatesLocation.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2019 by Loopie, LLC.  All rights reserved.

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
    public class PostmatesLocation
    {
        //---------------------------------------------------------------------
        // Static members

        /// <summary>
        /// Constructor.
        /// </summary>
        public PostmatesLocation()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Default)]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "phone_number", Required = Required.Default)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "address", Required = Required.Default)]
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "detailed_address", Required = Required.Default)]
        public PostmatesAddress DetailedAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "notes", Required = Required.Default)]
        public string Notes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "location", Required = Required.Default)]
        public PostmatesCoordinates Location { get; set; }

    }
}
