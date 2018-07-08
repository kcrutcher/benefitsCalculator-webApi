using BenefitsCalculator.Common.Entities;

namespace BenefitsCalculator.Common.Interfaces
{
    public interface IBenefitLogic
    {
        Benefit GetItem(Person person);
    }
}
