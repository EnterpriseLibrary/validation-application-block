// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class BaseTestTypeWithValidatorAttributesOnMethods
    {
        public String MethodWithNoAttributes()
        {
            return null;
        }

        [MockValidator(false, MessageTemplate = "MethodWithSingleAttribute-Message1")]
        public int MethodWithSingleAttribute()
        {
            return 0;
        }

        [MockValidator(false, MessageTemplate = "MethodWithMultipleAttributes-Message1")]
        [MockValidator(false, MessageTemplate = "MethodWithMultipleAttributes-Message2")]
        public virtual object MethodWithMultipleAttributes()
        {
            return null;
        }

        [IgnoreNulls]
        [ValidatorComposition(CompositionType.Or)]
        [MockValidator(false, MessageTemplate = "MethodWithMultipleAttributesAndValidationModifier-Message1")]
        [MockValidator(false, MessageTemplate = "MethodWithMultipleAttributesAndValidationModifier-Message2")]
        public object MethodWithMultipleAttributesAndValidationModifier()
        {
            return null;
        }
    }
}
