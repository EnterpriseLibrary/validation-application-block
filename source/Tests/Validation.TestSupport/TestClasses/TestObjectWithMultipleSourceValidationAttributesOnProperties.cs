// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class TestObjectWithMultipleSourceValidationAttributesOnProperties
    {
        [MockValidator(true, MessageTemplate = "vab-only")]
        [MockValidator(true, MessageTemplate = "vab-only-RuleA", Ruleset = "RuleA")]
        [MockValidator(true, MessageTemplate = "vab-only-RuleB", Ruleset = "RuleB")]
        public string PropertyWithVABOnlyAttributes { get; set; }

        [StringLength(1, ErrorMessage = "data annotations-only")]
        public string PropertyWithDataAnnotationsAttributes { get; set; }

        [MockValidator(true, MessageTemplate = "vab-mixed")]
        [StringLength(1, ErrorMessage = "data annotations-mixed")]
        public string PropertyWithMixedAttributes { get; set; }
    }
}
