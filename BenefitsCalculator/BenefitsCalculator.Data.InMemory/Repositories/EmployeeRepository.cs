using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenefitsCalculator.Common.Entities;
using BenefitsCalculator.Common.Interfaces;

namespace BenefitsCalculator.Data.InMemory.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static readonly List<Employee> employees = new List<Employee>();
        private static int previousEmployeeId = 0;

        static EmployeeRepository()
        {
            var repository = new EmployeeRepository();

            Task add1 = repository.AddItemAsync(new Employee("Jeffrey", "Lebowski", new List<Person> { new Person("Little", "Lebowski") }));
            Task add2 = repository.AddItemAsync(new Employee("Walter", "Sobchak"));
            Task add3 = repository.AddItemAsync(new Employee("Donny", "Kerabatsos"));
            Task add4 = repository.AddItemAsync(new Employee("Maude", "Lebowski"));
            Task add5 = repository.AddItemAsync(new Employee("Arthur", "Sellers", new List<Person> { new Person("Larry", "Sellers") }));

            Task.WaitAll(add1, add2, add3, add4);
        }

        public async Task<Employee> GetItemAsync(int id)
        {
            return await Task.FromResult(employees.SingleOrDefault(x => x.Id == id));
        }

        public async Task<List<Employee>> GetItemsAsync()
        {
            return await Task.FromResult(employees);
        }

        public async Task<Employee> AddItemAsync(Employee employee)
        {
            // TODO consider how to handle if ID is supplied

            var employeeToAdd = new Employee(GetNextEmployeeId(), employee.FirstName, employee.LastName, employee.Dependents);

            employees.Add(employeeToAdd);

            return await Task.FromResult(employeeToAdd);
        }

        private static int GetNextEmployeeId()
        {
            return ++previousEmployeeId;
        }
    }
}
