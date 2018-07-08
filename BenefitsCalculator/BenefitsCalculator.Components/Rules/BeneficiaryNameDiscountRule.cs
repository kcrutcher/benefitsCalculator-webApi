using System;
using BenefitsCalculator.Common.Entities;

namespace BenefitsCalculator.Components.Rules
{
    public class BeneficiaryNameDiscountRule
    {
        public static readonly decimal DiscountAmount = .1m;

        public decimal DetermineDiscount(Benefit benefit)
        {
            if (benefit == null) { throw new ArgumentNullException(nameof(benefit)); }
            if (benefit.Beneficiary == null) { throw new ArgumentException($"{nameof(benefit.Beneficiary)} cannot be null."); }

            if (!EligibleForDiscount(benefit.Beneficiary.FirstName))
            {
                return 0;
            }

            return benefit.GrossCost * DiscountAmount;
        }

        private static bool EligibleForDiscount(string firstName)
        {
            return firstName?.StartsWith("A", StringComparison.InvariantCultureIgnoreCase) ?? false;
        }
    }
}
