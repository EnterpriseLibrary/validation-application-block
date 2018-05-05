// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using EnterpriseLibrary.Common.Configuration;
using EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS.TestService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS
{
    /// <summary>
    /// Test fixture to make sure the test service is configured properly
    /// with validators.
    /// </summary>
    [TestClass]
    public class TestServiceFixture
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
        public void ShouldFailValidationWithInvalidSSN()
        {
            AddCustomerRequest request = new AddCustomerRequest("John", "Doe", "Not an SSN");
            Validator v = ValidationFactory.CreateValidator<AddCustomerRequest>();
            ValidationResults results = v.Validate(request);
            Assert.IsFalse(results.IsValid);
        }

        [TestMethod]
        public void ShouldPassValidationWithValidSSN()
        {
            AddCustomerRequest request = new AddCustomerRequest("John", "Doe", "012-34-5678");
            Validator v = ValidationFactory.CreateValidator<AddCustomerRequest>();
            ValidationResults results = v.Validate(request);
            Assert.IsTrue(results.IsValid);
        }
    }
}
