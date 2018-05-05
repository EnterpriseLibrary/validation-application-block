// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseLibrary.Validation.Configuration
{
    internal static class ValidationDesignTime
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public static class ViewModelTypeNames
        {
            public const string ValidationSectionViewModel = "EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.ValidationSectionViewModel, EnterpriseLibrary.Configuration.DesignTime";

            public const string ValidatedTypeReferenceViewModel = "EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.ValidatedTypeReferenceViewModel, EnterpriseLibrary.Configuration.DesignTime";

            public const string ValidatorDataViewModel = "EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.ValidatorDataViewModel, EnterpriseLibrary.Configuration.DesignTime";
            
            public const string ValidationRulesetDataViewModel = "EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.ValidationRulesetDataViewModel, EnterpriseLibrary.Configuration.DesignTime";

            public const string ValidatedMemberReferenceViewModel = "EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.ValidatedMemberReferenceViewModel, EnterpriseLibrary.Configuration.DesignTime";

            public const string DomainConfigurationElementViewModel =
                "EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.DomainConfigurationElementViewModel, EnterpriseLibrary.Configuration.DesignTime";

            public const string RangeValidatorCultureProperty = "EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.RangeValidatorCultureProperty, EnterpriseLibrary.Configuration.DesignTime";
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public static class CommandTypeNames
        {
            public const string SelectValidatedTypeReferenceMembersCommand = "EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.SelectValidatedTypeReferenceMembersCommand, EnterpriseLibrary.Configuration.DesignTime";

            public const string AddValidatedTypeCommand = "EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.ValidationTypeReferenceAddCommand, EnterpriseLibrary.Configuration.DesignTime";
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public static class Validators
        {
            public const string NameValueCollectionValidator = "EnterpriseLibrary.Configuration.Design.Validation.NameValueCollectionValidator, EnterpriseLibrary.Configuration.DesignTime";

            public const string RangeBoundValidator = "EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.RangeBoundValidator, EnterpriseLibrary.Configuration.DesignTime";
        }
    }
}
