using System;
using System.Collections.Generic;
using System.Reflection;
using BenefitsCalculator.Common.Entities;
using BenefitsCalculator.Common.Interfaces;
using BenefitsCalculator.Common.Utilities;

namespace BenefitsCalculator.Components.Logic
{
    public class BenefitLogic : IBenefitLogic
    {
        private static readonly Dictionary<Type, decimal> benefitCosts = new Dictionary<Type, decimal>();
        public IReadOnlyCollection<IBeneficiaryRule> BeneficiaryRules => Assembly.GetExecutingAssembly().GetInterfaceImplementations<IBeneficiaryRule>();

        static BenefitLogic()
        {
            // TODO expose these via a service
            benefitCosts.Add(typeof(Employee), 1000);
            benefitCosts.Add(typeof(Person), 500);
        }

        public Benefit GetItem(Person person)
        {
            if (person == null) { throw new ArgumentNullException(nameof(person)); }

            var benefit = new Benefit();
            benefit.Beneficiary = person;
            benefit.GrossCost = benefitCosts[person.GetType()];

            foreach (var rule in this.BeneficiaryRules)
            {
                decimal discount = rule.DetermineDiscount(benefit);
                if (discount > 0)
                {
                    benefit.Discounts.Add(discount);
                }
            }

            return benefit;
        }
    }
}
