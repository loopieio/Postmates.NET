﻿//-----------------------------------------------------------------------------
// FILE:	    PostmatesAccount.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2018-2020 by Loopie, Inc.  All rights reserved.

using Newtonsoft.Json;

using YamlDotNet.Serialization;

namespace Postmates
{
    /// <summary>
    /// Specifies the Postmates account infomation required to aces the REST API
    /// </summary>
    public class PostmatesAccount
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public PostmatesAccount()
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="apiKey"></param>
        public PostmatesAccount(string customerId, string apiKey)
        {
            CustomerId = customerId;
            ApiKey = apiKey;
        }

        /// <summary>
        /// The Postmates customer ID.
        /// </summary>
        [JsonProperty(PropertyName = "CustomerId", Required = Required.Always)]
        [YamlMember(Alias = "customerId", ApplyNamingConventions = false)]
        public string CustomerId { get; set; }

        /// <summary>
        /// The REST API key.
        /// </summary>
        [JsonProperty(PropertyName = "ApiKey", Required = Required.Always)]
        [YamlMember(Alias = "apiKey", ApplyNamingConventions = false)]
        public string ApiKey { get; set; }
    }
}
