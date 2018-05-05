﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Configuration;
using EnterpriseLibrary.Common.Configuration;
using EnterpriseLibrary.Common.TestSupport.Configuration;
using EnterpriseLibrary.Validation.Configuration;
using EnterpriseLibrary.Validation.TestSupport.Configuration;
using EnterpriseLibrary.Validation.TestSupport.TestClasses;
using EnterpriseLibrary.Validation.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Tests.Configuration
{
    [TestClass]
    public class OrCompositeValidatorDataFixture
    {
        [TestMethod]
        public void CanDeserializeSerializedInstanceWithNoChildValidators()
        {
            MockValidationSettings rwSettings = new MockValidationSettings();
            OrCompositeValidatorData rwValidatorData = new OrCompositeValidatorData("validator1");
            rwSettings.Validators.Add(rwValidatorData);
            rwValidatorData.MessageTemplate = "Template";
            rwValidatorData.Tag = "tag";

            IDictionary<string, ConfigurationSection> sections = new Dictionary<string, ConfigurationSection>();
            sections[ValidationSettings.SectionName] = rwSettings;

            using (ConfigurationFileHelper configurationFileHelper = new ConfigurationFileHelper(sections))
            {
                IConfigurationSource configurationSource = configurationFileHelper.ConfigurationSource;

                MockValidationSettings roSettings = configurationSource.GetSection(ValidationSettings.SectionName) as MockValidationSettings;

                Assert.IsNotNull(roSettings);
                Assert.AreEqual(1, roSettings.Validators.Count);
                Assert.AreEqual("validator1", roSettings.Validators.Get(0).Name);
                Assert.AreSame(typeof(OrCompositeValidatorData), roSettings.Validators.Get(0).GetType());
                Assert.AreEqual(0, ((OrCompositeValidatorData)roSettings.Validators.Get(0)).Validators.Count);
                Assert.AreEqual("Template", ((OrCompositeValidatorData)roSettings.Validators.Get(0)).MessageTemplate);
                Assert.AreEqual("tag", ((OrCompositeValidatorData)roSettings.Validators.Get(0)).Tag);
            }
        }

        [TestMethod]
        public void CanDeserializeSerializedInstanceWithChildValidators()
        {
            MockValidationSettings rwSettings = new MockValidationSettings();
            OrCompositeValidatorData rwValidatorData = new OrCompositeValidatorData("validator1");
            rwSettings.Validators.Add(rwValidatorData);
            rwValidatorData.Validators.Add(new MockValidatorData("child validator 1", false));
            rwValidatorData.Validators.Add(new MockValidatorData("child validator 2", false));

            IDictionary<string, ConfigurationSection> sections = new Dictionary<string, ConfigurationSection>();
            sections[ValidationSettings.SectionName] = rwSettings;

            using (ConfigurationFileHelper configurationFileHelper = new ConfigurationFileHelper(sections))
            {
                IConfigurationSource configurationSource = configurationFileHelper.ConfigurationSource;

                MockValidationSettings roSettings = configurationSource.GetSection(ValidationSettings.SectionName) as MockValidationSettings;

                Assert.IsNotNull(roSettings);
                Assert.AreEqual(1, roSettings.Validators.Count);
                Assert.AreEqual("validator1", roSettings.Validators.Get(0).Name);
                Assert.AreSame(typeof(OrCompositeValidatorData), roSettings.Validators.Get(0).GetType());
                Assert.AreEqual(2, ((OrCompositeValidatorData)roSettings.Validators.Get(0)).Validators.Count);
                Assert.AreEqual("child validator 1", ((OrCompositeValidatorData)roSettings.Validators.Get(0)).Validators.Get(0).Name);
                Assert.AreEqual("child validator 2", ((OrCompositeValidatorData)roSettings.Validators.Get(0)).Validators.Get(1).Name);
            }
        }

        [TestMethod]
        public void CanCreateValidatorFromEmptyConfigurationObject()
        {
            OrCompositeValidatorData rwValidatorData = new OrCompositeValidatorData("validator1");

            Validator validator = ((IValidatorDescriptor)rwValidatorData).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(OrCompositeValidator), validator.GetType());
            IList<Validator> validators = ValidationTestHelper.CreateListFromEnumerable<Validator>(((OrCompositeValidator)validator).Validators);
            Assert.AreEqual(0, validators.Count);
        }

        [TestMethod]
        public void CanCreateValidatorFromConfigurationObject()
        {
            OrCompositeValidatorData rwValidatorData = new OrCompositeValidatorData("validator1");
            rwValidatorData.Validators.Add(new MockValidatorData("child validator 1", false));
            rwValidatorData.Validators.Get(0).MessageTemplate = "child validator 1";
            rwValidatorData.Validators.Add(new MockValidatorData("child validator 2", false));
            rwValidatorData.Validators.Get(1).MessageTemplate = "child validator 2";

            Validator validator = ((IValidatorDescriptor)rwValidatorData).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(OrCompositeValidator), validator.GetType());
            IList<Validator> validators = ValidationTestHelper.CreateListFromEnumerable<Validator>(((OrCompositeValidator)validator).Validators);
            Assert.AreEqual(2, validators.Count);
            Assert.AreEqual("child validator 1", ((MockValidator<object>)validators[0]).MessageTemplate);
            Assert.AreEqual("child validator 2", ((MockValidator<object>)validators[1]).MessageTemplate);
        }
    }
}
