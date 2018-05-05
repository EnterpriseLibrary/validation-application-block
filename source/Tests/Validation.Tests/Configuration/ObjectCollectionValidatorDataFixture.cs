﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Configuration;
using EnterpriseLibrary.Common.Configuration;
using EnterpriseLibrary.Common.TestSupport.Configuration;
using EnterpriseLibrary.Validation.Configuration;
using EnterpriseLibrary.Validation.TestSupport.Configuration;
using EnterpriseLibrary.Validation.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Tests.Configuration
{
    [TestClass]
    public class ObjectCollectionValidatorDataFixture
    {
        [TestInitialize]
        public void TestInitialize()
        {
            ValidationFactory.SetDefaultConfigurationValidatorFactory(new SystemConfigurationSource(false));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ValidationFactory.Reset();
        }

        [TestMethod]
        public void CanDeserializeSerializedInstanceWithNameOnly()
        {
            MockValidationSettings rwSettings = new MockValidationSettings();
            ObjectCollectionValidatorData rwValidatorData = new ObjectCollectionValidatorData("validator1");
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
                Assert.AreSame(typeof(ObjectCollectionValidator), roSettings.Validators.Get(0).Type);
                Assert.AreEqual(null, ((ObjectCollectionValidatorData)roSettings.Validators.Get(0)).TargetType);
                Assert.AreEqual(string.Empty, ((ObjectCollectionValidatorData)roSettings.Validators.Get(0)).TargetRuleset);
            }
        }

        [TestMethod]
        public void CanDeserializeSerializedInstanceWithNameTargetTypeAndTargetRuleset()
        {
            MockValidationSettings rwSettings = new MockValidationSettings();
            ObjectCollectionValidatorData rwValidatorData = new ObjectCollectionValidatorData("validator1");
            rwSettings.Validators.Add(rwValidatorData);
            rwValidatorData.TargetType = typeof(ObjectCollectionValidatorDataFixture);
            rwValidatorData.TargetRuleset = "ruleset";

            IDictionary<string, ConfigurationSection> sections = new Dictionary<string, ConfigurationSection>();
            sections[ValidationSettings.SectionName] = rwSettings;

            using (ConfigurationFileHelper configurationFileHelper = new ConfigurationFileHelper(sections))
            {
                IConfigurationSource configurationSource = configurationFileHelper.ConfigurationSource;

                MockValidationSettings roSettings = configurationSource.GetSection(ValidationSettings.SectionName) as MockValidationSettings;

                Assert.IsNotNull(roSettings);
                Assert.AreEqual(1, roSettings.Validators.Count);
                Assert.AreEqual("validator1", roSettings.Validators.Get(0).Name);
                Assert.AreSame(typeof(ObjectCollectionValidator), roSettings.Validators.Get(0).Type);
                Assert.AreSame(typeof(ObjectCollectionValidatorDataFixture), ((ObjectCollectionValidatorData)roSettings.Validators.Get(0)).TargetType);
                Assert.AreEqual("ruleset", ((ObjectCollectionValidatorData)roSettings.Validators.Get(0)).TargetRuleset);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationErrorsException))]
        [Ignore]    // no longer true
        public void CreateValidatorWithNullTargetTypeThrows()
        {
            ObjectCollectionValidatorData rwValidatorData = new ObjectCollectionValidatorData("validator1");

            ((IValidatorDescriptor)rwValidatorData).CreateValidator(null, null, null, null);
        }

        [TestMethod]
        public void CanCreateValidatorFromConfigurationObject()
        {
            ObjectCollectionValidatorData rwValidatorData = new ObjectCollectionValidatorData("validator1");
            rwValidatorData.TargetType = typeof(ObjectCollectionValidatorDataFixture);
            rwValidatorData.TargetRuleset = "ruleset";

            Validator validator =
                ((IValidatorDescriptor)rwValidatorData).CreateValidator(null, null, null, ValidationFactory.DefaultCompositeValidatorFactory);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(ObjectCollectionValidator), validator.GetType());
            Assert.AreSame(typeof(ObjectCollectionValidatorDataFixture), ((ObjectCollectionValidator)validator).TargetType);
            Assert.AreEqual("ruleset", ((ObjectCollectionValidator)validator).TargetRuleset);
            Assert.AreEqual(null, ((ObjectCollectionValidator)validator).MessageTemplate);
        }

        [TestMethod]
        public void CanCreateValidatorFromConfigurationObjectWithNoTargetType()
        {
            ObjectCollectionValidatorData rwValidatorData = new ObjectCollectionValidatorData("validator1");
            rwValidatorData.TargetRuleset = "ruleset";

            Validator validator =
                ((IValidatorDescriptor)rwValidatorData).CreateValidator(null, null, null, ValidationFactory.DefaultCompositeValidatorFactory);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(ObjectCollectionValidator), validator.GetType());
            Assert.IsNull(((ObjectCollectionValidator)validator).TargetType);
            Assert.AreEqual("ruleset", ((ObjectCollectionValidator)validator).TargetRuleset);
            Assert.AreEqual(null, ((ObjectCollectionValidator)validator).MessageTemplate);
        }
    }
}
