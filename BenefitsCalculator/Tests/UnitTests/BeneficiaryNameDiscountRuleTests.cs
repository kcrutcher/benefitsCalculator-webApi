using BenefitsCalculator.Common.Entities;
using BenefitsCalculator.Components.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BeneficiaryNameDiscountRuleTests
    {
        private BeneficiaryNameDiscountRule _rule;

        [TestInitialize]
        public void Initialize()
        {
            this._rule = new BeneficiaryNameDiscountRule();
        }

        [TestMethod]
        public void NameDiscountShouldApply()
        {
            decimal grossBenefitCost = 1000;

            var benefit = BuildBenefitForTest(grossBenefitCost, "Aaron");

            decimal discount = _rule.DetermineDiscount(benefit);

            Assert.AreEqual(grossBenefitCost * BeneficiaryNameDiscountRule.DiscountPercent, discount);
        }

        [TestMethod]
        public void NameDiscountShouldNotApply()
        {
            var benefit = BuildBenefitForTest(1000, "James");

            decimal discount = _rule.DetermineDiscount(benefit);

            Assert.AreEqual(0, discount);
        }

        private Benefit BuildBenefitForTest(decimal grossBenefitCost, string beneficiaryFirstName)
        {
            return new Benefit() { GrossCost = grossBenefitCost, Beneficiary = new Person() { FirstName = beneficiaryFirstName } };
        }
    }
}
