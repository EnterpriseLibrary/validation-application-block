// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using EnterpriseLibrary.Common.Configuration;
using System.Configuration;

namespace EnterpriseLibrary.Validation.Configuration
{
    /// <summary>
    /// Represents a collection of validator configuration objects.
    /// </summary>
    /// <seealso cref="ValidatorData"/>
    [ConfigurationCollection(typeof(ValidatorData), AddItemName = "validator", ClearItemsName="clear", RemoveItemName="remove")]
    public class ValidatorDataCollection : NameTypeConfigurationElementCollection<ValidatorData, CustomValidatorData>
    {
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ValidatorDataCollection"/> class.</para>
        /// </summary>
        public ValidatorDataCollection()
        {
            this.AddElementName = "validator";
        }
    }
}
