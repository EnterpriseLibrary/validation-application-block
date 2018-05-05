﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using EnterpriseLibrary.Validation.TestSupport.TestClasses;
using EnterpriseLibrary.Validation.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Tests
{
    [TestClass]
    public class ValidatorAttributeFixture
    {
        [TestMethod]
        public void RulesetNameIsEmptyStringByDefault()
        {
            ValidatorAttribute attribute = new MockValidatorAttribute(false);

            Assert.AreEqual("", attribute.Ruleset);
        }

        [TestMethod]
        public void MessageTemplatePropertiesAreNullByDefault()
        {
            ValidatorAttribute attribute = new MockValidatorAttribute(false);

            Assert.AreEqual(null, attribute.MessageTemplate);
            Assert.AreEqual(null, attribute.MessageTemplateResourceName);
            Assert.AreEqual(null, attribute.MessageTemplateResourceType);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SettingMessageTemplateResourceNameWhenMessageTemplateIsSetThrows()
        {
            ValidatorAttribute attribute = new MockValidatorAttribute(false);

            attribute.MessageTemplate = "template";
            attribute.MessageTemplateResourceName = "template resource";
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SettingMessageTemplateResourceTypeWhenMessageTemplateIsSetThrows()
        {
            ValidatorAttribute attribute = new MockValidatorAttribute(false);

            attribute.MessageTemplate = "template";
            attribute.MessageTemplateResourceType = typeof(TestResources);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SettingMessageTemplateWhenMessageTemplateResourceNameIsSetThrows()
        {
            ValidatorAttribute attribute = new MockValidatorAttribute(false);

            attribute.MessageTemplateResourceName = "template resource";
            attribute.MessageTemplate = "template";
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SettingMessageTemplateWhenMessageTemplateResourceTypeIsSetThrows()
        {
            ValidatorAttribute attribute = new MockValidatorAttribute(false);

            attribute.MessageTemplateResourceType = typeof(TestResources);
            attribute.MessageTemplate = "template";
        }

        [TestMethod]
        public void GetsNullMessageTemplateIfNoOverridesAreSet()
        {
            ValidatorAttribute attribute = new MockValidatorAttribute(false);

            Assert.AreEqual(null, attribute.GetMessageTemplate());
        }

        [TestMethod]
        public void GetsOverridenMessageTemplateIfMessageOverrideIsSet()
        {
            ValidatorAttribute attribute = new MockValidatorAttribute(false);
            attribute.MessageTemplate = "overriden";

            Assert.AreEqual("overriden", attribute.GetMessageTemplate());
        }

        [TestMethod]
        public void GetOverridenMessageTemplateFromResourceIfBothResourceNameAndTypeAreSet()
        {
            ValidatorAttribute attribute = new MockValidatorAttribute(false);
            attribute.MessageTemplateResourceName = "overriden";
            attribute.MessageTemplateResourceType = typeof(TestResources);

            Assert.AreEqual("overriden from resource", attribute.GetMessageTemplate());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RequestForMessageTemplateWhenOnlyResourceTypeIsSetThrows()
        {
            ValidatorAttribute attribute = new MockValidatorAttribute(false);
            attribute.MessageTemplateResourceName = "overriden";

            attribute.GetMessageTemplate();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RequestForMessageTemplateWhenOnlyResourceNameIsSetThrows()
        {
            ValidatorAttribute attribute = new MockValidatorAttribute(false);
            attribute.MessageTemplateResourceType = typeof(TestResources);

            attribute.GetMessageTemplate();
        }

        [TestMethod]
        public void AttributeCanCreateValidator()
        {
            MockValidatorAttribute validatorAttribute = new MockValidatorAttribute(false);

            Validator validator = ((IValidatorDescriptor)validatorAttribute).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreEqual(MockValidator.DefaultMockValidatorMessageTemplate, validator.MessageTemplate);
            Assert.IsNull(validator.Tag);
        }

        [TestMethod]
        public void CreatedValidatorWillHaveTagIfSpecified()
        {
            MockValidatorAttribute validatorAttribute = new MockValidatorAttribute(false);
            validatorAttribute.Tag = "tag";

            Validator validator = ((IValidatorDescriptor)validatorAttribute).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreEqual(MockValidator.DefaultMockValidatorMessageTemplate, validator.MessageTemplate);
            Assert.AreEqual("tag", validator.Tag);
            Assert.AreEqual("tag", validatorAttribute.Tag);
        }

        [TestMethod]
        public void CreatedValidatorWillHaveOverridenMessageIfSpecified()
        {
            MockValidatorAttribute validatorAttribute = new MockValidatorAttribute(false);
            validatorAttribute.MessageTemplate = "message override";

            Validator validator = ((IValidatorDescriptor)validatorAttribute).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreEqual("message override", validator.MessageTemplate);
            Assert.IsNull(validator.Tag);
        }
    }
}
