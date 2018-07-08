using BenefitsCalculator.Common.Entities;

namespace BenefitsCalculator.Common.Interfaces
{
    public interface IBeneficiaryRule
    {
        decimal DetermineDiscount(Benefit benefit);
    }
}
