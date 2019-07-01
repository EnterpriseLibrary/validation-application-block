// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.Practices.EnterpriseLibrary.Validation
{
    /// <summary>
    /// Specifies the kind of filtering to perform for <see cref="ValidationResults.FindAll"/>
    /// </summary>
    public enum TagFilter
    {
        /// <summary>
        /// Include results with the supplied tags.
        /// </summary>
        Include,

        /// <summary>
        /// Ignore results with the supplied tags.
        /// </summary>
        Ignore
    }
}
