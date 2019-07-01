// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class BaseTestTypeWithValidatorAttributesOnFields
    {
        public String FieldWithNoAttributes = null;

        [MockValidator(false, MessageTemplate = "FieldWithSingleAttribute-Message1")]
        public int FieldWithSingleAttribute = 0;

        [MockValidator(false, MessageTemplate = "FieldWithMultipleAttributes-Message1")]
        [MockValidator(false, MessageTemplate = "FieldWithMultipleAttributes-Message2")]
        public object FieldWithMultipleAttributes = null;

        [IgnoreNulls]
        [ValidatorComposition(CompositionType.Or)]
        [MockValidator(false, MessageTemplate = "FieldWithMultipleAttributesAndValidationModifier-Message1")]
        [MockValidator(false, MessageTemplate = "FieldWithMultipleAttributesAndValidationModifier-Message2")]
        public object FieldWithMultipleAttributesAndValidationModifier = null;
    }
}
