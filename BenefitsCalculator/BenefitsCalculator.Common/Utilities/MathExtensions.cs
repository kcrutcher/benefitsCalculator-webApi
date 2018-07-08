using System;

namespace BenefitsCalculator.Common.Utilities
{
    public static class MathExtensions
    {
        public static decimal TruncateToTwoDecimals(this decimal valueToTruncate)
        {
            return Math.Truncate((valueToTruncate) * 100) / 100;
        }
    }
}
