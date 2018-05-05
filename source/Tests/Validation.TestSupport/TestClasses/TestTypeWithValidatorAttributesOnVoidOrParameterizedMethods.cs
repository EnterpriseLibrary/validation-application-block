// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class TestTypeWithValidatorAttributesOnVoidOrParameterizedMethods
    {
        [MockValidator(false, MessageTemplate = "VoidMethodWithoutParameters")]
        public void VoidMethodWithoutParameters()
        {
        }

        [MockValidator(false, MessageTemplate = "VoidMethodWithParameters")]
        public void VoidMethodWithParameters(object param1)
        {
        }

        [MockValidator(false, MessageTemplate = "VoidMethodWithParamParameters")]
        public void VoidMethodWithParamParameters(params object[] param1)
        {
        }

        [MockValidator(false, MessageTemplate = "NonVoidMethodWithoutParameters")]
        public object NonVoidMethodWithoutParameters()
        {
            return null;
        }

        [MockValidator(false, MessageTemplate = "NonVoidMethodWithParameters")]
        public object NonVoidMethodWithParameters(object param1)
        {
            return null;
        }

        [MockValidator(false, MessageTemplate = "NonVoidMethodWithParamParameters")]
        public object NonVoidMethodWithParamParameters(params object[] param1)
        {
            return null;
        }
    }
}
