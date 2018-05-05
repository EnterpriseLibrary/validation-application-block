// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using EnterpriseLibrary.Validation.Integration.WinForms.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Integration.WinForms.Tests
{
    [TestClass]
    public class SupportingTypesFixture
    {
        
        [TestMethod]
        public void TypeConverterRejectsNull()
        {
            Assert.IsFalse(new RequiredIdentifierConverter().IsValid(null));
        }

        [TestMethod]
        public void TypeConverterRejectsEmpty()
        {
            Assert.IsFalse(new RequiredIdentifierConverter().IsValid(string.Empty));
        }

        [TestMethod]
        public void TypeConverterRejectsNonString()
        {
            Assert.IsFalse(new RequiredIdentifierConverter().IsValid(5));
        }

        [TestMethod]
        public void TypeConverterAcceptsIdentifier()
        {
            Assert.IsTrue(new RequiredIdentifierConverter().IsValid("Property"));
        }
    }
}
