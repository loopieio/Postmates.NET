//-----------------------------------------------------------------------------
// FILE:	    TestCategory.cs
// CONTRIBUTOR: Marcus Bowyer
// COPYRIGHT:	Copyright (c) 2019 by Postmates, LLC.  All rights reserved.

namespace Postmates.Xunit
{
    /// <summary>
    /// Defines constants used to help categorize unit tests and avoid
    /// spelling errors and inconsistencies.
    /// </summary>
    public static class TestCategory
    {
        /// <summary>
        /// Identifies the trait.
        /// </summary>
        public const string CategoryTrait = "Category";

        /// <summary>
        /// Identifies sample tests.
        /// </summary>
        public const string Sample = "Sample";

        /// <summary>
        /// Identifies integration tests.
        /// </summary>
        public const string Integration = "Integration";

        /// <summary>
        /// Identifies mock tests.
        /// </summary>
        public const string Mock = "Mock";

        /// <summary>
        /// Identifies a test that should be run daily.
        /// </summary>
        public const string Daily = "Daily";

        /// <summary>
        /// A test that should be run after a master merge.
        /// </summary>
        public const string MasterMerge = "MasterMerge";

    }
}
