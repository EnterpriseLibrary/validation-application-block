// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;

namespace Microsoft.Practices.EnterpriseLibrary.Validation
{
    ///<summary>
    /// A CompositeValidatorFactory that produces validators based on reflection.
    ///</summary>
    public class AttributeValidatorFactory : ValidatorFactory
    {
        ///<summary>
        /// Initializes an AttributeValidatorFactory
        ///</summary>
        public AttributeValidatorFactory()
        { }

        /// <summary>
        /// Creates the validator for the specified target and ruleset.
        /// </summary>
        /// <param name="targetType">The <see cref="Type"/>to validate.</param>
        /// <param name="ruleset">The ruleset to use when validating</param>
        /// <param name="mainValidatorFactory">Factory to use when building nested validators.</param>
        /// <returns>A <see cref="Validator"/></returns>
        protected internal override Validator InnerCreateValidator(
            Type targetType, 
            string ruleset, 
            ValidatorFactory mainValidatorFactory)
        {
            MetadataValidatorBuilder builder =
                new MetadataValidatorBuilder(MemberAccessValidatorBuilderFactory.Default, mainValidatorFactory);

            return builder.CreateValidator(targetType, ruleset);
        }
    }
}
