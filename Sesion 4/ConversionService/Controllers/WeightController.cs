using Microsoft.AspNetCore.Mvc;

namespace ConversionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeightController : ControllerBase
    {
        // Mal patrón: Lógica de negocio directamente en el controlador
        [HttpGet("kilograms-to-pounds/{kilograms}")]
        public IActionResult KilogramsToPounds(double kilograms)
        {
            // Código redundante: Misma lógica repetida en múltiples lugares
            double pounds = kilograms * 2.20462;
            return Ok(new { kilograms, pounds, message = "Conversión exitosa" });
        }

        [HttpGet("pounds-to-kilograms/{pounds}")]
        public IActionResult PoundsToKilograms(double pounds)
        {
            // Código redundante: Misma lógica repetida en múltiples lugares
            double kilograms = pounds / 2.20462;
            return Ok(new { pounds, kilograms, message = "Conversión exitosa" });
        }

        [HttpGet("grams-to-ounces/{grams}")]
        public IActionResult GramsToOunces(double grams)
        {
            // Código redundante: Misma lógica repetida en múltiples lugares
            double ounces = grams * 0.035274;
            return Ok(new { grams, ounces, message = "Conversión exitosa" });
        }

        [HttpGet("ounces-to-grams/{ounces}")]
        public IActionResult OuncesToGrams(double ounces)
        {
            // Código redundante: Misma lógica repetida en múltiples lugares
            double grams = ounces / 0.035274;
            return Ok(new { ounces, grams, message = "Conversión exitosa" });
        }

        // Mal patrón: Método que hace múltiples cosas
        [HttpPost("convert-all")]
        public IActionResult ConvertAll([FromBody] object request)
        {
            // Código redundante y mal estructurado
            var result = new
            {
                message = "Conversiones múltiples",
                conversions = new[]
                {
                    new { from = "kilograms", to = "pounds", value = 10.0, result = 22.0462 },
                    new { from = "pounds", to = "kilograms", value = 22.0462, result = 10.0 },
                    new { from = "grams", to = "ounces", value = 100.0, result = 3.5274 }
                }
            };
            return Ok(result);
        }
    }
} 