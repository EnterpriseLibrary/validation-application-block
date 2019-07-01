// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Validators
{
    /// <summary>
    /// Date time unit.
    /// </summary>
    public enum DateTimeUnit
    {
        /// <summary>
        /// No units.
        /// </summary>
        None,
        /// <summary>
        /// Seconds.
        /// </summary>
        Second,
        /// <summary>
        /// Minutes.
        /// </summary>
        Minute,
        /// <summary>
        /// Hours.
        /// </summary>
        Hour,
        /// <summary>
        /// Days.
        /// </summary>
        Day,
        /// <summary>
        /// Months.
        /// </summary>
        Month,
        /// <summary>
        /// Years.
        /// </summary>
        Year
    }
}
