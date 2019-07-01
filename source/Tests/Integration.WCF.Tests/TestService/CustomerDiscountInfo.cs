// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Runtime.Serialization;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS.TestService
{
    [DataContract(Name="CustomerDiscountInfo", Namespace="http://tempuri.org/CustomerDiscountInfo")]
    internal class CustomerDiscountInfo
    {
        private string customerId;
        private double discountPercent;

        public CustomerDiscountInfo()
        {
        }

        public CustomerDiscountInfo(string customerId, double discountPercent)
        {
            this.customerId = customerId;
            this.discountPercent = discountPercent;
        }

        public string CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public double DiscountPercent
        {
            get { return discountPercent; }
            set { discountPercent = value; }
        }
    }
}
