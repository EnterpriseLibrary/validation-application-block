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
    public class DomainValidatorDataFixture
    {
        [TestMethod]
        public void CanDeserializeSerializedInstanceWithName()
        {
            MockValidationSettings rwSettings = new MockValidationSettings();
            DomainValidatorData rwValidatorData = new DomainValidatorData("validator1");
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
                Assert.AreSame(typeof(DomainValidator<object>), roSettings.Validators.Get(0).Type);
                Assert.IsNotNull(((DomainValidatorData)roSettings.Validators.Get(0)).Domain);
            }
        }

        [TestMethod]
        public void CanDeserializeSerializedInstanceWithValuesSet()
        {
            MockValidationSettings rwSettings = new MockValidationSettings();
            DomainValidatorData rwValidatorData = new DomainValidatorData("validator1");
            rwSettings.Validators.Add(rwValidatorData);
            rwValidatorData.Negated = true;
            rwValidatorData.Domain.Add(new DomainConfigurationElement("1"));
            rwValidatorData.Domain.Add(new DomainConfigurationElement("2"));
            rwValidatorData.Domain.Add(new DomainConfigurationElement("3"));

            IDictionary<string, ConfigurationSection> sections = new Dictionary<string, ConfigurationSection>();
            sections[ValidationSettings.SectionName] = rwSettings;

            using (ConfigurationFileHelper configurationFileHelper = new ConfigurationFileHelper(sections))
            {
                IConfigurationSource configurationSource = configurationFileHelper.ConfigurationSource;

                MockValidationSettings roSettings = configurationSource.GetSection(ValidationSettings.SectionName) as MockValidationSettings;

                Assert.IsNotNull(roSettings);
                Assert.AreEqual(1, roSettings.Validators.Count);
                Assert.AreEqual("validator1", roSettings.Validators.Get(0).Name);
                Assert.AreSame(typeof(DomainValidator<object>), roSettings.Validators.Get(0).Type);
                Assert.AreEqual(true, ((DomainValidatorData)roSettings.Validators.Get(0)).Negated);
                Assert.AreEqual(3, ((DomainValidatorData)roSettings.Validators.Get(0)).Domain.Count);
            }
        }

        [TestMethod]
        public void CanCreateValidatorFromConfigurationObject()
        {
            DomainValidatorData rwValidatorData = new DomainValidatorData("validator1");
            rwValidatorData.Negated = true;
            rwValidatorData.Domain.Add(new DomainConfigurationElement("1"));
            rwValidatorData.Domain.Add(new DomainConfigurationElement("2"));
            rwValidatorData.Domain.Add(new DomainConfigurationElement("3"));

            Validator validator = ((IValidatorDescriptor)rwValidatorData).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(DomainValidator<object>), validator.GetType());
            Assert.AreEqual(Resources.DomainNegatedDefaultMessageTemplate, validator.MessageTemplate);
            Assert.AreEqual(true, ((DomainValidator<object>)validator).Negated);
            Assert.AreEqual(3, ((DomainValidator<object>)validator).Domain.Count);
            Assert.IsTrue(typeof(string).Equals(((DomainValidator<object>)validator).Domain[0].GetType()));
        }

        [TestMethod]
        public void CanCreateValidatorFromConfigurationObjectUsingIntDomain()
        {
            DomainValidatorData rwValidatorData = new DomainValidatorData("validator1");
            rwValidatorData.Negated = true;
            rwValidatorData.Domain.Add(new DomainConfigurationElement("1"));
            rwValidatorData.Domain.Add(new DomainConfigurationElement("2"));
            rwValidatorData.Domain.Add(new DomainConfigurationElement("3"));

            Validator validator = ((IValidatorDescriptor)rwValidatorData).CreateValidator(typeof(int), null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(DomainValidator<object>), validator.GetType());
            Assert.AreEqual(Resources.DomainNegatedDefaultMessageTemplate, validator.MessageTemplate);
            Assert.AreEqual(true, ((DomainValidator<object>)validator).Negated);
            Assert.AreEqual(3, ((DomainValidator<object>)validator).Domain.Count);
            Assert.IsTrue(typeof(int).Equals(((DomainValidator<object>)validator).Domain[0].GetType()));
        }

        [TestMethod]
        public void CanCreateValidatorFromConfigurationObjectWithMessageTemplateOverride()
        {
            DomainValidatorData rwValidatorData = new DomainValidatorData("validator1");
            rwValidatorData.MessageTemplate = "message template override";
            rwValidatorData.Negated = true;
            rwValidatorData.Domain.Add(new DomainConfigurationElement("1"));
            rwValidatorData.Domain.Add(new DomainConfigurationElement("2"));
            rwValidatorData.Domain.Add(new DomainConfigurationElement("3"));

            Validator validator = ((IValidatorDescriptor)rwValidatorData).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(DomainValidator<object>), validator.GetType());
            Assert.AreEqual("message template override", validator.MessageTemplate);
            Assert.AreEqual(true, ((DomainValidator<object>)validator).Negated);
            Assert.AreEqual(3, ((DomainValidator<object>)validator).Domain.Count);
            Assert.IsTrue(typeof(string).Equals(((DomainValidator<object>)validator).Domain[0].GetType()));
        }
    }
}
