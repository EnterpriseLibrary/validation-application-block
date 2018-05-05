// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using EnterpriseLibrary.Validation.Properties;
using EnterpriseLibrary.Validation.Validators;

namespace EnterpriseLibrary.Validation
{
    /// <summary>
    /// Helper for reflection access.
    /// </summary>
    public static partial class ValidationReflectionHelper
    {
        internal static PropertyInfo GetProperty(Type type, string propertyName, bool throwIfInvalid)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException("propertyName");
            }

            PropertyInfo propertyInfo = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);

            if (!IsValidProperty(propertyInfo))
            {
                if (throwIfInvalid)
                {
                    throw new ArgumentException(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            Resources.ExceptionInvalidProperty,
                            propertyName,
                            type.FullName));
                }
                else
                {
                    return null;
                }
            }

            return propertyInfo;
        }

        internal static bool IsValidProperty(PropertyInfo propertyInfo)
        {
            return null != propertyInfo                // exists
                    && propertyInfo.CanRead            // and it's readable
                    && propertyInfo.GetIndexParameters().Length == 0;    // and it's not an indexer
        }

        internal static FieldInfo GetField(Type type, string fieldName, bool throwIfInvalid)
        {
            if (string.IsNullOrEmpty(fieldName))
            {
                throw new ArgumentNullException("fieldName");
            }

            FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);

            if (!IsValidField(fieldInfo))
            {
                if (throwIfInvalid)
                {
                    throw new ArgumentException(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            Resources.ExceptionInvalidField,
                            fieldName,
                            type.FullName));
                }
                else
                {
                    return null;
                }
            }

            return fieldInfo;
        }

        internal static bool IsValidField(FieldInfo fieldInfo)
        {
            return null != fieldInfo;
        }

        internal static MethodInfo GetMethod(Type type, string methodName, bool throwIfInvalid)
        {
            if (string.IsNullOrEmpty(methodName))
            {
                throw new ArgumentNullException("methodName");
            }

            MethodInfo methodInfo = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null);

            if (!IsValidMethod(methodInfo))
            {
                if (throwIfInvalid)
                {
                    throw new ArgumentException(
                        string.Format(
                            CultureInfo.CurrentCulture,
                            Resources.ExceptionInvalidMethod,
                            methodName,
                            type.FullName));
                }
                else
                {
                    return null;
                }
            }

            return methodInfo;
        }

        internal static bool IsValidMethod(MethodInfo methodInfo)
        {
            return null != methodInfo
                && typeof(void) != methodInfo.ReturnType
                && methodInfo.GetParameters().Length == 0;
        }

        internal static T ExtractValidationAttribute<T>(MemberInfo attributeProvider, string ruleset)
            where T : BaseValidationAttribute
        {
            if (attributeProvider != null)
            {
                foreach (T attribute in GetCustomAttributes(attributeProvider, typeof(T), false))
                {
                    if (ruleset.Equals(attribute.Ruleset))
                    {
                        return attribute;
                    }
                }
            }

            return null;
        }

        internal static T ExtractValidationAttribute<T>(ParameterInfo attributeProvider, string ruleset)
            where T : BaseValidationAttribute
        {
            if (attributeProvider != null)
            {
                foreach (T attribute in attributeProvider.GetCustomAttributes(typeof(T), false))
                {
                    if (ruleset.Equals(attribute.Ruleset))
                    {
                        return attribute;
                    }
                }
            }

            return null;
        }

        private static bool MatchMethodBase(MethodBase mb, Type[] parameterTypes)
        {
            ParameterInfo[] parameters = mb.GetParameters();

            if (parameters.Length != parameterTypes.Length)
            {
                return false;
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].ParameterType != parameterTypes[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
