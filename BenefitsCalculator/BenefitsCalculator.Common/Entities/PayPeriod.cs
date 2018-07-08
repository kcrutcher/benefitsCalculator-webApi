namespace BenefitsCalculator.Common.Entities
{
    public class PayPeriod
    {
        public int Period { get; set; }

        public decimal GrossPay { get; set; }

        public decimal Deductions { get; set; }

        public decimal NetPay => GrossPay - Deductions;
    }
}
