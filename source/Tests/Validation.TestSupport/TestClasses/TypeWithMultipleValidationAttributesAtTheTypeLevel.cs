// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    [MockValidator(false, MessageTemplate = "TypeWithMultipleValidationAttributesAtTheTypeLevel-Message1")]
    [MockValidator(false, MessageTemplate = "TypeWithMultipleValidationAttributesAtTheTypeLevel-Message2")]
    [MockValidator(false, MessageTemplate = "TypeWithMultipleValidationAttributesAtTheTypeLevel-Message1-RuleA", Ruleset = "RuleA")]
    [MockValidator(false, MessageTemplate = "TypeWithMultipleValidationAttributesAtTheTypeLevel-Message2-RuleA", Ruleset = "RuleA")]
    [MockValidator(false, MessageTemplate = "TypeWithMultipleValidationAttributesAtTheTypeLevel-Message3-RuleA", Ruleset = "RuleA")]
    [MockValidator(false, MessageTemplate = "TypeWithMultipleValidationAttributesAtTheTypeLevel-Message1-RuleB", Ruleset = "RuleB")]
    public class TypeWithMultipleValidationAttributesAtTheTypeLevel
    {
    }
}
