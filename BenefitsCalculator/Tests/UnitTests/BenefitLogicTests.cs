using System.Linq;
using BenefitsCalculator.Components.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BenefitLogicTests
    {
        [TestMethod]
        public void BeneficiaryRulesExist()
        { 
            Assert.IsTrue(new BenefitLogic().BeneficiaryRules.Any());
        }
    }
}
