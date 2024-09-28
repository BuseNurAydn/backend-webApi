using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;
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
                .Select(e => new
                {
                    Value = (int)e,
                    Text = e.GetDisplayName()  // EnumExtension metodunu kullanarak display name'i alıyoruz
                })
                .ToList();

            return Ok(customerTypes);
        }


        [HttpGet("tax-calculation-types")]
        public IActionResult GetTaxCalculationTypes()
        {
            var taxCalculationTypes = Enum.GetValues(typeof(TaxCalculationType))
                .Cast<TaxCalculationType>()
                .Select(e => new
                {
                    Value = (int)e,
                    Text = e.GetDisplayName()  // Display name'i alıyoruz
                })
                .ToList();

            return Ok(taxCalculationTypes);
        }


        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            var status = Enum.GetValues(typeof(Status))
               .Cast<Status>()
               .Select(e => new {
                   Value = (int)e,
                   Text = e.GetDisplayName()  // EnumExtension metodunu kullanarak display name'i alıyoruz
               })
              .ToList();

            return Ok(status);
        }
    }

}
