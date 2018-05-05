// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using EnterpriseLibrary.Validation.Validators;

namespace EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class MockClassWithValidatorAttributesOnProperties
    {
        public String PropertyWithNoAttributes
        {
            get { return null; }
        }

        [MockValidator(false, MessageTemplate = "PropertyWithSingleAttribute-Message1")]
        public int PropertyWithSingleAttribute
        {
            get { return 0; }
        }

        [MockValidator(false, MessageTemplate = "PropertyWithMultipleAttributes-Message1")]
        [MockValidator(false, MessageTemplate = "PropertyWithMultipleAttributes-Message2", Ruleset="RuleA")]
        public string PropertyWithMultipleAttributes
        {
            get { return null; }
        }
    }
}
