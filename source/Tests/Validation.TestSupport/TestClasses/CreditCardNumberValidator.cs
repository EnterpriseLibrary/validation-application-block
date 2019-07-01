// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class CreditCardNumberValidator : RegexValidator
    {
        private const string CreditCardRegex = @"^\d{4}([-\s]?\d{4}){3}$";

        public CreditCardNumberValidator()
            : base(CreditCardRegex)
        {
            
        }

        protected override string DefaultNonNegatedMessageTemplate
        {
            get
            {
                return "Invalid credit card number";
            }
        }
    }
}
