// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class TestTypeWithValidatorAttributesOnSetterOnlyProperties
    {
        [MockValidator(false, MessageTemplate = "PropertyWithGetter")]
        public String PropertyWithGetter
        {
            get { return null; }
        }

        [MockValidator(false, MessageTemplate = "PropertyWithGetterAndSetter")]
        public String PropertyWithGetterAndSetter
        {
            get { return null; }
            set { }
        }

        [MockValidator(false, MessageTemplate = "PropertyWithSetter")]
        public String PropertyWithSetter
        {
            set { }
        }
    }
}
