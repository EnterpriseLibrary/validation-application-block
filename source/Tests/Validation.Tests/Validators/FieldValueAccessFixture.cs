// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Reflection;
using EnterpriseLibrary.Validation.Properties;
using EnterpriseLibrary.Validation.TestSupport;
using EnterpriseLibrary.Validation.TestSupport.TestClasses;
using EnterpriseLibrary.Validation.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Tests
{
    [TestClass]
    public class FieldValueAccessFixture
    {
        [TestMethod]
        public void CanGetValueFromFieldForInstanceOfDeclaringClass()
        {
            FieldInfo fieldInfo = typeof(BaseTestDomainObject).GetField("Field1");
            ValueAccess valueAccess = new FieldValueAccess(fieldInfo);
            BaseTestDomainObject domainObject = new BaseTestDomainObject();

            object value;
            string valueAccessRetrievalFailure;
            bool status = valueAccess.GetValue(domainObject, out value, out valueAccessRetrievalFailure);

            Assert.IsTrue(status);
            Assert.AreEqual(BaseTestDomainObject.Base1Value, value);
        }

        [TestMethod]
        public void CanGetValueFromFieldForInstanceOfDerivedClass()
        {
            FieldInfo fieldInfo = typeof(BaseTestDomainObject).GetField("Field1");
            ValueAccess valueAccess = new FieldValueAccess(fieldInfo);
            BaseTestDomainObject domainObject = new DerivedTestDomainObject();

            object value;
            string valueAccessRetrievalFailure;
            bool status = valueAccess.GetValue(domainObject, out value, out valueAccessRetrievalFailure);

            Assert.IsTrue(status);
            Assert.AreEqual(BaseTestDomainObject.Base1Value, value);
        }

        [TestMethod]
        public void RetrievalOfValueForInstanceOfDerivedTypeThroughBaseAliasedFieldReturnsValueFromInheritedField()
        {
            FieldInfo fieldInfo = typeof(BaseTestDomainObject).GetField("Field3");
            ValueAccess valueAccess = new FieldValueAccess(fieldInfo);
            BaseTestDomainObject domainObject = new DerivedTestDomainObject();

            object value;
            string valueAccessRetrievalFailure;
            bool status = valueAccess.GetValue(domainObject, out value, out valueAccessRetrievalFailure);

            Assert.IsTrue(status);
            Assert.AreEqual(BaseTestDomainObject.Base3Value, value);
        }

        [TestMethod]
        public void RetrievalOfValueForInstanceOfDerivedTypeThroughNewAliasedFieldReturnsValueFromNewField()
        {
            FieldInfo fieldInfo = typeof(DerivedTestDomainObject).GetField("Field3");
            ValueAccess valueAccess = new FieldValueAccess(fieldInfo);
            BaseTestDomainObject domainObject = new DerivedTestDomainObject();

            object value;
            string valueAccessRetrievalFailure;
            bool status = valueAccess.GetValue(domainObject, out value, out valueAccessRetrievalFailure);

            Assert.IsTrue(status);
            Assert.AreEqual(DerivedTestDomainObject.Derived3Value, value);
        }

        [TestMethod]
        public void RetrievalOfValueForInstanceOfNonRelatedTypeReturnsFailure()
        {
            FieldInfo fieldInfo = typeof(BaseTestDomainObject).GetField("Field1");
            ValueAccess valueAccess = new FieldValueAccess(fieldInfo);

            object value;
            string valueAccessRetrievalFailure;
            bool status = valueAccess.GetValue("a string", out value, out valueAccessRetrievalFailure);

            Assert.IsFalse(status);
            Assert.IsNull(value);
            Assert.IsTrue(TemplateStringTester.IsMatch(Resources.ErrorValueAccessInvalidType, valueAccessRetrievalFailure));
        }

        [TestMethod]
        public void RetrievalOfValueForNullReferenceReturnsFailure()
        {
            FieldInfo fieldInfo = typeof(BaseTestDomainObject).GetField("Field1");
            ValueAccess valueAccess = new FieldValueAccess(fieldInfo);

            object value;
            string valueAccessRetrievalFailure;
            bool status = valueAccess.GetValue(null, out value, out valueAccessRetrievalFailure);

            Assert.IsFalse(status);
            Assert.IsNull(value);
            Assert.IsTrue(TemplateStringTester.IsMatch(Resources.ErrorValueAccessNull, valueAccessRetrievalFailure));
        }

        [TestMethod]
        public void CanGetKeyFromValueAccess()
        {
            FieldInfo fieldInfo = typeof(BaseTestDomainObject).GetField("Field3");
            ValueAccess valueAccess = new FieldValueAccess(fieldInfo);

            Assert.AreEqual("Field3", valueAccess.Key);
        }
    }
}
