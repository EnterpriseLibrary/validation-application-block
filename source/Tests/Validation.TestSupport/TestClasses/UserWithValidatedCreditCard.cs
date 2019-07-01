// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class UserWithValidatedCreditCard
    {
        public string Name { get; set; }

        [CreditCardNumberValidator]
        public string CreditCardNumber { get; set; }
    }
}
