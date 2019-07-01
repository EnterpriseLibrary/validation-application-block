// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS.TestService
{
    [DataContract(Name="TaxInfo", Namespace = "http://tempuri.org/TaxInfo")]
    class TaxInfo
    {
        string taxId;
        string taxingState;

        public TaxInfo()
        {
        }

        public TaxInfo(string taxId, string taxingState)
        {
            this.taxId = taxId;
            this.taxingState = taxingState;
        }

        [DataMember(IsRequired=false, Name="TaxId", Order=0)]
        [RegexValidator(@"\d+") ]
        public string TaxId
        {
            get { return taxId; }
            set { taxId = value; }
        }

        [DataMember(IsRequired = false, Name="TaxingState", Order=1)]
        [RegexValidator(@"[A-Z]{2}")]
        public string TaxingState
        {
            get { return taxingState; }
            set { taxingState = value; }
        }
    }
}
