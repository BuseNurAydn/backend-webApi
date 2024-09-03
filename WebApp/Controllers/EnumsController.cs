using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{

    [Route("api/enums")]
    [ApiController]
    public class EnumsController : ControllerBase
    {
        //enum değerlerini frontend'e display name ile göndermek için 
        /* postman çıktı
        {
        "value": 1,
        "text": "Taksit Tutarı"
        }
       */
       

        [HttpGet("customer-types")]
        public IActionResult GetCustomerTypes()
        {
            var customerTypes = Enum.GetValues(typeof(CustomerType))
                .Cast<CustomerType>()
                .Select(tct => new { value = (int)tct, text = tct.GetDisplayName() })
                .ToList();

            return Ok(customerTypes);
        }



        [HttpGet("tax-calculation-types")]
        public IActionResult GetTaxCalculationTypes()
        {
            var taxCalculationTypes = Enum.GetValues(typeof(TaxCalculationType))
                .Cast<TaxCalculationType>()
                .Select(tct => new { value = (int)tct, text = tct.GetDisplayName() })
                .ToList();

            return Ok(taxCalculationTypes);
        }


        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            var status = Enum.GetValues(typeof(Status))
               .Cast<Status>()
               .Select(tct => new { value = (int)tct, text = tct.GetDisplayName() })
               .ToList();

            return Ok(status);
        }
    }

}
