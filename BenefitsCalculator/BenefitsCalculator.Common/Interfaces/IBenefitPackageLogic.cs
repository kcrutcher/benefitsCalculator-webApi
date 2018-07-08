using BenefitsCalculator.Common.Entities;

namespace BenefitsCalculator.Common.Interfaces
{
    public interface IBenefitPackageLogic
    {
        BenefitPackage GetItem(Employee employee);
    }
}
