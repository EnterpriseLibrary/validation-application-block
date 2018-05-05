// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS.TestService
{
    [ServiceContract(Namespace="http://tempuri.org/Banking3Service")]
    interface IBanking3Service
    {
        [OperationContract]
        AccountSummary GetAccountSummary(CustomerInfo customer);
    }
}
