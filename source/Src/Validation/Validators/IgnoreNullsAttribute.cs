// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Validators
{
    /// <summary>
    /// Indicates that a <see langword="null"/> value is to be allowed by the validator represented by the validation
    /// attributes for the language element this attribute is bound.
    /// </summary>
    /// <seealso cref="ValidatorAttribute"/>
    [AttributeUsage(AttributeTargets.Property
        | AttributeTargets.Field
        | AttributeTargets.Method
        | AttributeTargets.Parameter,
        AllowMultiple = true,
        Inherited = false)]
    public sealed class IgnoreNullsAttribute : BaseValidationAttribute
    {
        private readonly Guid typeId = Guid.NewGuid();

        /// <summary>
        /// Gets a unique identifier for this attribute.
        /// </summary>
        public override object TypeId
        {
            get
            {
                return this.typeId;
            }
        }
    }
}
