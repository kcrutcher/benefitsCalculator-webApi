using System;
using System.Collections.Generic;
using System.Linq;
using BenefitsCalculator.Common.Entities;
using BenefitsCalculator.Common.Interfaces;
using BenefitsCalculator.Common.Utilities;

namespace BenefitsCalculator.Components.Logic
{
    public class PayrollLogic : IPayrollLogic
    {
        private readonly ISalaryLogic _salaryLogic;
        private readonly IBenefitPackageLogic _benefitPackageLogic;

        public PayrollLogic(ISalaryLogic salaryLogic, IBenefitPackageLogic benefitPackageLogic)
        {
            this._salaryLogic = salaryLogic;
            this._benefitPackageLogic = benefitPackageLogic;
        }

        public Payroll Calculate(Employee employee)
        {
            if (employee == null) { throw new ArgumentNullException(nameof(employee)); }

            var payroll = new Payroll();

            payroll.Employee = employee;
            payroll.Salary = _salaryLogic.GetItem(employee);
            payroll.BenefitPackage = _benefitPackageLogic.GetItem(employee);
            payroll.NetYearlySalary = CalculateNetYearlySalary(payroll.Salary.Yearly, payroll.BenefitPackage.NetCost);
            payroll.PaySchedule.AddRange(BreakoutPaySchedule(payroll.Salary, payroll.BenefitPackage));

            return payroll;
        }

        private static decimal CalculateNetYearlySalary(decimal grossYearlySalary, decimal netBenefitCost)
        {
            return grossYearlySalary - netBenefitCost;
        }

        private static IEnumerable<PayPeriod> BreakoutPaySchedule(Salary salary, BenefitPackage benefitPackage)
        {
            int payPeriodsPerYear = (int)salary.Interval;

            decimal typicalDeductions = (benefitPackage.NetCost / payPeriodsPerYear).TruncateToTwoDecimals();

            var periods = Enumerable.Range(1, payPeriodsPerYear - 1)
                                    .Select(index => new PayPeriod()
                                    {
                                        Period = index,
                                        GrossPay = salary.PerPeriod,
                                        Deductions = typicalDeductions,
                                    }).ToList();

            var lastPeriod = new PayPeriod
            {
                Period = payPeriodsPerYear,
                GrossPay = salary.Yearly - periods.Sum(x => x.GrossPay),
                Deductions = benefitPackage.NetCost - periods.Sum(x => x.Deductions)
            };

            periods.Add(lastPeriod);

            return periods;
        }
    }
}
