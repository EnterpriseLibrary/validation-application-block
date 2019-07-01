// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.ServiceModel;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS.TestService
{
    [ServiceContract(Namespace = "http://tempuri.org/Banking4Service")]
    interface IBanking4Service
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [ValidationBehavior("Bank1Rules")]
        AccountSummary GetAccountSummary(CustomerInfo customer);

        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        [ValidationBehavior("Bank2Rules")]
        AccountSummary GetAccountSummary2(CustomerInfo customer);
    }
}
