//-----------------------------------------------------------------------------
// FILE:	    PostmatesCoordinates.cs
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
    public class PostmatesCoordinates
    {
        //---------------------------------------------------------------------
        // Static members

        /// <summary>
        /// Constructor.
        /// </summary>
        public PostmatesCoordinates()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "lat", Required = Required.Always)]
        public decimal Lat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "lng", Required = Required.Always)]
        public decimal Lng { get; set; }

    }
}
