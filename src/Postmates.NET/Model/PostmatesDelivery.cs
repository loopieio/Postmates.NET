//-----------------------------------------------------------------------------
// FILE:	    PostmatesDelivery.cs
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
using System.Collections.Generic;

namespace Postmates.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class PostmatesDelivery
    {
        //---------------------------------------------------------------------
        // Static members

        /// <summary>
        /// Constructor.
        /// </summary>
        public PostmatesDelivery()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "kind", Required = Required.Always)]
        public PostmatesKinds Kind { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "id", Required = Required.Always)]
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "created", Required = Required.Always)]
        public DateTime Created { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "updated", Required = Required.Always)]
        public DateTime Updated { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public PostmatesDeliveryStatuses Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "complete", Required = Required.Always)]
        public bool Complete { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "pickup_eta", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public DateTime? PickupEta { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_eta", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public DateTime? DropoffEta { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "pickup_ready", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public DateTime? PickupReady { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "pickup_deadline", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public DateTime? PickupDeadline { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_ready", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public DateTime? DropoffReady { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_deadline", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public DateTime? DropoffDeadline { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "quote_id", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string QuoteId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "fee", Required = Required.Always)]
        public int Fee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "currency", Required = Required.Always)]
        public PostmatesCurrencies Currency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "manifest", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public PostmatesManifest Manifest { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "manifest_items", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public List<PostmatesManifestItem> ManifestItems { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "dropoff_identifier", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string DropoffIdentifier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "pickup", Required = Required.Always)]
        public PostmatesLocation Pickup { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "dropoff", Required = Required.Always)]
        public PostmatesLocation Dropoff { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "courier", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public PostmatesCourier Courier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "courier_imminent", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public bool CourierImminent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "related_deliveries", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public List<PostmatesRelatedDelivery> RelatedDeliveries { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "tracking_url", Required = Required.Always)]
        public string TrackingUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "undeliverable_action", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string UndeliverableAction { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "undeliverable_reason", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public string UndeliverableReason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "live_mode", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public bool LiveMode { get; set; }

        /// <summary>
        /// The tip amount for the delivery.
        /// </summary>
        [JsonProperty(PropertyName = "tip", Required = Required.Default, DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(null)]
        public int? Tip { get; set; }

    }
}
