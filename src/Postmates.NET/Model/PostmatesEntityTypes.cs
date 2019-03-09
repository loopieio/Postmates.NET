//-----------------------------------------------------------------------------
// FILE:	    PostmatesEntityTypes.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2017-2018 by Tarukino, LLC.  All rights reserved.

using System;
using Postmates.Model;
using Postmates.API;

namespace Postmates.Model
{
    /// <summary>
    /// Enumerates the Couchbase document type strings used for Postmates related
    /// purposes.  Note that document types use <b>"::"</b> as a separator to 
    /// provide a simple namespace scheme for document types and IDs.  By convention,
    /// document types are lowercase.
    /// </summary>
    public static class PostmatesEntityTypes
    {
        /// <summary>
        /// Represents a delivery quote.
        /// </summary>
        public const string DeliveryQuote = "postmates::delivery::quote";
    }
}
