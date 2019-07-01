// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Tests.Configuration
{
    [TestClass]
    public class ConfigurationCultureInfoConverterFixture
    {
        private ConfigurationCultureInfoConverter converter = new ConfigurationCultureInfoConverter();

        [TestMethod]
        public void CanDesializeEmptyString()
        {
            var culture = (CultureInfo)converter.ConvertFromInvariantString("");
            Assert.IsNull(culture);
        }

        [TestMethod]
        public void CanDesializeNull()
        {
            var culture = (CultureInfo)converter.ConvertFromInvariantString(null);
            Assert.IsNull(culture);
        }

        [TestMethod]
        public void CanSerializeSpecificCulture()
        {
            var value = converter.ConvertToInvariantString(CultureInfo.GetCultureInfo("nl-NL"));
            Assert.AreEqual("nl-NL", value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotSerializeInvariantCulture()
        {
            converter.ConvertToInvariantString(CultureInfo.InvariantCulture);
        }
    }
}
