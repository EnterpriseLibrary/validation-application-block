// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    [MockValidator(false, MessageTemplate = "DerivedTestTypeWithValidatorAttributesOnMembersAndType-Message1")]
    [MockValidator(false, MessageTemplate = "DerivedTestTypeWithValidatorAttributesOnMembersAndType-Message2")]
    [MockValidator(false, MessageTemplate = "DerivedTestTypeWithValidatorAttributesOnMembersAndType-Message1-RuleA", Ruleset = "RuleA")]
    [MockValidator(false, MessageTemplate = "DerivedTestTypeWithValidatorAttributesOnMembersAndType-Message2-RuleA", Ruleset = "RuleA")]
    [MockValidator(false, MessageTemplate = "DerivedTestTypeWithValidatorAttributesOnMembersAndType-Message3-RuleA", Ruleset = "RuleA")]
    [MockValidator(false, MessageTemplate = "DerivedTestTypeWithValidatorAttributesOnMembersAndType-Message1-RuleB", Ruleset = "RuleB")]
    public class DerivedTestTypeWithValidatorAttributesOnMembersAndType : BaseTestTypeWithValidatorAttributes
    {
        [MockValidator(false, MessageTemplate = "PropertyWithMultipleAttributesOverride-Message1")]
        public override object PropertyWithMultipleAttributes
        {
            get
            {
                return base.PropertyWithMultipleAttributes;
            }
        }

        [MockValidator(false, MessageTemplate = "MethodWithMultipleAttributesOverride-Message1")]
        [MockValidator(false, MessageTemplate = "MethodWithMultipleAttributesOverride-Message1-RuleA", Ruleset = "RuleA")]
        [MockValidator(false, MessageTemplate = "MethodWithMultipleAttributesOverride-Message2-RuleA", Ruleset = "RuleA")]
        public override object MethodWithMultipleAttributes()
        {
            return base.PropertyWithMultipleAttributes;
        }
    }
}
