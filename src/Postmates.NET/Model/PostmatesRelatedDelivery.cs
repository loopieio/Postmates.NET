//-----------------------------------------------------------------------------
// FILE:	    PostmatesRelatedDelivery.cs
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
    public class PostmatesRelatedDelivery
    {
        //---------------------------------------------------------------------
        // Static members

        /// <summary>
        /// Constructor.
        /// </summary>
        public PostmatesRelatedDelivery()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "relationship", Required = Required.Always)]
        public string Relationship { get; set; }

    }
}
