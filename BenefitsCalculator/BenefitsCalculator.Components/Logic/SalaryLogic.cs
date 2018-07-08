using System;
using BenefitsCalculator.Common.Entities;
using BenefitsCalculator.Common.Entities.Configuration;
using BenefitsCalculator.Common.Interfaces;
using Microsoft.Extensions.Options;

namespace BenefitsCalculator.Components.Logic
{
    public class SalaryLogic : ISalaryLogic
    {
        private readonly PayrollSettings _payrollSettings;

        public SalaryLogic(IOptions<PayrollSettings> payrollSettings)
        {
            this._payrollSettings = payrollSettings.Value;
        }

        // TODO note this logic should be extracted into a repository in order to abstract the storage mechanism
        public Salary GetItem(Employee employee)
        {
            if (employee == null) { throw new ArgumentNullException(nameof(employee)); }

            return new Salary()
            {
                PerPeriod = _payrollSettings.Amount,
                Interval = _payrollSettings.PayInterval,
            };
        }
    }
}
