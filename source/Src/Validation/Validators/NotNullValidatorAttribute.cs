// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using Microsoft.Practices.EnterpriseLibrary.Validation.Properties;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Validators
{
    /// <summary>
    /// Describes a <see cref="NotNullValidator"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property
        | AttributeTargets.Field
        | AttributeTargets.Method
        | AttributeTargets.Class
        | AttributeTargets.Parameter,
        AllowMultiple = true,
        Inherited = false)]
    public sealed class NotNullValidatorAttribute : ValueValidatorAttribute
    {
        /// <summary>
        /// Creates the <see cref="NotNullValidator"/> described by the attribute object.
        /// </summary>
        /// <param name="targetType">The type of object that will be validated by the validator.</param>
        /// <returns>The created <see cref="NotNullValidator"/>.</returns>
        protected override Validator DoCreateValidator(Type targetType)
        {
            return new NotNullValidator(Negated);
        }

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
