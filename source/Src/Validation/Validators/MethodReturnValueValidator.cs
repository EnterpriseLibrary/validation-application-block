// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseLibrary.Validation.Validators
{
    /// <summary>
    /// Validates the return value of a method without parameters using a configured validator.
    /// </summary>
    /// <typeparam name="T">The type for which validation on a method is to be performed.</typeparam>
    public class MethodReturnValueValidator<T> : MemberAccessValidator<T>
    {
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="MethodReturnValueValidator{T}"/> class.</para>
        /// </summary>
        /// <param name="methodName">The name of the method to validate.</param>
        /// <param name="methodValueValidator">The validator for the value of the method.</param>
        public MethodReturnValueValidator(string methodName, Validator methodValueValidator)
            : base(GetMethodValueAccess(methodName), methodValueValidator)
        { }

        private static ValueAccess GetMethodValueAccess(string methodName)
        {
            return new MethodValueAccess(ValidationReflectionHelper.GetMethod(typeof(T), methodName, true));
        }
    }
}
