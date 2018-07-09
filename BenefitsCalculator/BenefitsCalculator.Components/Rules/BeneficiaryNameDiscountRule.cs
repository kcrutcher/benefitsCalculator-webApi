using System;
using BenefitsCalculator.Common.Entities;
using BenefitsCalculator.Common.Interfaces;

namespace BenefitsCalculator.Components.Rules
{
    public class BeneficiaryNameDiscountRule : IBeneficiaryRule
    {
        public static readonly decimal DiscountPercent = .1m;

        public decimal DetermineDiscount(Benefit benefit)
        {
            if (benefit == null) { throw new ArgumentNullException(nameof(benefit)); }
            if (benefit.Beneficiary == null) { throw new ArgumentException($"{nameof(benefit.Beneficiary)} cannot be null."); }

            if (!EligibleForDiscount(benefit.Beneficiary.FirstName))
            {
                return 0;
            }

            return benefit.GrossCost * DiscountPercent;
        }

        private static bool EligibleForDiscount(string firstName)
        {
            return firstName?.StartsWith("A", StringComparison.InvariantCultureIgnoreCase) ?? false;
        }
    }
}
