// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class DerivedTestTypeWithValidatorAttributesOnNewProperties : BaseTestTypeWithValidatorAttributesOnProperties
    {
        [MockValidator(false, MessageTemplate = "PropertyWithMultipleAttributesNew-Message1")]
        public new object PropertyWithMultipleAttributes
        {
            get
            {
                return base.PropertyWithMultipleAttributes;
            }
        }
    }
}
