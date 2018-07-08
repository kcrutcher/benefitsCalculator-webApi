using System.Collections.Generic;

namespace BenefitsCalculator.Common.Entities
{
    public class Payroll
    {
        public Employee Employee { get; set; }

        public Salary Salary { get; set; }

        public BenefitPackage BenefitPackage { get; set; }

        public decimal NetYearlySalary { get; set; }

        public List<PayPeriod> PaySchedule { get; private set; } = new List<PayPeriod>();
    }
}
