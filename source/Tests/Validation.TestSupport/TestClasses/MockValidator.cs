// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using EnterpriseLibrary.Common.Configuration;
using EnterpriseLibrary.Validation.TestSupport.Configuration;

namespace EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    [ConfigurationElementType(typeof(MockValidatorData))]
    public class MockValidator : MockValidator<object>
    {
        public MockValidator(bool returnFailure)
            : base(returnFailure)
        { }

        public MockValidator(bool returnFailure, string messageTemplate)
            : base(returnFailure, messageTemplate)
        { }

        public MockValidator(Exception e)
            : base(e)
        {
        }
    }
}
