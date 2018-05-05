// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using EnterpriseLibrary.Validation.Properties;
using EnterpriseLibrary.Validation.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Tests.Validators
{
    [TestClass]
    public class NotNullValidatorAttributeFixture
    {
        [TestMethod]
        public void CanCreateNonNegatedValidatorWithAttribute()
        {
            ValidatorAttribute validatorAttribute = new NotNullValidatorAttribute();

            Validator validator = ((IValidatorDescriptor)validatorAttribute).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(NotNullValidator), validator.GetType());
            Assert.AreEqual(Resources.NonNullNonNegatedValidatorDefaultMessageTemplate, validator.MessageTemplate);
            Assert.AreEqual(false, ((NotNullValidator)validator).Negated);
        }

        [TestMethod]
        public void CanCreateNegatedValidatorWithAttribute()
        {
            ValueValidatorAttribute validatorAttribute = new NotNullValidatorAttribute();
            validatorAttribute.Negated = true;

            Validator validator = ((IValidatorDescriptor)validatorAttribute).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(NotNullValidator), validator.GetType());
            Assert.AreEqual(Resources.NonNullNegatedValidatorDefaultMessageTemplate, validator.MessageTemplate);
            Assert.AreEqual(true, ((NotNullValidator)validator).Negated);
        }

        [TestMethod]
        public void CanCreateValidatorWithAttributeAndMessageOverride()
        {
            string messageTemplateOverride = "overriden message template";

            ValueValidatorAttribute validatorAttribute = new NotNullValidatorAttribute();
            validatorAttribute.MessageTemplate = messageTemplateOverride;

            Validator validator = ((IValidatorDescriptor)validatorAttribute).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(NotNullValidator), validator.GetType());
            Assert.AreEqual(messageTemplateOverride, validator.MessageTemplate);
            Assert.AreEqual(false, ((NotNullValidator)validator).Negated);
        }

        [TestMethod]
        public void CanCreateValidatorWithAttributeAndMessageOverrideAndNegated()
        {
            string messageTemplateOverride = "overriden message template";

            ValueValidatorAttribute validatorAttribute = new NotNullValidatorAttribute();
            validatorAttribute.Negated = true;
            validatorAttribute.MessageTemplate = messageTemplateOverride;

            Validator validator = ((IValidatorDescriptor)validatorAttribute).CreateValidator(null, null, null, null);

            Assert.IsNotNull(validator);
            Assert.AreSame(typeof(NotNullValidator), validator.GetType());
            Assert.AreEqual(messageTemplateOverride, validator.MessageTemplate);
            Assert.AreEqual(true, ((NotNullValidator)validator).Negated);
        }

        [TestMethod]
        public void CanUseAttributeAsValidationAttributeForValidValue()
        {
            ValidationAttribute attribute =
                new NotNullValidatorAttribute()
                {
                    MessageTemplate = "template {1}"
                };

            Assert.IsTrue(attribute.IsValid(new object()));
        }

        [TestMethod]
        public void CanUseAttributeAsValidationAttribute()
        {
            ValidationAttribute attribute =
                new NotNullValidatorAttribute()
                {
                    MessageTemplate = "template {1}"
                };

            Assert.IsFalse(attribute.IsValid(null));
            Assert.AreEqual("template name", attribute.FormatErrorMessage("name"));
        }

        [TestMethod]
        public void ValidatingWithValidatorAttributeWithARulesetSkipsValidation()
        {
            ValidationAttribute attribute =
                new NotNullValidatorAttribute()
                {
                    MessageTemplate = "template {1}",
                    Ruleset = "some ruleset"
                };

            Assert.IsTrue(attribute.IsValid(null));
        }
    }
}
