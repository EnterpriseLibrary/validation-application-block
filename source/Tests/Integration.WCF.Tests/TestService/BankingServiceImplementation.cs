// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS.TestService
{
    class BankingServiceImplementation : IBankingService, IBanking2Service, IBanking3Service, IBanking4Service
    {
        public AccountSummary GetAccountSummary(CustomerInfo customer)
        {
            return new AccountSummary();
        }

        public AccountSummary GetAccountSummary2(CustomerInfo customer)
        {
            return new AccountSummary();
        }
    }
}
