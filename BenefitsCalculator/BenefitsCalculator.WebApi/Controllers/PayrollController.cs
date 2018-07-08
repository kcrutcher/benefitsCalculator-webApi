using BenefitsCalculator.Common.Entities;
using BenefitsCalculator.Common.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BenefitsCalculator.WebApi.Controllers
{
    [EnableCors("OpenPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PayrollController : Controller
    {
        private readonly IPayrollLogic _payrollLogic;

        public PayrollController(IPayrollLogic payrollLogic)
        {
            this._payrollLogic = payrollLogic;
        }

        [HttpPost]
        public IActionResult Preview([FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Payroll payroll = this._payrollLogic.Calculate(employee);

            return Ok(payroll);
        }
    }
}