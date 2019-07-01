// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Validators_NotNullValidator=
    Microsoft.Practices.EnterpriseLibrary.Validation.Validators.NotNullValidator;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS.TestService
{
    [ServiceContract(Namespace = "http://TestService")]
    [ValidationBehavior]
    internal interface ITestService
    {
        [OperationContract]
        string ToUpperCase(string input);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        AddCustomerResponse AddCustomer(AddCustomerRequest request);

        // Not having a FaultContract on this one is deliberate,
        // so that we can test that we get the right exceptions when
        // there isn't one.
        [OperationContract]
        void PlaceOrder(string customerId, TaxInfo taxInfo, ItemInfo itemInfo, CustomerDiscountInfo discountInfo);

        [OperationContract(Name="LookupItem")]
        [FaultContract(typeof(ValidationFault))]
        void LookupItem(string itemId, out ItemInfo info);

        [OperationContract(Name = "ReturnItem")]
        [FaultContract(typeof(ValidationFault))]
        ItemInfo LookupItem(string itemId);

        [OperationContract(Name = "ShouldValidateParameters")]
        [FaultContract(typeof(ValidationFault))]
        void LookupById(
            [RangeValidator(5, RangeBoundaryType.Inclusive, 100, RangeBoundaryType.Exclusive)] 
            int id,
            [NotNullValidator]
            [StringLengthValidator(4, RangeBoundaryType.Inclusive, 32, RangeBoundaryType.Inclusive)]
            string customerName
            );
    }
}
