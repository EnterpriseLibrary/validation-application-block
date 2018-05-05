// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using EnterpriseLibrary.Validation.Validators;

namespace EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CreditCardNumberValidatorAttribute : ValueValidatorAttribute
    {
        protected override Validator DoCreateValidator(Type targetType)
        {
            return new CreditCardNumberValidator();
        }
    }
}
