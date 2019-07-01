// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class DerivedTestDomainObject : BaseTestDomainObject
    {
        public const string Derived2Value = "derived2";
        public const string Derived3Value = "derived3";

        public new string Field3 = Derived3Value;

        public override string Property2
        {
            get { return Derived2Value; }
        }

        public new string Property3
        {
            get { return Derived3Value; }
        }

        public override string Method2()
        {
            return Derived2Value;
        }

        public new string Method3()
        {
            return Derived3Value;
        }
    }
}
