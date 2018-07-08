using System.Collections.Generic;
using System.Linq;

namespace BenefitsCalculator.Common.Entities
{
    public class BenefitPackage
    {
        public string packageName { get; set; }

        public List<Benefit> Benefits { get; } = new List<Benefit>();

        public decimal GrossCost => Benefits.Sum(x => x.GrossCost);

        public decimal Deductions => Benefits.Sum(x => x.Discounts.Sum());

        public decimal NetCost => Benefits.Sum(x => x.NetCost);

    }
}
