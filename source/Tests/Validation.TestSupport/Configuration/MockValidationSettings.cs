// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using EnterpriseLibrary.Common.Configuration;
using EnterpriseLibrary.Validation.Configuration;
using System.Configuration;

namespace EnterpriseLibrary.Validation.TestSupport.Configuration
{
    public class MockValidationSettings : SerializableConfigurationSection
    {
        private const string ValidatorsPropertyName = "";
        [ConfigurationProperty(ValidatorsPropertyName, IsDefaultCollection = true)]
        public ValidatorDataCollection Validators
        {
            get { return (ValidatorDataCollection)this[ValidatorsPropertyName]; }
        }
    }
}
