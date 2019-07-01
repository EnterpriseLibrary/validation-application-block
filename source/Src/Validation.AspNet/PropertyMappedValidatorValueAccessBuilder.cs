// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Reflection;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet
{
    internal class PropertyMappedValidatorValueAccessBuilder : MemberValueAccessBuilder
    {
        protected override ValueAccess DoGetFieldValueAccess(FieldInfo fieldInfo)
        {
            throw new NotSupportedException();
        }

        protected override ValueAccess DoGetMethodValueAccess(MethodInfo methodInfo)
        {
            throw new NotSupportedException();
        }

        protected override ValueAccess DoGetPropertyValueAccess(PropertyInfo propertyInfo)
        {
            return new PropertyMappedValidatorValueAccess(propertyInfo.Name);
        }
    }
}
