// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Validation
{
    ///<summary>
    /// A <see cref="Validator"/> factory producing validators from rules specified in a configuration file.
    ///</summary>
    /// <seealso cref="ValidatorFactory"/>
    public class ConfigurationValidatorFactory : ValidatorFactory
    {
        ///<summary>
        /// Creates a <see cref="ConfigurationValidatorFactory"/> based on a configuration source.
        ///</summary>
        ///<param name="configurationSource"></param>
        ///<returns>A new ConfigurationValidatorFactory</returns>
        public static ConfigurationValidatorFactory FromConfigurationSource(IConfigurationSource configurationSource)
        {
            return new ConfigurationValidatorFactory(configurationSource);
        }

        ///<summary>
        /// Initializes a <see cref="ConfigurationValidatorFactory"/>.
        ///</summary>
        ///<param name="configurationSource">The configuration source containing the validation rules to create validators from.</param>
        public ConfigurationValidatorFactory(IConfigurationSource configurationSource)
        {
            ConfigurationSource = configurationSource;
        }

        ///<summary>
        /// The <see cref="IConfigurationSource"/> the factory uses for determining validation rules.
        ///</summary>
        public IConfigurationSource ConfigurationSource { get; private set; }

        /// <summary>
        /// Creates the validator for the specified target and ruleset.
        /// </summary>
        /// <param name="targetType">The <see cref="Type"/>to validate.</param>
        /// <param name="ruleset">The ruleset to use when validating</param>
        /// <param name="mainValidatorFactory">Factory to use when building nested validators.</param>
        /// <returns>A <see cref="Validator"/></returns>
        protected internal override Validator InnerCreateValidator(Type targetType, string ruleset, ValidatorFactory mainValidatorFactory)
        {
            ConfigurationValidatorBuilder builder =
                new ConfigurationValidatorBuilder(
                    ValidationSettings.TryGet(ConfigurationSource),
                    MemberAccessValidatorBuilderFactory.Default,
                    mainValidatorFactory);

            return builder.CreateValidator(targetType, ruleset);
        }
    }
}
