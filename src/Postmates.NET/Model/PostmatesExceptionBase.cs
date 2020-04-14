//-----------------------------------------------------------------------------
// FILE:	    PostmatesExceptionBase.cs
// CONTRIBUTOR: Ian White
// COPYRIGHT:	Copyright (c) 2018-2020 by Loopie, Inc.  All rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

using Postmates.Model;

namespace Postmates.Model
{
    public class PostmatesExceptionBase : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="code"></param>
        public PostmatesExceptionBase(PostmatesExceptionArgs postmatesExceptionArgs)
        {
            PostmatesErrorCode = postmatesExceptionArgs.Code;
            PostmatesMessage = postmatesExceptionArgs.Message;
        }

        /// <summary>
        /// The error code from Postmates.
        /// </summary>
        [JsonProperty(PropertyName = "postmates_error_code", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public PostmatesErrorCodes PostmatesErrorCode { get; set; }

        /// <summary>
        /// The error message from Postmates.
        /// </summary>
        [JsonProperty(PropertyName = "postmates_message", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        public string PostmatesMessage { get; set; }
    }
}
