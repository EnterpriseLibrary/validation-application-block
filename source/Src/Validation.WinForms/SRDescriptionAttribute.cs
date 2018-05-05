// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.ComponentModel;
using EnterpriseLibrary.Validation.Integration.WinForms.Properties;

namespace EnterpriseLibrary.Validation.Integration.WinForms
{
    internal sealed class SRDescriptionAttribute : DescriptionAttribute
    {
        public SRDescriptionAttribute(string resourceName)
            : base(GetResource(resourceName))
        { }

        private static string GetResource(string resourceName)
        {
            string resource = Resources.ResourceManager.GetString(resourceName);
            return resource != null ? resource : resourceName;
        }
    }
}
