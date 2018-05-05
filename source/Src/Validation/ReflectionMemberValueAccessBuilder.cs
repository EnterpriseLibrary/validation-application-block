// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Reflection;
using EnterpriseLibrary.Validation.Validators;

namespace EnterpriseLibrary.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public class ReflectionMemberValueAccessBuilder : MemberValueAccessBuilder
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldInfo"></param>
        /// <returns></returns>
        protected override ValueAccess DoGetFieldValueAccess(FieldInfo fieldInfo)
        {
            return new FieldValueAccess(fieldInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodInfo"></param>
        /// <returns></returns>
        protected override ValueAccess DoGetMethodValueAccess(MethodInfo methodInfo)
        {
            return new MethodValueAccess(methodInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        protected override ValueAccess DoGetPropertyValueAccess(PropertyInfo propertyInfo)
        {
            return new PropertyValueAccess(propertyInfo);
        }
    }
}
