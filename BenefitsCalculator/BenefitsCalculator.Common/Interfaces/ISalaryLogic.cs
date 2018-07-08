using BenefitsCalculator.Common.Entities;

namespace BenefitsCalculator.Common.Interfaces
{
    public interface ISalaryLogic
    {
        Salary GetItem(Employee employee);
    }
}
