// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS.TestService
{
    [ServiceContract(Namespace = "http://tempuri.org/BankingService")]
    [ValidationBehavior("Bank2Rules")]
    internal interface IBanking2Service
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        AccountSummary GetAccountSummary(CustomerInfo customer);
    }
}
