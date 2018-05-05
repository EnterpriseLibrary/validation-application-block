﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Configuration;
using System.ServiceModel.Configuration;
using Configuration_ConfigurationProperty=System.Configuration.ConfigurationProperty;

namespace EnterpriseLibrary.Validation.Integration.WCF
{
    /// <summary>
    /// Represents a configuration element that specifies validation features 
    /// for a Windows Communication Foundation (WCF) service.
    /// </summary>
    public class ValidationElement : BehaviorExtensionElement
    {
        private const string EnabledAttributeName = "enabled";
        private const string RulesetAttributeName = "ruleset";

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty(EnabledAttributeName, DefaultValue = true, IsRequired = false)]
        public bool Enabled
        {
            get { return (bool)base[EnabledAttributeName]; }
            set { base[EnabledAttributeName] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigurationProperty(RulesetAttributeName, DefaultValue = null, IsRequired = false)]
        public string Ruleset
        {
            get { return (string)base[RulesetAttributeName]; }
            set { base[RulesetAttributeName] = value;  }
        }

        /// <summary>
        /// Gets the type of behavior.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="ValidationBehavior"/> <see cref="T:System.Type"></see>.</returns>
        public override Type BehaviorType
        {
            get { return typeof(ValidationBehavior); }
        }

        /// <summary>
        /// Creates a behavior extension based on the current configuration settings.
        /// </summary>
        /// <returns>The behavior extension.</returns>
        protected override object CreateBehavior()
        {
            if( Ruleset == null )
            {
                Ruleset = string.Empty;
            }

            return new ValidationBehavior(Enabled, Enabled, Ruleset);
        }
    }
}
