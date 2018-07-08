using System;
using System.Collections.Generic;
using System.Linq;
using BenefitsCalculator.Common.Entities;
using BenefitsCalculator.Common.Interfaces;

namespace BenefitsCalculator.Components.Logic
{
    public class BenefitPackageLogic : IBenefitPackageLogic
    {
        private readonly IBenefitLogic _benefitLogic;

        public BenefitPackageLogic(IBenefitLogic benefitLogic)
        {
            this._benefitLogic = benefitLogic;
        }

        // TODO make this async
        public BenefitPackage GetItem(Employee employee)
        {
            if (employee == null) { throw new ArgumentNullException(nameof(employee)); }

            var benefitPackage = new BenefitPackage();

            var employeeBenefit = this._benefitLogic.GetItem(employee);

            benefitPackage.Benefits.Add(employeeBenefit);

            benefitPackage.Benefits.AddRange(this.GetDependentBenefits(employee));

            return benefitPackage;
        }

        private IEnumerable<Benefit> GetDependentBenefits(Employee employee)
        {
            return employee.Dependents.Select(dependent => this._benefitLogic.GetItem(dependent));
        }
    }
}
