using System.ComponentModel.DataAnnotations;

namespace BenefitsCalculator.Common.Entities
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public Person() { }

        public Person(int id, string firstName, string lastName)
            : this(firstName, lastName)
        {
            this.Id = id;
        }

        public Person(string firstName, string lastName)
            : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
