using BenefitsCalculator.Common.Entities;

namespace BenefitsCalculator.Common.Interfaces
{
    public interface IPayrollLogic
    {
        Payroll Calculate(Employee employee);
    }
}
