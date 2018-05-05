// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;

namespace EnterpriseLibrary.Validation.Validators
{
    /// <summary>
    /// Indicates that the kind of composition to use when multiple <see cref="ValidatorAttribute"/> instances
    /// are bound to a language element.
    /// </summary>
    /// <seealso cref="ValidatorAttribute"/>
    [AttributeUsage(AttributeTargets.Property
        | AttributeTargets.Field
        | AttributeTargets.Method
        | AttributeTargets.Parameter
        | AttributeTargets.Class,
        AllowMultiple = true,
        Inherited = false)]
    public sealed class ValidatorCompositionAttribute : BaseValidationAttribute
    {
        private CompositionType compositionType;
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorCompositionAttribute"/> class.
        /// </summary>
        /// <param name="compositionType">The <see cref="CompositionType"/> to be used.</param>
        public ValidatorCompositionAttribute(CompositionType compositionType)
        {
            this.compositionType = compositionType;
        }

        /// <summary>
        /// The <see cref="CompositionType"/> to be used.
        /// </summary>
        public CompositionType CompositionType
        {
            get { return compositionType; }
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
