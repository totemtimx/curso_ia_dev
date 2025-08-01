using Microsoft.AspNetCore.Mvc;

namespace ConversionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DistanceController : ControllerBase
    {
        // Mal patrón: Lógica de negocio directamente en el controlador
        [HttpGet("meters-to-feet/{meters}")]
        public IActionResult MetersToFeet(double meters)
        {
            // Código redundante: Misma lógica repetida en múltiples lugares
            double feet = meters * 3.28084;
            return Ok(new { meters, feet, message = "Conversión exitosa" });
        }

        [HttpGet("feet-to-meters/{feet}")]
        public IActionResult FeetToMeters(double feet)
        {
            // Código redundante: Misma lógica repetida en múltiples lugares
            double meters = feet / 3.28084;
            return Ok(new { feet, meters, message = "Conversión exitosa" });
        }

        [HttpGet("kilometers-to-miles/{kilometers}")]
        public IActionResult KilometersToMiles(double kilometers)
        {
            // Código redundante: Misma lógica repetida en múltiples lugares
            double miles = kilometers * 0.621371;
            return Ok(new { kilometers, miles, message = "Conversión exitosa" });
        }

        [HttpGet("miles-to-kilometers/{miles}")]
        public IActionResult MilesToKilometers(double miles)
        {
            // Código redundante: Misma lógica repetida en múltiples lugares
            double kilometers = miles / 0.621371;
            return Ok(new { miles, kilometers, message = "Conversión exitosa" });
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
                    new { from = "meters", to = "feet", value = 10.0, result = 32.8084 },
                    new { from = "feet", to = "meters", value = 32.8084, result = 10.0 },
                    new { from = "kilometers", to = "miles", value = 10.0, result = 6.21371 }
                }
            };
            return Ok(result);
        }
    }
} 