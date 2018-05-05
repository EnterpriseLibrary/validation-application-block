// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Configuration;
using EnterpriseLibrary.Common.Configuration;
using EnterpriseLibrary.Common.Configuration.Design;

namespace EnterpriseLibrary.Validation.Configuration
{
    /// <summary>
    /// Represents the validation information for a field.
    /// </summary>
    /// <seealso cref="ValidatedTypeReference"/>
    /// <seealso cref="ValidationRulesetData"/>
    /// <seealso cref="ValidatedMemberReference"/>
    [ResourceDescription(typeof(DesignResources), "ValidatedFieldReferenceDescription")]
    [ResourceDisplayName(typeof(DesignResources), "ValidatedFieldReferenceDisplayName")]
    [NameProperty("Name", NamePropertyDisplayFormat = "Field: {0}")]
    public sealed class ValidatedFieldReference : ValidatedMemberReference
    {
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ValidatedFieldReference"/> class.</para>
        /// </summary>
        public ValidatedFieldReference()
        { }
            
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ValidatedFieldReference"/> class with a name.</para>
        /// </summary>
        /// <param name="name">The name for the instance.</param>
        public ValidatedFieldReference(string name)
            : base(name)
        { }
    }
}
