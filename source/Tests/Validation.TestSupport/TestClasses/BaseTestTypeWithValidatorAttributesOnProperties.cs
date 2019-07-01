// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class BaseTestTypeWithValidatorAttributesOnProperties
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
        [MockValidator(false, MessageTemplate = "PropertyWithMultipleAttributes-Message2")]
        public virtual object PropertyWithMultipleAttributes
        {
            get { return null; }
        }

        [IgnoreNulls]
        [ValidatorComposition(CompositionType.Or)]
        [MockValidator(false, MessageTemplate = "PropertyWithMultipleAttributesAndValidationModifier-Message1")]
        [MockValidator(false, MessageTemplate = "PropertyWithMultipleAttributesAndValidationModifier-Message2")]
        public object PropertyWithMultipleAttributesAndValidationModifier
        {
            get { return null; }
        }
    }
}
