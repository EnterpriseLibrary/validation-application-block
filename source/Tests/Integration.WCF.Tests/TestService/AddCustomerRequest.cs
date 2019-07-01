// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Runtime.Serialization;
using System.ServiceModel;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS.TestService
{
    [MessageContract]
    internal class AddCustomerRequest
    {
        private string firstName;
        private string lastName;
        private string ssn;

        public AddCustomerRequest()
        {
        }

        public AddCustomerRequest(string firstName, string lastName, string ssn)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.ssn = ssn;
        }

        [DataMember(IsRequired=false, Name = "FirstName")]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        [DataMember(IsRequired = false, Name="LastName")]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [DataMember(IsRequired=false, Name="SSN")]
        [RegexValidator(@"\d\d\d-\d\d-\d\d\d\d")]
        public string SSN
        {
            get { return ssn; }
            set { ssn = value; }
        }
    }
}
