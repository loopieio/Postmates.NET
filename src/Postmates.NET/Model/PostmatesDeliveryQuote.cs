//-----------------------------------------------------------------------------
// FILE:	    PostmatesDeliveryQuote.cs
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
    /// Represens a delivery quote from Postmates
    /// </summary>
    public class PostmatesDeliveryQuote
    {
        //---------------------------------------------------------------------
        // Static members

        /// <summary>
        /// Returns the Couchbase key for a delivery quote based on its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The Couchbase key.</returns>
        public static string GetKey(string id)
        {
            Covenant.Requires<ArgumentNullException>(!string.IsNullOrEmpty(id));

            return $"{PostmatesEntityTypes.DeliveryQuote}::{GetRef(id)}";
        }

        /// <summary>
        /// Returns the Couchbase reference for an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The Couchbase reference.</returns>
        public static string GetRef(string id)
        {
            Covenant.Requires<ArgumentNullException>(!string.IsNullOrEmpty(id));

            return id;
        }

        /// <summary>
        /// Constuctor.
        /// </summary>
        public PostmatesDeliveryQuote()
        {

        }

        /// <summary>
        /// The kind of API response.
        /// </summary>
        [JsonProperty(PropertyName = "kind", Required = Required.Always)]
        public PostmatesKinds Kind { get; set; }

        /// <summary>
        /// The ID of the quote.
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        /// <summary>
        /// Date/Time the quote was created.
        /// </summary>
        [JsonProperty(PropertyName = "created", Required = Required.Always)]
        public DateTime Created { get; set; }

        /// <summary>
        /// Date/Time after which the quote will no longer be accepted.
        /// </summary>
        [JsonProperty(PropertyName = "expires", Required = Required.Always)]
        public DateTime Expires { get; set; }

        /// <summary>
        /// Amount in cents that will be charged if this delivery is created (see "Other Standards » Currency").
        /// </summary>
        [JsonProperty(PropertyName = "fee", Required = Required.Always)]
        public int Fee { get; set; }

        /// <summary>
        /// Currency the "amount" values are in. (see "Other Standards » Currency").
        /// </summary>
        [JsonProperty(PropertyName = "currency", Required = Required.Always)]
        public string Currency { get; set; }

        /// <summary>
        /// Estimated drop-off time. This value may increase to several hours if the postmates platform is in high demand.
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_eta", Required = Required.Always)]
        public DateTime DropoffEta { get; set; }

        /// <summary>
        /// Estimated minutes for this delivery to reach dropoff, this value can be highly variable based upon the current amount of capacity available.
        /// </summary>
        [JsonProperty(PropertyName = "duration", Required = Required.Always)]
        public int Duration { get; set; }

        /// <summary>
        /// Estimated minutes until a courier will arrive at the pickup. This value can be highly variable based upon the current amount of capacity available.
        /// </summary>
        [JsonProperty(PropertyName = "pickup_duration", Required = Required.Always)]
        public int PickupDuration { get; set; }
    }
}
