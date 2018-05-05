// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Windows.Forms;

namespace EnterpriseLibrary.Validation.Integration.WinForms
{
    /// <summary>
    /// Contains the data for the <see cref="ValidationProvider.ValidationPerformed"/> event.
    /// </summary>
    /// <seealso cref="ValidationProvider.ValidationPerformed"/>
    public class ValidationPerformedEventArgs : EventArgs
    {
        private Control validatedControl;
        private ValidationResults validationResults;

        internal ValidationPerformedEventArgs(Control validatedControl, ValidationResults validationResults)
        {
            this.validatedControl = validatedControl;
            this.validationResults = validationResults;
        }

        /// <summary>
        /// Gets the control that was validated.
        /// </summary>
        public Control ValidatedControl
        {
            get { return validatedControl; }
        }

        /// <summary>
        /// Gets the results of the validation for the control.
        /// </summary>
        public ValidationResults ValidationResults
        {
            get { return validationResults; }
        }
    }
}
