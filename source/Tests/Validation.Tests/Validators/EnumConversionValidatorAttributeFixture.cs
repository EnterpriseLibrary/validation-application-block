﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.ComponentModel.DataAnnotations;
using EnterpriseLibrary.Validation.Properties;
using EnterpriseLibrary.Validation.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Tests.Validators
{
    [TestClass]
    public class EnumConversionValidatorAttributeFixture
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructionOfAttributeWithNullPatternThrows()
        {
            new EnumConversionValidatorAttribute(null);
        }

        [TestMethod]
        public void AttributeWithEnumTypeCreatesValidator()
        {
            ValidatorAttribute attribute = new EnumConversionValidatorAttribute(typeof(MockEnumValidator));

            Validator validator = ((IValidatorDescriptor)attribute).CreateValidator(null, null, null, null);
            Assert.IsNotNull(validator);

            EnumConversionValidator typedValidator = validator as EnumConversionValidator;
            Assert.IsNotNull(typedValidator);

            Assert.AreEqual(Resources.EnumConversionNonNegatedDefaultMessageTemplate, validator.MessageTemplate);
            Assert.AreEqual(typeof(MockEnumValidator), typedValidator.EnumType);
            Assert.AreEqual(false, typedValidator.Negated);
        }

        [TestMethod]
        public void AttributeWithEnumTypeAndNegatedCreatesValidator()
        {
            ValueValidatorAttribute attribute = new EnumConversionValidatorAttribute(typeof(MockEnumValidator));
            attribute.Negated = true;

            Validator validator = ((IValidatorDescriptor)attribute).CreateValidator(null, null, null, null);
            Assert.IsNotNull(validator);

            EnumConversionValidator typedValidator = validator as EnumConversionValidator;
            Assert.IsNotNull(typedValidator);

            Assert.AreEqual(Resources.EnumConversionNegatedDefaultMessageTemplate, validator.MessageTemplate);
            Assert.AreEqual(typeof(MockEnumValidator), typedValidator.EnumType);
            Assert.AreEqual(true, typedValidator.Negated);
        }

        [TestMethod]
        public void AttributeWithEnumTypeAndMessageTemplateCreatesValidator()
        {
            ValidatorAttribute attribute = new EnumConversionValidatorAttribute(typeof(MockEnumValidator));
            attribute.MessageTemplate = "my message template";

            Validator validator = ((IValidatorDescriptor)attribute).CreateValidator(null, null, null, null);
            Assert.IsNotNull(validator);

            EnumConversionValidator typedValidator = validator as EnumConversionValidator;
            Assert.IsNotNull(typedValidator);

            Assert.AreEqual("my message template", validator.MessageTemplate);
            Assert.AreEqual(typeof(MockEnumValidator), typedValidator.EnumType);
            Assert.AreEqual(false, typedValidator.Negated);
        }

        [TestMethod]
        public void AttributeWithEnumTypeAndMessageTemplateAndNegatedCreatesValidator()
        {
            ValueValidatorAttribute attribute = new EnumConversionValidatorAttribute(typeof(MockEnumValidator));
            attribute.Negated = true;
            attribute.MessageTemplate = "my message template";

            Validator validator = ((IValidatorDescriptor)attribute).CreateValidator(null, null, null, null);
            Assert.IsNotNull(validator);

            EnumConversionValidator typedValidator = validator as EnumConversionValidator;
            Assert.IsNotNull(typedValidator);

            Assert.AreEqual("my message template", validator.MessageTemplate);
            Assert.AreEqual(typeof(MockEnumValidator), typedValidator.EnumType);
            Assert.AreEqual(true, typedValidator.Negated);
        }

        [TestMethod]
        public void CanUseAttributeAsValidationAttributeForValidValue()
        {
            ValidationAttribute attribute =
                new EnumConversionValidatorAttribute(typeof(MockEnumValidator))
                {
                    MessageTemplate = "template {1}"
                };

            Assert.IsTrue(attribute.IsValid("MyEnumValue"));
        }

        [TestMethod]
        public void CanUseAttributeAsValidationAttribute()
        {
            ValidationAttribute attribute =
                new EnumConversionValidatorAttribute(typeof(MockEnumValidator))
                {
                    MessageTemplate = "template {1}"
                };

            Assert.IsFalse(attribute.IsValid("invalid"));
            Assert.AreEqual("template name", attribute.FormatErrorMessage("name"));
        }

        [TestMethod]
        public void ValidatingWithValidatorAttributeWithARulesetSkipsValidation()
        {
            ValidationAttribute attribute =
                new EnumConversionValidatorAttribute(typeof(MockEnumValidator))
                {
                    MessageTemplate = "template {1}",
                    Ruleset = "some ruleset"
                };

            Assert.IsTrue(attribute.IsValid("invalid"));
        }
    }
}
