using BenefitsCalculator.Common.Entities.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BenefitsCalculator.WebApi.Controllers
{
    [EnableCors("OpenPolicy")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PayrollSettingsController : Controller
    {
        private readonly IOptions<PayrollSettings> _payrollSettings;

        public PayrollSettingsController(IOptions<PayrollSettings> payrollSettings)
        {
            this._payrollSettings = payrollSettings;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this._payrollSettings.Value);
        }
    }
}
