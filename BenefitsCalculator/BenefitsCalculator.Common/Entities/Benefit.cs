using System.Collections.Generic;
using System.Linq;

namespace BenefitsCalculator.Common.Entities
{
    public class Benefit
    {
        public Person Beneficiary { get; set; }

        public decimal GrossCost { get; set; }

        public List<decimal> Discounts { get; } = new List<decimal>();

        public decimal NetCost => GrossCost - Discounts.Sum();
    }
}
