using System.Collections.Generic;

namespace BenefitsCalculator.Common.Entities
{
    public class Employee : Person
    {
        public List<Person> Dependents { get; } = new List<Person>();

        public Employee(int id, string firstName, string lastName, List<Person> dependents)
            : base(id, firstName, lastName)
        {
            this.Dependents = dependents;
        }

        public Employee(string firstName, string lastName, List<Person> dependents)
            : base(firstName, lastName)
        {
            this.Dependents = dependents;
        }

        public Employee(int id, string firstName, string lastName)
            : base(id, firstName, lastName)
        {

        }

        public Employee(string firstName, string lastName)
            : base(firstName, lastName)
        {

        }
    }
}
