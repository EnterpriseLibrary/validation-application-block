// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS
{
    /// <summary>
    /// Summary description for ValidationDetailFixture
    /// </summary>
    [TestClass]
    public class ValidationDetailFixture
    {
        [TestMethod]
        public void ShouldDefaultConstructToValid()
        {
            ValidationFault fault = new ValidationFault();
            Assert.IsTrue(fault.IsValid);
            Assert.AreEqual(0, fault.Details.Count);
        }

        [TestMethod]
        public void ShouldBeInvalidAfterAddingDetail()
        {
            ValidationFault fault = new ValidationFault();
            fault.Add(new ValidationDetail("message", "key", "tag"));
            Assert.IsFalse(fault.IsValid);
            Assert.AreEqual(1, fault.Details.Count);
        }

        [TestMethod]
        public void ShouldBeInvalidWhenConstructedWithDetails()
        {
            ValidationDetail[] details = {
                                             new ValidationDetail("m1", "k1", "t1"),
                                             new ValidationDetail("m2", "k2", "t2")
                                         };

            ValidationFault fault = new ValidationFault(details);
            Assert.IsFalse(fault.IsValid);
            Assert.AreEqual(2, fault.Details.Count);
        }
    }
}
