//-----------------------------------------------------------------------------
// FILE:	    PostmatesDeliveryTipArgs.cs
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
    public class PostmatesDeliveryTipArgs
    {
        //---------------------------------------------------------------------
        // Static members

        /// <summary>
        /// Constructor.
        /// </summary>
        public PostmatesDeliveryTipArgs()
        {

        }

        /// <summary>
        /// Amount in cents that will be paid to the courier as a tip.
        /// </summary>
        [JsonProperty(PropertyName = "tip_by_customer", Required = Required.Always)]
        public int TipByCustomer { get; set; }

    }
}
