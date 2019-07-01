// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    [ConfigurationElementType(typeof(DomainValidatorData))]
    public class MockDomainValidator : MockValidator<object>
    {
        public MockDomainValidator(NameValueCollection attributes)
            : base(GetReturnFailure(attributes))
        { }

        private static bool GetReturnFailure(NameValueCollection attributes)
        {
            string returnFailureString = attributes.Get("returnFailure");
            if (returnFailureString != null)
            {
                return bool.Parse(returnFailureString);
            }
            return false;
        }
    }
}
