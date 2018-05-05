// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using EnterpriseLibrary.Validation.Validators;

namespace EnterpriseLibrary.Validation
{
    /// <summary>
    /// Specifies the kind of composition that is to be used when multiple validation attributes
    /// are supplied for a member info.
    /// </summary>
    public enum CompositionType
    {
        /// <summary>
        /// Use the <see cref="AndCompositeValidator"/>.
        /// </summary>
        And,

        /// <summary>
        /// Use the <see cref="OrCompositeValidator"/>.
        /// </summary>
        Or
    }
}
