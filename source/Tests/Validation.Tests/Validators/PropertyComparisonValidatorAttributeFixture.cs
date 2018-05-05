// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.ComponentModel.DataAnnotations;
using EnterpriseLibrary.Validation.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Tests.Validators
{
    [TestClass]
    public class PropertyComparisonValidatorAttributeFixture
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatingInstanceWithNullPropertyNameThrows()
        {
            new PropertyComparisonValidatorAttribute(null, ComparisonOperator.Equal);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AttributeWithInvalidPropertyNameThrowsWhenCreatingValidator()
        {
            MemberValueAccessBuilder builder = new ReflectionMemberValueAccessBuilder();
            IValidatorDescriptor validatorAttribute = new PropertyComparisonValidatorAttribute("InvalidProperty", ComparisonOperator.Equal);

            validatorAttribute.CreateValidator(typeof(PropertyComparisonValidatorAttributeFixtureTestClass),
                                               typeof(PropertyComparisonValidatorAttributeFixtureTestClass),
                                               builder,
                                               null);
        }

        [TestMethod]
        public void CreatesAppropriateValidator()
        {
            MemberValueAccessBuilder builder = new ReflectionMemberValueAccessBuilder();
            PropertyComparisonValidatorAttribute validatorAttribute = new PropertyComparisonValidatorAttribute("PublicProperty", ComparisonOperator.NotEqual);
            validatorAttribute.Negated = true;

            PropertyComparisonValidator validator = ((IValidatorDescriptor)validatorAttribute).CreateValidator(typeof(PropertyComparisonValidatorAttributeFixtureTestClass),
                                                                                                               typeof(PropertyComparisonValidatorAttributeFixtureTestClass),
                                                                                                               builder,
                                                                                                               null) as PropertyComparisonValidator;

            Assert.IsNotNull(validator);
            Assert.AreEqual("PublicProperty", ((PropertyValueAccess)validator.ValueAccess).PropertyInfo.Name);
            Assert.AreEqual(ComparisonOperator.NotEqual, validator.ComparisonOperator);
            Assert.AreEqual(true, validator.Negated);
        }

        public class PropertyComparisonValidatorAttributeFixtureTestClass
        {
            string publicProperty;

            public string PublicProperty
            {
                get { return publicProperty; }
                set { publicProperty = value; }
            }
        }

        [TestMethod]
        public void AttributeWithNullRulesetCannotBeUsedAsValidationAttribute()
        {
            ValidationAttribute attribute =
                new PropertyComparisonValidatorAttribute("proeprty", ComparisonOperator.NotEqual);

            try
            {
                attribute.IsValid("");
                Assert.Fail("should have thrown");
            }
            catch (NotSupportedException)
            {
            }
        }

        [TestMethod]
        public void AttributeWithNonNullRulesetReturnsValid()
        {
            ValidationAttribute attribute =
                new PropertyComparisonValidatorAttribute("proeprty", ComparisonOperator.NotEqual)
                {
                    Ruleset = "ruleset"
                };

            Assert.IsTrue(attribute.IsValid(""));
        }
    }
}
