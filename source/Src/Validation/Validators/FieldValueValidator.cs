// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Validators
{
    /// <summary>
    /// Validates the value of a field using a configured validator.
    /// </summary>
    /// <typeparam name="T">The type for which validation on a member is to be performed.</typeparam>
    public class FieldValueValidator<T> : MemberAccessValidator<T>
    {
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="FieldValueValidator{T}"/> class.</para>
        /// </summary>
        /// <param name="fieldName">The name of the field to validate.</param>
        /// <param name="fieldValueValidator">The validator for the value of the field.</param>
        public FieldValueValidator(string fieldName, Validator fieldValueValidator)
            : base(GetFieldValueAccess(fieldName), fieldValueValidator)
        {
        }

        private static ValueAccess GetFieldValueAccess(string fieldName)
        {
            return new FieldValueAccess(ValidationReflectionHelper.GetField(typeof(T), fieldName, true));
        }
    }
}
