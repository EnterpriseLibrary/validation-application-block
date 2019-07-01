// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class DerivedTestTypeWithValidatorAttributesOnMethods : BaseTestTypeWithValidatorAttributesOnMethods
    {
        [MockValidator(false, MessageTemplate = "MethodWithMultipleAttributesOverride-Message1")]
        public override object MethodWithMultipleAttributes()
        {
            return base.MethodWithMultipleAttributes();
        }
    }
}
