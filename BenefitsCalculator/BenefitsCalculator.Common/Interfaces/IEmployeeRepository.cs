using System.Collections.Generic;
using System.Threading.Tasks;
using BenefitsCalculator.Common.Entities;

namespace BenefitsCalculator.Common.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetItemAsync(int id);
        Task<List<Employee>> GetItemsAsync();
        Task<Employee> AddItemAsync(Employee employee);
    }
}
