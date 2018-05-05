// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class TestObjectWithFailingAttributesOnProperties
    {
        private string failingProperty1;
        [MockValidator(true, MessageTemplate = "message1")]
        [MockValidator(true, MessageTemplate = "message1-RuleA", Ruleset = "RuleA")]
        [MockValidator(true, MessageTemplate = "message1-RuleB", Ruleset = "RuleB")]
        public string FailingProperty1
        {
            get { return failingProperty1; }
            set { failingProperty1 = value; }
        }
    
        [MockValidator(true, MessageTemplate = "message2")]
        public string FailingProperty2
        {
            get { return "failing2"; }
        }

        [MockValidator(true, MessageTemplate = "non readable")]
        public string NonReadableProperty
        {
            set { }
        }

        public string PropertyWithoutAttributes
        {
            get { return "withoutAttributes"; }
        }
    }
}
