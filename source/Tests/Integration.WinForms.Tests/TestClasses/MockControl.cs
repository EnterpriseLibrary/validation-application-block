// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace EnterpriseLibrary.Validation.Integration.WinForms.Tests.TestClasses
{
    public class MockControl : Control
    {
        private int intControlProperty;
        public int IntControlProperty
        {
            get { return intControlProperty; }
            set { intControlProperty = value; }
        }

        private string stringControlProperty;
        public string StringControlProperty
        {
            get { return stringControlProperty; }
            set { stringControlProperty = value; }
        }

        public bool FireValidating()
        {
            CancelEventArgs cancelEventArgs = new CancelEventArgs();
            this.OnValidating(cancelEventArgs);

            return cancelEventArgs.Cancel;
        }
    }
}
