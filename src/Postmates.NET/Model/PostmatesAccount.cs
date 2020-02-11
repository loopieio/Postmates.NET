//-----------------------------------------------------------------------------
// FILE:	    PostmatesAccount.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2019 by Loopie, LLC.  All rights reserved.

using Newtonsoft.Json;

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
        public PostmatesAccount(string customerId, string apiKey)
        {
            CustomerId = customerId;
            ApiKey = apiKey;
        }

        /// <summary>
        /// The Postmates customer ID.
        /// </summary>
        [JsonProperty(PropertyName = "CustomerId", Required = Required.Always)]
        public string CustomerId { get; set; }

        /// <summary>
        /// The REST API key.
        /// </summary>
        [JsonProperty(PropertyName = "ApiKey", Required = Required.Always)]
        public string ApiKey { get; set; }
    }
}
