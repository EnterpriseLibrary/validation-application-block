// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Runtime.Serialization;
using System.ServiceModel;

namespace EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS.TestService
{
    [MessageContract]
    internal class AddCustomerResponse
    {
        private string fullName;
        private bool added;

        public AddCustomerResponse()
        {
        }

        public AddCustomerResponse(string fullName, bool added)
        {
            this.fullName = fullName;
            this.added = added;
        }

        [DataMember(IsRequired = false, Name="FullName")]
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        [DataMember(IsRequired=false, Name="Added")]
        public bool Added
        {
            get { return added; }
            set { added = value; }
        }
    }
}
