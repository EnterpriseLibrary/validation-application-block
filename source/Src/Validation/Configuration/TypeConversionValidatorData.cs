// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Configuration;
using EnterpriseLibrary.Validation.Validators;
using EnterpriseLibrary.Common.Configuration;
using EnterpriseLibrary.Common.Configuration.Design;
using System.ComponentModel;

namespace EnterpriseLibrary.Validation.Configuration
{
    /// <summary>
    /// Configuration object to describe an instance of class <see cref="TypeConversionValidatorData"/>.
    /// </summary>
    [ResourceDescription(typeof(DesignResources), "TypeConversionValidatorDataDescription")]
    [ResourceDisplayName(typeof(DesignResources), "TypeConversionValidatorDataDisplayName")]
    public class TypeConversionValidatorData : ValueValidatorData
    {
        private static readonly AssemblyQualifiedTypeNameConverter typeConverter = new AssemblyQualifiedTypeNameConverter();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="TypeConversionValidatorData"/> class.</para>
        /// </summary>
        public TypeConversionValidatorData() { Type = typeof(TypeConversionValidator); }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="TypeConversionValidatorData"/> class with a name.</para>
        /// </summary>
        /// <param name="name">The name for the instance.</param>
        public TypeConversionValidatorData(string name)
            : base(name, typeof(TypeConversionValidator))
        { }

        private const string TargetTypeNamePropertyName = "targetType";
        /// <summary>
        /// Gets or sets name of the type the represented <see cref="TypeConversionValidator"/> must use for testing conversion.
        /// </summary>
        [ConfigurationProperty(TargetTypeNamePropertyName, IsRequired=true)]
        [Editor(CommonDesignTime.EditorTypes.TypeSelector, CommonDesignTime.EditorTypes.UITypeEditor)]
        [BaseType(typeof(object))]
        [ResourceDescription(typeof(DesignResources), "TypeConversionValidatorDataTargetTypeNameDescription")]
        [ResourceDisplayName(typeof(DesignResources), "TypeConversionValidatorDataTargetTypeNameDisplayName")]
        public string TargetTypeName
        {
            get { return (string)this[TargetTypeNamePropertyName]; }
            set { this[TargetTypeNamePropertyName] = value; }
        }

        /// <summary>
        /// Gets or sets the target element type.
        /// </summary>
        public Type TargetType
        {
            get { return (Type)typeConverter.ConvertFrom(TargetTypeName); }
            set { TargetTypeName = typeConverter.ConvertToString(value); }
        }

        /// <summary>
        /// Creates the <see cref="TypeConversionValidator"/> described by the configuration object.
        /// </summary>
        /// <param name="targetType">The type of object that will be validated by the validator.</param>
        /// <returns>The created <see cref="TypeConversionValidator"/>.</returns>    
        protected override Validator DoCreateValidator(Type targetType)
        {
            return new TypeConversionValidator(TargetType, Negated);
        }
    }
}
