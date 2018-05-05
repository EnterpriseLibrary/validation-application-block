// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using EnterpriseLibrary.Validation.Properties;

namespace EnterpriseLibrary.Validation.Configuration
{
    /// <summary>
    /// A <see cref="TypeConverter"/> implementation intended to convert to and from <see cref="CultureInfo"/> instances when serializing and de-serializing from configuration.
    /// </summary>
    public class ConfigurationCultureInfoConverter : TypeConverter
    {
        /// <summary/>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return (sourceType == typeof(string));
        }

        /// <summary/>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string && !string.IsNullOrEmpty((string)value))
            {
                return CultureInfo.GetCultureInfo((string)value);
            }
            return null;
        }

        /// <summary/>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return (destinationType == typeof(string));
        }

        /// <summary/>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value == CultureInfo.InvariantCulture) throw new ArgumentException(Resources.InvariantCultureCannotBeUsedToDeserializeConfiguration, "culture");

            if (value is CultureInfo && destinationType == typeof(string))
            {
                return ((CultureInfo)value).Name;
            }
            return null;
        }
    }
}
