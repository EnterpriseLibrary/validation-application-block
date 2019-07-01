// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class TypeWithValidatorAttributesWithRuleNames
    {
        [MockValidator(true, MessageTemplate = "PropertyWithMixedRulesInValidationAttributes1-NoRule")]
        [MockValidator(true, MessageTemplate = "PropertyWithMixedRulesInValidationAttributes2-NoRule")]
        [MockValidator(true, MessageTemplate = "PropertyWithMixedRulesInValidationAttributes-RuleA", Ruleset = "RuleA")]
        [MockValidator(true, MessageTemplate = "PropertyWithMixedRulesInValidationAttributes3-NoRule")]
        [MockValidator(true, MessageTemplate = "PropertyWithMixedRulesInValidationAttributes-RuleB", Ruleset = "RuleB")]
        public string PropertyWithMixedRulesInValidationAttributes
        {
            get { return null; }
        }

        [MockValidator(true, MessageTemplate = "FieldWithMixedRulesInValidationAttributes1-NoRule")]
        [MockValidator(true, MessageTemplate = "FieldWithMixedRulesInValidationAttributes2-NoRule")]
        [MockValidator(true, MessageTemplate = "FieldWithMixedRulesInValidationAttributes-RuleA", Ruleset = "RuleA")]
        [MockValidator(true, MessageTemplate = "FieldWithMixedRulesInValidationAttributes3-NoRule")]
        [MockValidator(true, MessageTemplate = "FieldWithMixedRulesInValidationAttributes-RuleB", Ruleset = "RuleB")]
        public string FieldWithMixedRulesInValidationAttributes = null;

        [MockValidator(true, MessageTemplate = "MethodWithMixedRulesInValidationAttributes1-NoRule")]
        [MockValidator(true, MessageTemplate = "MethodWithMixedRulesInValidationAttributes2-NoRule")]
        [MockValidator(true, MessageTemplate = "MethodWithMixedRulesInValidationAttributes-RuleA", Ruleset = "RuleA")]
        [MockValidator(true, MessageTemplate = "MethodWithMixedRulesInValidationAttributes3-NoRule")]
        [MockValidator(true, MessageTemplate = "MethodWithMixedRulesInValidationAttributes-RuleB", Ruleset = "RuleB")]
        public string MethodWithMixedRulesInValidationAttributes()
        {
            return null;
        }
    }
}
