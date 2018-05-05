// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using EnterpriseLibrary.Common.Configuration.Design;
using EnterpriseLibrary.Validation.Validators;
using System.ComponentModel;
using EnterpriseLibrary.Common.Configuration.Design.Validation;

namespace EnterpriseLibrary.Validation.Configuration
{
    /// <summary>
    /// Describes a <see cref="DateTimeRangeValidator"/>.
    /// </summary>
    [ResourceDescription(typeof(DesignResources), "DateTimeRangeValidatorDataDescription")]
    [ResourceDisplayName(typeof(DesignResources), "DateTimeRangeValidatorDataDisplayName")]
    public class DateTimeRangeValidatorData : RangeValidatorData<DateTime>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeRangeValidatorData"/> class.
        /// </summary>
        public DateTimeRangeValidatorData() { Type = typeof(DateTimeRangeValidator); }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeRangeValidatorData"/> class.
        /// </summary>
        /// <param name="name">The configuration object name.</param>
        public DateTimeRangeValidatorData(string name)
            : base(name, typeof(DateTimeRangeValidator))
        { }

        /// <summary>
        /// Overridden in order to add Editor Attribute.
        /// </summary>
        [EditorAttribute(CommonDesignTime.EditorTypes.DatePickerEditor, CommonDesignTime.EditorTypes.FrameworkElement)]
        [Validation(ValidationDesignTime.Validators.RangeBoundValidator)]
        public override DateTime LowerBound
        {
            get { return base.LowerBound; }
            set { base.LowerBound = value; }
        }

        /// <summary>
        /// Overridden in order to add Editor Attribute.
        /// </summary>
        [EditorAttribute(CommonDesignTime.EditorTypes.DatePickerEditor, CommonDesignTime.EditorTypes.FrameworkElement)]
        [Validation(ValidationDesignTime.Validators.RangeBoundValidator)]
        public override DateTime UpperBound
        {
            get { return base.UpperBound; }
            set { base.UpperBound = value; }
        }

        /// <summary>
        /// Creates the <see cref="DateTimeRangeValidator"/> described by the configuration object.
        /// </summary>
        /// <param name="targetType">The type of object that will be validated by the validator.</param>
        /// <returns>The created <see cref="DateTimeRangeValidator"/>.</returns>    
        protected override Validator DoCreateValidator(Type targetType)
        {
            return new DateTimeRangeValidator(this.LowerBound,
                this.LowerBoundType,
                this.UpperBound,
                this.UpperBoundType,
                Negated);
        }

    }
}
