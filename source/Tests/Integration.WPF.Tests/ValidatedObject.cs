// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EnterpriseLibrary.Validation.Validators;

namespace EnterpriseLibrary.Validation.Integration.WPF.Tests
{
    public class ValidatedObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [RangeValidator(10, RangeBoundaryType.Inclusive, 20, RangeBoundaryType.Inclusive, MessageTemplate = "invalid int")]
        public int ValidatedIntProperty { get; set; }

        [RegexValidator(@"^a*$", MessageTemplate = "invalid string")]
        public string ValidatedStringProperty { get; set; }

        public int NonValidatedProperty { get; set; }

        [RegexValidator(@"^a*$", MessageTemplate = "invalid string: vab")]
        [StringLength(2, ErrorMessage = "invalid string: data annotations")]
        public string MultipleSourceValidatedStringProperty { get; set; }

        [RegexValidator(@"^a*$", MessageTemplate = "invalid string default")]
        [RegexValidator(@"^a*$", MessageTemplate = "invalid string ruleset", Ruleset = "A")]
        public string MultipleRulesetValidatedStringProperty { get; set; }

        private string twoWayValidatedStringProperty;

        //[StringLengthValidator(1, MessageTemplate = "String must be one character")]
        [StringLength(1, ErrorMessage = "String must be one character")]
        public string TwoWayValidatedStringProperty
        {
            get { return twoWayValidatedStringProperty; }
            set
            {
                twoWayValidatedStringProperty = value;
                OnPropertyChanged("TwoWayValidatedStringProperty");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changedEvent = PropertyChanged;
            if (changedEvent != null)
            {
                changedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
