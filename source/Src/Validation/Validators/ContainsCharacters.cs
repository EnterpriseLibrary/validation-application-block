// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;

namespace EnterpriseLibrary.Validation.Validators
{
    /// <summary>
    /// Represents the behavior of the <see cref="ContainsCharactersValidator"/>.
    /// </summary>
    public enum ContainsCharacters
    {
        /// <summary>
        /// Indicates that validation is considered successful when at least one character in the
        /// character set is included in the validated value.
        /// </summary>
        Any,
        /// <summary>
        /// Indicates that validation is considered successful when at all the characters in the
        /// character set are included in the validated value.
        /// </summary>
        All
    }

}
