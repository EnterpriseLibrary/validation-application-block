// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Configuration;
using EnterpriseLibrary.Common.Configuration;
using EnterpriseLibrary.Common.Configuration.Design;

namespace EnterpriseLibrary.Validation.Configuration
{
    /// <summary>
    /// Represents the validation information for a member of a type.
    /// </summary>
    /// <seealso cref="ValidationRulesetData"/>
    /// <seealso cref="ValidatedMemberReference"/>
    [ViewModel(ValidationDesignTime.ViewModelTypeNames.ValidatedMemberReferenceViewModel)]
    public abstract class ValidatedMemberReference : NamedConfigurationElement
    {
        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ValidatedMemberReference"/> class.</para>
        /// </summary>
        protected ValidatedMemberReference()
        { }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ValidatedMemberReference"/> class with a name.</para>
        /// </summary>
        /// <param name="name">The name for the instance.</param>
        protected ValidatedMemberReference(string name)
            : base(name)
        { }

        private const string ValidatorsPropertyName = "";
        /// <summary>
        /// Gets the collection of validators configured for the member.
        /// </summary>
        [ConfigurationProperty(ValidatorsPropertyName, IsDefaultCollection = true)]
        [ResourceDescription(typeof(DesignResources), "ValidatedMemberReferenceValidatorsDescription")]
        [ResourceDisplayName(typeof(DesignResources), "ValidatedMemberReferenceValidatorsDisplayName")]
        [PromoteCommands]
        public ValidatorDataCollection Validators
        {
            get { return (ValidatorDataCollection)this[ValidatorsPropertyName]; }
        }
    }
}
