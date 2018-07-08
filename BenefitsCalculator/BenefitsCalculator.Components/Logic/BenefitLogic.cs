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
        // TODO expose these via a service
        private static readonly Dictionary<Type, decimal> benefitCosts = new Dictionary<Type, decimal>();
        private static readonly List<IBeneficiaryRule> beneficiaryRules = new List<IBeneficiaryRule>();

        static BenefitLogic()
        {
            benefitCosts.Add(typeof(Employee), 1000);
            benefitCosts.Add(typeof(Person), 500);

            beneficiaryRules.AddRange(Assembly.GetExecutingAssembly().GetInterfaceImplementations<IBeneficiaryRule>());
        }

        // TODO make this async
        public Benefit GetItem(Person person)
        {
            if (person == null) { throw new ArgumentNullException(nameof(person)); }

            var benefit = new Benefit();
            benefit.Beneficiary = person;
            benefit.GrossCost = benefitCosts[person.GetType()];

            beneficiaryRules.ForEach(rule =>
            {
                decimal discount = rule.DetermineDiscount(benefit);
                if (discount > 0)
                {
                    benefit.Discounts.Add(discount);
                }
            });

            return benefit;
        }
    }
}
