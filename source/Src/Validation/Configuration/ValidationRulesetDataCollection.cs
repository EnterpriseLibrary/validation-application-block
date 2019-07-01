// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Configuration
{
    /// <summary>
    /// Represents a collection of validated properties.
    /// </summary>
    /// <seealso cref="ValidationRulesetData"/>
    [ConfigurationCollection(typeof(ValidationRulesetData), AddItemName = "ruleset", ClearItemsName = "clear", RemoveItemName = "remove")]
    public class ValidationRulesetDataCollection : NamedElementCollection<ValidationRulesetData>
    {
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ValidationRulesetDataCollection"/> class.</para>
        /// </summary>
        public ValidationRulesetDataCollection()
        {
            this.AddElementName = "ruleset";
        }
    }
}
