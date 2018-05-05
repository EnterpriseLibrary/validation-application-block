﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Tests
{
    [TestClass]
    public class GivenValidatorForTypeWithNoValidationAttributesCreatedWithValidationAttributeValidatorFactory
    {
        private Validator validator;

        [TestInitialize]
        public void Setup()
        {
            var factory = new ValidationAttributeValidatorFactory();
            this.validator = factory.CreateValidator<TypeWithNoValidationAttributes>();
        }

        [TestMethod]
        public void ThenValidatorIsNotNull()
        {
            Assert.IsNotNull(this.validator);
        }

        [TestMethod]
        public void WhenValidatingInstance_ThenInstanceIsValid()
        {
            var result = this.validator.Validate(new TypeWithNoValidationAttributes());

            Assert.IsTrue(result.IsValid);
        }


        public class TypeWithNoValidationAttributes
        {
            public int MyProperty { get; set; }

            public string MyField;

            public int MyMethod()
            {
                return MyProperty;
            }
        }
    }

    [TestClass]
    public class GivenValidatorForTypeWithValidationAttributesCreatedWithValidationAttributeValidatorFactory
    {
        private Validator validator;

        [TestInitialize]
        public void Setup()
        {
            var factory =
                new ValidationAttributeValidatorFactory();
            this.validator = factory.CreateValidator<TypeWithValidationAttributes>();
        }

        [TestMethod]
        public void ThenValidatorIsNotNull()
        {
            Assert.IsNotNull(this.validator);
        }

        [TestMethod]
        public void WhenValidatingValidInstance_ThenResultIsValid()
        {
            var instance = new TypeWithValidationAttributes { MyProperty = 6, MyField = "valid" };

            var result = this.validator.Validate(instance);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void WhenValidatingInstanceWithInvalidPropertyValid_ThenResultIsNotValid()
        {
            var instance = new TypeWithValidationAttributes { MyProperty = 20, MyField = "valid" };

            var result = this.validator.Validate(instance);

            Assert.IsFalse(result.IsValid);
        }

        public class TypeWithValidationAttributes
        {
            [Range(4, 10, ErrorMessage = "range")]
            public int MyProperty { get; set; }

            [Required(ErrorMessage = "required")]
            [StringLength(10, ErrorMessage = "length")]
            public string MyField;

            public int MyMethod()
            {
                return MyProperty;
            }
        }
    }

    [TestClass]
    public class GivenValidatorForTypeWithValidationAttributesCreatedWithValidationAttributeValidatorFactoryForARuleset
    {
        private Validator validator;

        [TestInitialize]
        public void Setup()
        {
            var factory =
                new ValidationAttributeValidatorFactory();
            this.validator = factory.CreateValidator<TypeWithValidationAttributes>("ruleset");
        }

        [TestMethod]
        public void ThenValidatorIsNotNull()
        {
            Assert.IsNotNull(this.validator);
        }

        [TestMethod]
        public void WhenValidatingValidInstance_ThenResultIsValid()
        {
            var instance = new TypeWithValidationAttributes { MyProperty = 6, MyField = "valid" };

            var result = this.validator.Validate(instance);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void WhenValidatingInstanceWithInvalidPropertyAccordingToTheRules_ThenResultIsValid()
        {
            var instance = new TypeWithValidationAttributes { MyProperty = 20, MyField = "valid" };

            var result = this.validator.Validate(instance);

            Assert.IsTrue(result.IsValid);
        }

        public class TypeWithValidationAttributes
        {
            [Range(4, 10, ErrorMessage = "range")]
            public int MyProperty { get; set; }

            [Required(ErrorMessage = "required")]
            [StringLength(10, ErrorMessage = "length")]
            public string MyField;

            public int MyMethod()
            {
                return MyProperty;
            }
        }
    }
}
