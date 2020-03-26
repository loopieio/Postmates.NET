//-----------------------------------------------------------------------------
// FILE:	    PostmatesManifestItem.cs
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
    public class PostmatesManifestItem
    {
        //---------------------------------------------------------------------
        // Static members

        /// <summary>
        /// Constructor.
        /// </summary>
        public PostmatesManifestItem()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "quantity", Required = Required.Always)]
        public int Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "size", Required = Required.Always)]
        public PostmatesItemSizes Size { get; set; }

    }
}
