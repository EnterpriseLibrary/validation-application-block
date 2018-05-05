// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using EnterpriseLibrary.Validation.Validators;

namespace EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    [AttributeUsage(AttributeTargets.Property
        | AttributeTargets.Field
        | AttributeTargets.Method
        | AttributeTargets.Class
        | AttributeTargets.Parameter,
        AllowMultiple = true,
        Inherited = false)]
    public class MockValidatorAttribute : ValidatorAttribute
    {
        private bool returnFailure;

        public MockValidatorAttribute(bool returnFailure)
        {
            this.returnFailure = returnFailure;
        }

        protected override Validator DoCreateValidator(Type targetType)
        {
            return new MockValidator<object>(this.returnFailure);
        }
    }
}
