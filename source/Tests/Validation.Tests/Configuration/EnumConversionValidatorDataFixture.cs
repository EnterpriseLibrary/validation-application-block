// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Configuration;
using EnterpriseLibrary.Common.Configuration;
using EnterpriseLibrary.Common.TestSupport.Configuration;
using EnterpriseLibrary.Validation.Configuration;
using EnterpriseLibrary.Validation.Properties;
using EnterpriseLibrary.Validation.Tests.Validators;
using EnterpriseLibrary.Validation.TestSupport.Configuration;
using EnterpriseLibrary.Validation.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Tests.Configuration
{
    [TestClass]
    public class EnumConversionValidatorDataFixture
    {
        [TestMethod]
        public void CanDeserializeSerializedInstanceWithNameOnly()
        {
            MockValidationSettings rwSettings = new MockValidationSettings();
            EnumConversionValidatorData rwValidatorData = new EnumConversionValidatorData("validator1");
            rwSettings.Validators.Add(rwValidatorData);

            IDictionary<string, ConfigurationSection> sections = new Dictionary<string, ConfigurationSection>();
            sections[ValidationSettings.SectionName] = rwSettings;

            using (ConfigurationFileHelper configurationFileHelper = new ConfigurationFileHelper(sections))
            {
                IConfigurationSource configurationSource = configurationFileHelper.ConfigurationSource;

                MockValidationSettings roSettings = configurationSource.GetSection(ValidationSettings.SectionName) as MockValidationSettings;

                Assert.IsNotNull(roSettings);
                Assert.AreEqual(1, roSettings.Validators.Count);
                Assert.AreEqual("validator1", roSettings.Validators.Get(0).Name);
                Assert.AreSame(typeof(EnumConversionValidator), roSettings.Validators.Get(0).Type);
            }
        }

        [TestMethod]
        public void CanDeserializeSerializedInstanceWithValuesSet()
        {
            MockValidationSettings rwSettings = new MockValidationSettings();
            EnumConversionValidatorData rwValidatorData = new EnumConversionValidatorData("validator1");
            rwSettings.Validators.Add(rwValidatorData);
            rwValidatorData.Negated = true;
            rwValidatorData.EnumType = typeof(MockEnumValidator);

            IDictionary<string, ConfigurationSection> sections = new Dictionary<string, ConfigurationSection>();
            sections[ValidationSettings.SectionName] = rwSettings;

            using (ConfigurationFileHelper configurationFileHelper = new ConfigurationFileHelper(sections))
            {
                IConfigurationSource configurationSource = configurationFileHelper.ConfigurationSource;

                MockValidationSettings roSettings = configurationSource.GetSection(ValidationSettings.SectionName) as MockValidationSettings;

                Assert.IsNotNull(roSettings);
                Assert.AreEqual(1, roSettings.Validators.Count);
                Assert.AreEqual("validator1", roSettings.Validators.Get(0).Name);
                Assert.AreSame(typeof(EnumConversionValidator), roSettings.Validators.Get(0).Type);
                Assert.AreEqual(true, ((EnumConversionValidatorData)roSettings.Validators.Get(0)).Negated);
                Assert.AreEqual(typeof(MockEnumValidator), ((EnumConversionValidatorData)roSettings.Validators.Get(0)).EnumType);
            }
        }

        [TestMethod]
        public void CanCreateValidatorFromConfigurationObject()
        {
            EnumConversionValidatorData rwValidatorData = new EnumConversionValidatorData("validator1");
            rwValidatorData.Negated = true;
            rwValidatorData.EnumType = typeof(MockEnumValidator);

            Validator validator = ((IValidatorDescriptor)rwValidatorData).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(EnumConversionValidator), validator.GetType());
            Assert.AreEqual(Resources.EnumConversionNegatedDefaultMessageTemplate, validator.MessageTemplate);
            Assert.AreEqual(true, ((EnumConversionValidator)validator).Negated);
            Assert.AreEqual(typeof(MockEnumValidator), ((EnumConversionValidator)validator).EnumType);
        }

        [TestMethod]
        public void CanCreateValidatorFromConfigurationObjectWithMessageTemplateOverride()
        {
            EnumConversionValidatorData rwValidatorData = new EnumConversionValidatorData("validator1");
            rwValidatorData.MessageTemplate = "message template override";
            rwValidatorData.Negated = true;
            rwValidatorData.EnumType = typeof(MockEnumValidator);

            Validator validator = ((IValidatorDescriptor)rwValidatorData).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(EnumConversionValidator), validator.GetType());
            Assert.AreEqual("message template override", validator.MessageTemplate);
            Assert.AreEqual(true, ((EnumConversionValidator)validator).Negated);
            Assert.AreEqual(typeof(MockEnumValidator), ((EnumConversionValidator)validator).EnumType);
        }
    }
}
