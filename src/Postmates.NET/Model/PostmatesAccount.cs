//-----------------------------------------------------------------------------
// FILE:	    PostmatesAccount.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2019 by Loopie, LLC.  All rights reserved.

using System;
using System.ComponentModel;

using Neon.Common;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Postmates.API
{
    /// <summary>
    /// Specifies the Postmates account infomation required to aces the REST API
    /// </summary>
    public class PostmatesAccount
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="secret"></param>
        public PostmatesAccount(string customerId, string secret)
        {
            CustomerId = customerId;
            SignatureSecret = secret;
        }

        /// <summary>
        /// The Postmates customer ID.
        /// </summary>
        [JsonProperty(PropertyName = "CustomerId", Required = Required.Always)]
        public string CustomerId { get; set; }

        /// <summary>
        /// The REST API signature secret.
        /// </summary>
        [JsonProperty(PropertyName = "SignatureSecret", Required = Required.Always)]
        public string SignatureSecret { get; set; }
    }
}
