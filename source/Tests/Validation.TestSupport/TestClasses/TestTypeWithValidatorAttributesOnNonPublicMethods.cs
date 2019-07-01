// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class TestTypeWithValidatorAttributesOnNonPublicOrStaticMethods
    {
        [MockValidator(false, MessageTemplate = "DefaultMethod")]
        String DefaultMethod()
        {
            return null;
        }

        [MockValidator(false, MessageTemplate = "InternalMethod")]
        internal int InternalMethod()
        {
            return 0;
        }

        [MockValidator(false, MessageTemplate = "ProtectedMethod")]
        [MockValidator(false, MessageTemplate = "ProtectedMethod")]
        protected virtual object ProtectedMethod()
        {
            return null;
        }

        [IgnoreNulls]
        [ValidatorComposition(CompositionType.Or)]
        [MockValidator(false, MessageTemplate = "PublicMethod")]
        [MockValidator(false, MessageTemplate = "PublicMethod")]
        public object PublicMethod()
        {
            return null;
        }

        [MockValidator(false, MessageTemplate = "StaticPublicMethod")]
        public static object StaticPublicMethod()
        {
            return null;
        }
    }
}
