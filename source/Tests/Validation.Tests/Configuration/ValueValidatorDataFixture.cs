﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Configuration;
using EnterpriseLibrary.Common.Configuration;
using EnterpriseLibrary.Common.TestSupport.Configuration;
using EnterpriseLibrary.Validation.Configuration;
using EnterpriseLibrary.Validation.Properties;
using EnterpriseLibrary.Validation.TestSupport.Configuration;
using EnterpriseLibrary.Validation.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Tests.Configuration
{
    [TestClass]
    public class ValueValidatorDataFixture
    {
        [TestMethod]
        public void CanDeserializeSerializedInstanceWithNameOnly()
        {
            MockValidationSettings rwSettings = new MockValidationSettings();
            ContainsCharactersValidatorData rwValidatorData = new ContainsCharactersValidatorData("validator1");
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
                Assert.AreSame(typeof(ContainsCharactersValidator), roSettings.Validators.Get(0).Type);
                Assert.AreEqual(string.Empty, ((ContainsCharactersValidatorData)roSettings.Validators.Get(0)).CharacterSet);
                Assert.AreEqual(ContainsCharacters.Any, ((ContainsCharactersValidatorData)roSettings.Validators.Get(0)).ContainsCharacters);
            }
        }

        [TestMethod]
        public void CanDeserializeSerializedInstanceWithValuesSet()
        {
            MockValidationSettings rwSettings = new MockValidationSettings();
            ContainsCharactersValidatorData rwValidatorData = new ContainsCharactersValidatorData("validator1");
            rwSettings.Validators.Add(rwValidatorData);
            rwValidatorData.CharacterSet = "abc";
            rwValidatorData.ContainsCharacters = ContainsCharacters.All;

            IDictionary<string, ConfigurationSection> sections = new Dictionary<string, ConfigurationSection>();
            sections[ValidationSettings.SectionName] = rwSettings;

            using (ConfigurationFileHelper configurationFileHelper = new ConfigurationFileHelper(sections))
            {
                IConfigurationSource configurationSource = configurationFileHelper.ConfigurationSource;

                MockValidationSettings roSettings = configurationSource.GetSection(ValidationSettings.SectionName) as MockValidationSettings;

                Assert.IsNotNull(roSettings);
                Assert.AreEqual(1, roSettings.Validators.Count);
                Assert.AreEqual("validator1", roSettings.Validators.Get(0).Name);
                Assert.AreSame(typeof(ContainsCharactersValidator), roSettings.Validators.Get(0).Type);
                Assert.AreEqual("abc", ((ContainsCharactersValidatorData)roSettings.Validators.Get(0)).CharacterSet);
                Assert.AreEqual(ContainsCharacters.All, ((ContainsCharactersValidatorData)roSettings.Validators.Get(0)).ContainsCharacters);
            }
        }

        [TestMethod]
        public void CanCreateValidatorFromConfigurationObject()
        {
            ContainsCharactersValidatorData rwValidatorData = new ContainsCharactersValidatorData("validator1");
            rwValidatorData.CharacterSet = "abc";
            rwValidatorData.ContainsCharacters = ContainsCharacters.All;

            Validator validator = ((IValidatorDescriptor)rwValidatorData).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(ContainsCharactersValidator), validator.GetType());
            Assert.AreEqual("abc", ((ContainsCharactersValidator)validator).CharacterSet);
            Assert.AreEqual(ContainsCharacters.All, ((ContainsCharactersValidator)validator).ContainsCharacters);
            Assert.AreEqual(Resources.ContainsCharactersNonNegatedDefaultMessageTemplate, validator.MessageTemplate);
        }

        [TestMethod]
        public void CanCreateValidatorFromConfigurationObjectWithMessageTemplateOverride()
        {
            ContainsCharactersValidatorData rwValidatorData = new ContainsCharactersValidatorData("validator1");
            rwValidatorData.CharacterSet = "abc";
            rwValidatorData.ContainsCharacters = ContainsCharacters.All;
            rwValidatorData.MessageTemplate = "message template override";

            Validator validator = ((IValidatorDescriptor)rwValidatorData).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(ContainsCharactersValidator), validator.GetType());
            Assert.AreEqual("abc", ((ContainsCharactersValidator)validator).CharacterSet);
            Assert.AreEqual(ContainsCharacters.All, ((ContainsCharactersValidator)validator).ContainsCharacters);
            Assert.AreEqual("message template override", validator.MessageTemplate);
        }
    }
}
