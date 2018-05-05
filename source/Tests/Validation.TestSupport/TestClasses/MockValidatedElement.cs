// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace EnterpriseLibrary.Validation.TestSupport.TestClasses
{
    public class MockValidatedElement : IValidatedElement
    {
        public MockValidatedElement(bool ignoreNulls,
            string ignoreNullsMessageTemplate,
            string ignoreNullsTag,
            CompositionType compositionType,
            string compositionMessageTemplate,
            string compositionTag)
        {
            this.ignoreNulls = ignoreNulls;
            this.ignoreNullsMessageTemplate = ignoreNullsMessageTemplate;
            this.ignoreNullsTag = ignoreNullsTag;
            this.compositionType = compositionType;
            this.compositionMessageTemplate = compositionMessageTemplate;
            this.compositionTag = compositionTag;
        }

        private bool ignoreNulls;
        bool IValidatedElement.IgnoreNulls
        {
            get { return ignoreNulls; }
        }

        private string ignoreNullsMessageTemplate;
        string IValidatedElement.IgnoreNullsMessageTemplate
        {
            get { return ignoreNullsMessageTemplate; }
        }

        private string ignoreNullsTag;
        string IValidatedElement.IgnoreNullsTag
        {
            get { return ignoreNullsTag; }
        }

        private CompositionType compositionType;
        CompositionType IValidatedElement.CompositionType
        {
            get { return compositionType; }
        }

        private string compositionMessageTemplate;
        string IValidatedElement.CompositionMessageTemplate
        {
            get { return compositionMessageTemplate; }
        }

        private string compositionTag;
        string IValidatedElement.CompositionTag
        {
            get { return compositionTag; }
        }

        IEnumerable<IValidatorDescriptor> IValidatedElement.GetValidatorDescriptors()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        MemberInfo IValidatedElement.MemberInfo
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        Type IValidatedElement.TargetType
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
    }
}
