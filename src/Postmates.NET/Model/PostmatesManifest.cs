//-----------------------------------------------------------------------------
// FILE:	    PostmatesManifest.cs
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
    public class PostmatesManifest
    {
        //---------------------------------------------------------------------
        // Static members

        /// <summary>
        /// Constructor.
        /// </summary>
        public PostmatesManifest()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "reference", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string Reference { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "description", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string Description { get; set; }

    }
}
