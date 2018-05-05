// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using EnterpriseLibrary.Validation.Validators;

namespace EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class TypeWithValidatorSelfValidationAttributes
    {
        public void MethodWithoutSelfValidationAttributes(ValidationResults validationResults)
        {
            validationResults.AddResult(new ValidationResult("MethodWithoutSelfValidationAttributes", null, null, null, null));
        }

        [SelfValidation]
        public void MethodWithSelfValidationAttributes(ValidationResults validationResults)
        {
            validationResults.AddResult(new ValidationResult("MethodWithSelfValidationAttributes", null, null, null, null));
        }

        [SelfValidation]
        [SelfValidation]
        [SelfValidation]
        public void MethodWithMultipleSelfValidationAttributes(ValidationResults validationResults)
        {
            validationResults.AddResult(new ValidationResult("MethodWithMultipleSelfValidationAttributes", null, null, null, null));
        }

        [SelfValidation(Ruleset = "RuleA")]
        public void MethodWithSelfValidationAttributesWithRuleset(ValidationResults validationResults)
        {
            validationResults.AddResult(new ValidationResult("MethodWithSelfValidationAttributesWithRuleset", null, null, null, null));
        }
    }
}
