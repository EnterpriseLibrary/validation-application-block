// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.ServiceModel.Channels;
using System.Xml;

namespace EnterpriseLibrary.Validation.Integration.WCF
{
    /// <summary>
    /// Represents the binding element that contains the message validation policy.
    /// </summary>
    public class ValidationBindingElement : BindingElement
    {
        private static XmlDocument doc = new XmlDocument();

        /// <summary>
        /// When overridden in a derived class, returns a copy of the binding element object.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.ServiceModel.Channels.BindingElement"></see> object that is a deep clone of the original.
        /// </returns>
        public override BindingElement Clone()
        {
            return this; 
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public override T GetProperty<T>(BindingContext context)
        {
            return context.GetInnerProperty<T>();
        }
    }
}
