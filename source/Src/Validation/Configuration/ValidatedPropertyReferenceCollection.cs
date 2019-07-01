// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Configuration
{
    /// <summary>
    /// Represents a collection of validated properties.
    /// </summary>
    /// <seealso cref="ValidatedPropertyReference"/>
    [ConfigurationCollection(typeof(ValidatedPropertyReference), AddItemName = "property", ClearItemsName = "clear", RemoveItemName = "remove")]
    public class ValidatedPropertyReferenceCollection : NamedElementCollection<ValidatedPropertyReference>
    {
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ValidatedPropertyReferenceCollection"/> class.</para>
        /// </summary>
        public ValidatedPropertyReferenceCollection()
        {
            this.AddElementName = "property";
        }
    }
}
