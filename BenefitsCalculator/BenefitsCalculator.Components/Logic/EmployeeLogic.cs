using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenefitsCalculator.Common.Entities;
using BenefitsCalculator.Common.Interfaces;

namespace BenefitsCalculator.Components.Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeLogic(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task<Employee> GetItemAsync(int id)
        {
            return await this._employeeRepository.GetItemAsync(id);
        }

        public async Task<List<Employee>> GetItemsAsync()
        {
            return await this._employeeRepository.GetItemsAsync();
        }

        public async Task<Employee> AddItemAsync(Employee employee)
        {
            if (employee == null) { throw new ArgumentNullException(nameof(employee)); }

            return await this._employeeRepository.AddItemAsync(employee);
        }
    }
}
