// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Integration.WCF.Tests.VSTS.TestService
{
    [DataContract]
    public class CustomerInfo
    {
        private string firstName;
        private string lastName;
        private string ssn;


        public CustomerInfo()
        {
        }


        public CustomerInfo(string firstName, string lastName, string ssn)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.ssn = ssn;
        }

        [DataMember(Order = 0)]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        [DataMember(Order = 1)]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        [DataMember(Order = 2)]
        public string Ssn
        {
            get { return ssn; }
            set { ssn = value; }
        }
    }
}
