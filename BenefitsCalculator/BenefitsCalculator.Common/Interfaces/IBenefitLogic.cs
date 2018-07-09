using System.Collections.Generic;
using BenefitsCalculator.Common.Entities;

namespace BenefitsCalculator.Common.Interfaces
{
    public interface IBenefitLogic
    {
        IReadOnlyCollection<IBeneficiaryRule> BeneficiaryRules { get; }

        Benefit GetItem(Person person);
    }
}
