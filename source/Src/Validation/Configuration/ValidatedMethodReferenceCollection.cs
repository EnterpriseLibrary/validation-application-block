// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using EnterpriseLibrary.Common.Configuration;
using System.Configuration;

namespace EnterpriseLibrary.Validation.Configuration
{
    /// <summary>
    /// Represents a collection of validated methods.
    /// </summary>
    /// <seealso cref="ValidatedMethodReference"/>
    [ConfigurationCollection(typeof(ValidatedMethodReference), AddItemName = "method", ClearItemsName = "clear", RemoveItemName = "remove")]
    public class ValidatedMethodReferenceCollection : NamedElementCollection<ValidatedMethodReference>
    {
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ValidatedMethodReferenceCollection"/> class.</para>
        /// </summary>
        public ValidatedMethodReferenceCollection()
        {
            this.AddElementName = "method";
        }
    }
}
