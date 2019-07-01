// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Microsoft.Practices.EnterpriseLibrary.Validation
{
    /// <summary>
    /// 
    /// </summary>
    public class ValueAccessValidatorBuilder : CompositeValidatorBuilder
    {
        private ValueAccess valueAccess;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueAccess"></param>
        /// <param name="validatedElement"></param>
        public ValueAccessValidatorBuilder(ValueAccess valueAccess, IValidatedElement validatedElement)
            : base(validatedElement)
        {
            this.valueAccess = valueAccess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override Validator DoGetValidator()
        {
            return new ValueAccessValidator(this.valueAccess, base.DoGetValidator());
        }

        #region test only properties

        /// <summary>
        /// 
        /// </summary>
        public ValueAccess ValueAccess
        {
            get { return this.valueAccess; }
        }

        #endregion
    }
}
