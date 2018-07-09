using System.Collections.Generic;
using System.Linq;
using BenefitsCalculator.Common.Entities;
using BenefitsCalculator.Common.Entities.Enums;
using BenefitsCalculator.Common.Interfaces;
using BenefitsCalculator.Components.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests
{
    [TestClass]
    public class PayrollLogicTests
    {
        [TestMethod]
        public void SalaryShouldMatchPayScheduleSummation()
        {
            var employee = new Employee(1, "Alan", "Smith");
            var salary = new Salary() { PerPeriod = 1000, Interval = PayInterval.Weekly };
            var benefit = new Benefit() { Beneficiary = employee, GrossCost = 1000 };
            var benefitPackage = new BenefitPackage();
            benefitPackage.Benefits.Add(benefit);

            var mockSalaryLogic = new Mock<ISalaryLogic>();
            mockSalaryLogic.Setup(x => x.GetItem(employee)).Returns(salary);

            var mockBenefitLogic = new Mock<IBenefitPackageLogic>();
            mockBenefitLogic.Setup(x => x.GetItem(employee)).Returns(benefitPackage);

            var payrollLogic = new PayrollLogic(mockSalaryLogic.Object, mockBenefitLogic.Object);

            Payroll payroll = payrollLogic.Calculate(employee);

            Assert.AreEqual(payroll.Salary.Yearly, payroll.PaySchedule.Sum(x => x.GrossPay));
            Assert.AreEqual(payroll.NetYearlySalary, payroll.PaySchedule.Sum(x => x.NetPay));
        }

        [TestMethod]
        public void PayIntervalShouldMatchPaycheckCount()
        {
            var expectedPaycheckCounts = new List<int>() { 12 /*monthly*/, 26 /*biweekly*/, 52 /*weekly*/};

            expectedPaycheckCounts.ForEach(expectedPaycheckCount =>
            {
                var employee = new Employee(1, "Alan", "Smith");
                var salary = new Salary() { PerPeriod = 1000, Interval = (PayInterval)expectedPaycheckCount };
                var benefit = new Benefit() { Beneficiary = employee, GrossCost = 1000 };
                var benefitPackage = new BenefitPackage();
                benefitPackage.Benefits.Add(benefit);

                var mockSalaryLogic = new Mock<ISalaryLogic>();
                mockSalaryLogic.Setup(x => x.GetItem(employee)).Returns(salary);

                var mockBenefitLogic = new Mock<IBenefitPackageLogic>();
                mockBenefitLogic.Setup(x => x.GetItem(employee)).Returns(benefitPackage);

                var payrollLogic = new PayrollLogic(mockSalaryLogic.Object, mockBenefitLogic.Object);

                Payroll payroll = payrollLogic.Calculate(employee);

                Assert.AreEqual(expectedPaycheckCount, payroll.PaySchedule.Count);
            });
        }
    }
}
