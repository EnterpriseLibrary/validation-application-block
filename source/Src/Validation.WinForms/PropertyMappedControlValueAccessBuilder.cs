// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Reflection;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WinForms
{
    /// <summary>
    /// Represents a build for <see cref="PropertyMappedControlValueAccess"/> objects.
    /// </summary>
    public class PropertyMappedControlValueAccessBuilder : MemberValueAccessBuilder
    {
        /// <summary>
        /// Performs the actual creation of a <see cref="ValueAccess"/> suitable for accessing the value in <paramref name="fieldInfo"/>.
        /// </summary>
        /// <param name="fieldInfo">The <see cref="FieldInfo"/></param> representing the field for which a
        /// <see cref="ValueAccess"/> is required.
        /// <returns>The <see cref="ValueAccess"/> that allows for accessing the value in <paramref name="fieldInfo"/>.</returns>
        protected override ValueAccess DoGetFieldValueAccess(FieldInfo fieldInfo)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Performs the actual creation of a <see cref="ValueAccess"/> suitable for accessing the value in <paramref name="methodInfo"/>.
        /// </summary>
        /// <param name="methodInfo">The <see cref="MethodInfo"/></param> representing the method for which a
        /// <see cref="ValueAccess"/> is required.
        /// <returns>The <see cref="ValueAccess"/> that allows for accessing the value in <paramref name="methodInfo"/>.</returns>
        protected override ValueAccess DoGetMethodValueAccess(MethodInfo methodInfo)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Performs the actual creation of a <see cref="ValueAccess"/> suitable for accessing the value in <paramref name="propertyInfo"/>.
        /// </summary>
        /// <param name="propertyInfo">The <see cref="PropertyInfo"/></param> representing the property for which a
        /// <see cref="ValueAccess"/> is required.
        /// <returns>The <see cref="ValueAccess"/> that allows for accessing the value in <paramref name="propertyInfo"/>.</returns>
        protected override ValueAccess DoGetPropertyValueAccess(PropertyInfo propertyInfo)
        {
            return new PropertyMappedControlValueAccess(propertyInfo.Name);
        }
    }
}
