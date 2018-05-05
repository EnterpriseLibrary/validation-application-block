// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using EnterpriseLibrary.Validation.Validators;

namespace EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    [HasSelfValidation]
    public class DerivedTypeWithSelfValidationAttributesOnMethods : BaseTypeWithSelfValidationAttributesOnMethods
    {
        [SelfValidation]
        [SelfValidation(Ruleset = "RuleA")]
        public void PublicMethodWithSelfValidationAttributeAndMatchingSignature(ValidationResults validationResults)
        {
            validationResults.AddResult(new ValidationResult("PublicMethodWithSelfValidationAttributeAndMatchingSignature", null, null, null, null));
        }

        public void PublicMethodWithMatchingSignatureButWithoutSelfValidationAttribute(ValidationResults validationResults)
        {
            validationResults.AddResult(new ValidationResult("PublicMethodWithMatchingSignatureButWithoutSelfValidationAttribute", null, null, null, null));
        }

        [SelfValidation]
        private void PrivateMethodWithSelfValidationAttributeAndMatchingSignature(ValidationResults validationResults)
        {
            validationResults.AddResult(new ValidationResult("PrivateMethodWithSelfValidationAttributeAndMatchingSignature", null, null, null, null));
        }

        [SelfValidation]
        public void PublicMethodWithSelfValidationAttributeAndWithInvalidParameters(ValidationResults validationResults, bool invalid)
        {
            validationResults.AddResult(new ValidationResult("PublicMethodWithSelfValidationAttributeAndWithInvalidParameters", null, null, null, null));
        }

        [SelfValidation]
        public bool PublicMethodWithSelfValidationAttributeAndWithoutReturnType(ValidationResults validationResults)
        {
            validationResults.AddResult(new ValidationResult("PublicMethodWithSelfValidationAttributeAndWithoutReturnType", null, null, null, null));

            return false;
        }

        public override void OverridenPublicMethodWithMatchingSignatureAndSelfValidationAttributeOnBaseButNotOnOverride(ValidationResults validationResults)
        {
            validationResults.AddResult(new ValidationResult("OverridenPublicMethodWithMatchingSignatureAndSelfValidationAttributeOnBaseButNotOnOverride-Derived", null, null, null, null));
        }

        [SelfValidation]
        public override void OverridenPublicMethodWithMatchingSignatureAndSelfValidationAttributeOnBaseAndOnOverride(ValidationResults validationResults)
        {
            validationResults.AddResult(new ValidationResult("OverridenPublicMethodWithMatchingSignatureAndSelfValidationAttributeOnBaseAndOnOverride-Derived", null, null, null, null));
        }
    }
}
