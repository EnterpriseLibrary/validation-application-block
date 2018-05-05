// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;

namespace EnterpriseLibrary.Validation.Validators
{
    /// <summary>
    /// 
    /// </summary>
    public class RelativeDateTimeGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bound"></param>
        /// <param name="unit"></param>
        /// <param name="referenceDateTime"></param>
        /// <returns></returns>
        public DateTime GenerateBoundDateTime(int bound, DateTimeUnit unit, DateTime referenceDateTime)
        {
            DateTime result;

            switch (unit)
            {
                case DateTimeUnit.Day: result = referenceDateTime.AddDays(bound); break;
                case DateTimeUnit.Hour: result = referenceDateTime.AddHours(bound); break;
                case DateTimeUnit.Minute: result = referenceDateTime.AddMinutes(bound); break;
                case DateTimeUnit.Month: result = referenceDateTime.AddMonths(bound); break;
                case DateTimeUnit.Second: result = referenceDateTime.AddSeconds(bound); break;
                case DateTimeUnit.Year: result = referenceDateTime.AddYears(bound); break;
                default: result = referenceDateTime; break;
            }
            return result;
        }
    }
}
