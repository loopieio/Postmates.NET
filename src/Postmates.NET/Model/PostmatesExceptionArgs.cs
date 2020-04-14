//-----------------------------------------------------------------------------
// FILE:	    PostmatesExceptionArgs.cs
// CONTRIBUTOR: Ian White
// COPYRIGHT:	Copyright (c) 2018-2020 by Loopie, Inc.  All rights reserved.

using System;
using System.ComponentModel;
using System.Diagnostics.Contracts;

using Neon.Common;

using Postmates.Model;
using Postmates.API;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Postmates.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class PostmatesExceptionArgs
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public PostmatesExceptionArgs()
        {

        }

        /// <summary>
        /// The kind of response (always error).
        /// </summary>
        [JsonProperty(PropertyName = "kind", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string Kind { get; set; }

        /// <summary>
        /// The code.
        /// </summary>
        [JsonProperty(PropertyName = "code", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public PostmatesErrorCodes Code { get; set; }

        /// <summary>
        /// The message.
        /// </summary>
        [JsonProperty(PropertyName = "message", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string Message { get; set; }

        /* TODO: Add the error messages specific to the parameters of the request. Postmates returns details such as: 
         * "dropoff_name": "Dropoff name is required.",
         * "dropoff_phone_number": "Dropoff phone number must be valid phone number."
         */
    }
}
