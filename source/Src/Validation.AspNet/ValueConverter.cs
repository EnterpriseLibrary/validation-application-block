// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;

namespace EnterpriseLibrary.Validation.Integration.AspNet
{
    internal delegate bool ValueConverter(string sourceValue, 
        Type targetType, 
        out object convertedValue, 
        out string conversionErrorMessage);
}
