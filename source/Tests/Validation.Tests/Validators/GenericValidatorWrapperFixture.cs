// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Tests.Validators
{
    [TestClass]
    public class GenericValidatorWrapperFixture
    {
        [TestMethod]
        public void FailureIsDeterminedByWrappedValidator()
        {
            string target = "";

            MockValidator<object> wrappedValidator = new MockValidator<object>(true, "message");
            Validator<string> validator = new GenericValidatorWrapper<string>(wrappedValidator);

            ValidationResults validationResults = validator.Validate(target);

            Assert.IsFalse(validationResults.IsValid);
            Assert.AreSame(target, wrappedValidator.ValidatedTargets[0]);
            IList<ValidationResult> resultsList = ValidationTestHelper.GetResultsList(validationResults);
            Assert.AreEqual(1, resultsList.Count);
            Assert.AreEqual("message", resultsList[0].Message);
        }

        [TestMethod]
        public void SuccessIsDeterminedByWrappedValidator()
        {
            string target = "";

            MockValidator<object> wrappedValidator = new MockValidator<object>(false, "message");
            Validator<string> validator = new GenericValidatorWrapper<string>(wrappedValidator);

            ValidationResults validationResults = validator.Validate(target);

            Assert.IsTrue(validationResults.IsValid);
            Assert.AreSame(target, wrappedValidator.ValidatedTargets[0]);
        }
    }
}
