//-----------------------------------------------------------------------------
// FILE:	    StringHelper.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2019 by Loopie, LLC.  All rights reserved.

using Newtonsoft.Json.Converters;

namespace Postmates.API
{
    /// <summary>
    /// Sets the correct DateTime format for when interacting with 
    /// the Postmates API.
    /// </summary>
    public class PostmatesDateTimeConverter : IsoDateTimeConverter
    {

        /// <summary>
        /// Constructor. Sets the DateTimeFormat
        /// </summary>
        public PostmatesDateTimeConverter()
        {
            base.DateTimeFormat = "yyy-MM-ddTHH:mm:ss.ffZ";
        }


    }
}
