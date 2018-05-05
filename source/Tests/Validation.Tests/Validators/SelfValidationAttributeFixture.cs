// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using EnterpriseLibrary.Validation.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Tests.Validators
{
    [TestClass]
    public class SelfValidationAttributeFixture
    {
        [TestMethod]
        public void CanSpecifyRulesetNameForAttribute()
        {
            SelfValidationAttribute attribute = new SelfValidationAttribute();
            attribute.Ruleset = "ruleset";

            Assert.AreEqual("ruleset", attribute.Ruleset);
        }
    }
}
