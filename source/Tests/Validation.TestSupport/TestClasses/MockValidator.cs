// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses
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
