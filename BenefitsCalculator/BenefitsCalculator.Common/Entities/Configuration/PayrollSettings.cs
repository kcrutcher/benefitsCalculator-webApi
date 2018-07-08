using BenefitsCalculator.Common.Entities.Enums;

namespace BenefitsCalculator.Common.Entities.Configuration
{
    public class PayrollSettings
    {
        public PayInterval PayInterval { get; set; }

        public decimal Amount { get; set; }
    }
}
