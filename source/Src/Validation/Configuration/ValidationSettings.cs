// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Configuration;
using EnterpriseLibrary.Common.Configuration;
using EnterpriseLibrary.Common.Configuration.Design;

namespace EnterpriseLibrary.Validation.Configuration
{
    /// <summary>
    /// Configuration section for stored validation information.
    /// </summary>
    /// <seealso cref="ValidatedTypeReference"/>
    [ViewModel(ValidationDesignTime.ViewModelTypeNames.ValidationSectionViewModel)]
    [ResourceDescription(typeof(DesignResources), "ValidationSettingsDescription")]
    [ResourceDisplayName(typeof(DesignResources), "ValidationSettingsDisplayName")]
    public class ValidationSettings : SerializableConfigurationSection
    {
        ///<summary>
        /// Tries to retrieve the <see cref="ValidationSettings"/>.
        ///</summary>
        ///<param name="configurationSource"></param>
        ///<returns></returns>
        public static ValidationSettings TryGet(IConfigurationSource configurationSource)
        {
            if (configurationSource == null) throw new ArgumentNullException("configurationSource");

            return configurationSource.GetSection(ValidationSettings.SectionName) as ValidationSettings;
        }

        /// <summary>
        /// The name used to serialize the configuration section.
        /// </summary>
        public const string SectionName = BlockSectionNames.Validation;

        private const string TypesPropertyName = "";
        /// <summary>
        /// Gets the collection of types for which validation has been configured.
        /// </summary>
        [ConfigurationProperty(TypesPropertyName, IsDefaultCollection = true)]
        [ResourceDescription(typeof(DesignResources), "ValidationSettingsTypesDescription")]
        [ResourceDisplayName(typeof(DesignResources), "ValidationSettingsTypesDisplayName")]
        public ValidatedTypeReferenceCollection Types
        {
            get { return (ValidatedTypeReferenceCollection)this[TypesPropertyName]; }
        }
    }
}
