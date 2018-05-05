// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS.TestService
{
    class TestServiceImplementation : ITestService
    {
        public string ToUpperCase(string input)
        {
            return input.ToUpperInvariant();
        }

        public AddCustomerResponse AddCustomer(AddCustomerRequest request)
        {
            AddCustomerResponse response = new AddCustomerResponse();
            response.FullName = string.Format("{0} {1}", request.FirstName, request.LastName);
            response.Added = true;
            return response;
        }

        public void PlaceOrder(
            string customerId, TaxInfo taxInfo, ItemInfo itemInfo, CustomerDiscountInfo discountInfo)
        {
            
        }

        public void LookupItem(string itemId, out ItemInfo info)
        {
            info = new ItemInfo(itemId, "This is a dummy", 42);
        }


        public ItemInfo LookupItem(string itemId)
        {
            return new ItemInfo(itemId, string.Format("Dummy item {0}", itemId), 44);
        }


        public void LookupById(int id, string customerName)
        {
            
        }
    }
}
