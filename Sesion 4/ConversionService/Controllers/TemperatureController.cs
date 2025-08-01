using Microsoft.AspNetCore.Mvc;

namespace ConversionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemperatureController : ControllerBase
    {
        // Mal patrón: Lógica de negocio directamente en el controlador
        [HttpGet("celsius-to-fahrenheit/{celsius}")]
        public IActionResult CelsiusToFahrenheit(double celsius)
        {
            // Código redundante: Misma lógica repetida en múltiples lugares
            double fahrenheit = (celsius * 9 / 5) + 32;
            return Ok(new { celsius, fahrenheit, message = "Conversión exitosa" });
        }

        [HttpGet("fahrenheit-to-celsius/{fahrenheit}")]
        public IActionResult FahrenheitToCelsius(double fahrenheit)
        {
            // Código redundante: Misma lógica repetida en múltiples lugares
            double celsius = (fahrenheit - 32) * 5 / 9;
            return Ok(new { fahrenheit, celsius, message = "Conversión exitosa" });
        }

        [HttpGet("celsius-to-kelvin/{celsius}")]
        public IActionResult CelsiusToKelvin(double celsius)
        {
            // Código redundante: Misma lógica repetida en múltiples lugares
            double kelvin = celsius + 273.15;
            return Ok(new { celsius, kelvin, message = "Conversión exitosa" });
        }

        [HttpGet("kelvin-to-celsius/{kelvin}")]
        public IActionResult KelvinToCelsius(double kelvin)
        {
            // Código redundante: Misma lógica repetida en múltiples lugares
            double celsius = kelvin - 273.15;
            return Ok(new { kelvin, celsius, message = "Conversión exitosa" });
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
                    new { from = "celsius", to = "fahrenheit", value = 25.0, result = 77.0 },
                    new { from = "fahrenheit", to = "celsius", value = 77.0, result = 25.0 },
                    new { from = "celsius", to = "kelvin", value = 25.0, result = 298.15 }
                }
            };
            return Ok(result);
        }
    }
} 