// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Validators
{
    /// <summary>
    /// Represents the different comparison behaviors available for a <see cref="PropertyComparisonValidator"/>.
    /// </summary>
    public enum ComparisonOperator
    {
        /// <summary>
        /// Comparison for equal.
        /// </summary>
        Equal,

        /// <summary>
        /// Comparison for not equal.
        /// </summary>
        NotEqual,

        /// <summary>
        /// Comparison for greater.
        /// </summary>
        GreaterThan,

        /// <summary>
        /// Comparison for greater or equal.
        /// </summary>
        GreaterThanEqual,

        /// <summary>
        /// Comparison for lesser.
        /// </summary>
        LessThan,

        /// <summary>
        /// Comparison for lesser or equal.
        /// </summary>
        LessThanEqual
    }
}
