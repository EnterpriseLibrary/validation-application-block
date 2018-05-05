// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;

namespace EnterpriseLibrary.Validation.Validators
{
    /// <summary>
    /// Represents a <see cref="TypeConversionValidator"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property
        | AttributeTargets.Field
        | AttributeTargets.Method
        | AttributeTargets.Parameter,
        AllowMultiple = true,
        Inherited = false)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1019",
        Justification = "Fields are used internally")]
    public sealed class TypeConversionValidatorAttribute : ValueValidatorAttribute
    {
        private Type targetType;

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="TypeConversionValidatorAttribute"/>.</para>
        /// </summary>
        /// <param name="targetType">The supplied type used to determine if the string can be converted to it.</param>
        public TypeConversionValidatorAttribute(Type targetType)
        {
            ValidatorArgumentsValidatorHelper.ValidateTypeConversionValidator(targetType);

            this.targetType = targetType;
        }

        /// <summary>
        /// The target type. 
        /// </summary>
        public Type TargetType
        {
            get { return targetType; }
        }

        /// <summary>
        /// Creates the <see cref="TypeConversionValidator"/> described by the attribute object.
        /// </summary>
        /// <param name="targetType">The type of object that will be validated by the validator.</param>
        /// <remarks>This operation must be overriden by subclasses.</remarks>
        /// <returns>The created <see cref="TypeConversionValidator"/>.</returns>
        protected override Validator DoCreateValidator(Type targetType)
        {
            return new TypeConversionValidator(this.TargetType, Negated);
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

