using BenefitsCalculator.Common.Entities.Enums;

namespace BenefitsCalculator.Common.Entities
{
    public class Salary
    {
        public decimal PerPeriod { get; set; }

        public PayInterval Interval { get; set; }

        public decimal Yearly => PerPeriod * (int)Interval;
    }
}
