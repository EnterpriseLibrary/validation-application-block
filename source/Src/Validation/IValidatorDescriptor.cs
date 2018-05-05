// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;

namespace EnterpriseLibrary.Validation
{
    /// <summary>
    /// Represents the behavior to create a validator for a target type.
    /// </summary>
    public interface IValidatorDescriptor
    {
        /// <summary>
        /// Creates the respresented <see cref="Validator"/>.
        /// </summary>
        /// <param name="targetType">The type of object that will be validated by the validator.</param>
        /// <param name="ownerType">The type of the object from which the value to validate is extracted.</param>
        /// <param name="memberValueAccessBuilder">The <see cref="MemberValueAccessBuilder"/> to use for validators that
        /// require access to properties.</param>
        /// <param name="validatorFactory">Factory to use when building nested validators.</param>
        /// <returns>The new <see cref="Validator"/>.</returns>
        Validator CreateValidator(Type targetType, Type ownerType, MemberValueAccessBuilder memberValueAccessBuilder, ValidatorFactory validatorFactory);
    }
}
