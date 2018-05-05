// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EnterpriseLibrary.Validation.Integration.WCF
{
    /// <summary>
    /// This class is used to return information to a WCF
    /// client when validation fails on a service parameter.
    /// </summary>
    [DataContract(Name = ValidationConstants.FaultContractName,
        Namespace = ValidationConstants.FaultContractNamespace)]
    public class ValidationFault
    {
        private IList<ValidationDetail> details;

        /// <summary>
        /// 
        /// </summary>
        public ValidationFault()
        : this( new ValidationDetail[] { })
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="details"></param>
        public ValidationFault(IEnumerable<ValidationDetail> details)
        {
            this.details = new List<ValidationDetail>(details);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="detail"></param>
        public void Add( ValidationDetail detail )
        {
            details.Add(detail);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsValid
        {
            get { return details.Count == 0;  }
        }
        
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public IList<ValidationDetail> Details
        {
            get { return details; }
            set { details = value; }
        }
    }
}
