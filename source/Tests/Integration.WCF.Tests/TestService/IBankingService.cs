// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS.TestService
{
    [ServiceContract(Namespace="http://tempuri.org/BankingService")]
    [ValidationBehavior("Bank1Rules")]
    internal interface IBankingService
    {
        [OperationContract]
        [FaultContract(typeof(ValidationFault))]
        AccountSummary GetAccountSummary(CustomerInfo customer);
    }
}
