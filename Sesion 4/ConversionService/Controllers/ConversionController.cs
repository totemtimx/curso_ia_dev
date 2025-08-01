using Microsoft.AspNetCore.Mvc;
using ConversionService.Services;

namespace ConversionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversionController : ControllerBase
    {
        // Mal patrón: Múltiples instancias del mismo servicio
        private readonly TemperatureService _temperatureService1;
        private readonly TemperatureService _temperatureService2;
        private readonly DistanceService _distanceService1;
        private readonly DistanceService _distanceService2;
        private readonly WeightService _weightService1;
        private readonly WeightService _weightService2;

        // Mal patrón: Constructor con múltiples responsabilidades
        public ConversionController()
        {
            // Código redundante: Crear múltiples instancias innecesarias
            _temperatureService1 = new TemperatureService();
            _temperatureService2 = new TemperatureService();
            _distanceService1 = new DistanceService();
            _distanceService2 = new DistanceService();
            _weightService1 = new WeightService();
            _weightService2 = new WeightService();
        }

        // Mal patrón: Método que hace múltiples cosas
        [HttpPost("convert")]
        public IActionResult Convert([FromBody] ConversionRequest request)
        {
            // Código redundante: Validación repetida
            if (request == null)
            {
                return BadRequest("Request no puede ser null");
            }

            if (string.IsNullOrEmpty(request.FromUnit))
            {
                return BadRequest("FromUnit no puede estar vacío");
            }

            if (string.IsNullOrEmpty(request.ToUnit))
            {
                return BadRequest("ToUnit no puede estar vacío");
            }

            // Mal patrón: Lógica de negocio directamente en el controlador
            object result = null;
            string message = "";

            // Código redundante: Múltiples if-else anidados
            if (request.FromUnit.ToLower() == "celsius" || request.FromUnit.ToLower() == "fahrenheit" || request.FromUnit.ToLower() == "kelvin")
            {
                if (request.FromUnit.ToLower() == "celsius" && request.ToUnit.ToLower() == "fahrenheit")
                {
                    // Código redundante: Usar ambos servicios
                    double result1 = _temperatureService1.ConvertCelsiusToFahrenheit(request.Value);
                    double result2 = _temperatureService2.CelsiusToFahrenheit(request.Value);
                    result = new { fromValue = request.Value, fromUnit = request.FromUnit, toUnit = request.ToUnit, result = result1, alternativeResult = result2 };
                    message = "Conversión de temperatura usando múltiples servicios";
                }
                else if (request.FromUnit.ToLower() == "fahrenheit" && request.ToUnit.ToLower() == "celsius")
                {
                    double result1 = _temperatureService1.ConvertFahrenheitToCelsius(request.Value);
                    double result2 = _temperatureService2.FahrenheitToCelsius(request.Value);
                    result = new { fromValue = request.Value, fromUnit = request.FromUnit, toUnit = request.ToUnit, result = result1, alternativeResult = result2 };
                    message = "Conversión de temperatura usando múltiples servicios";
                }
                else if (request.FromUnit.ToLower() == "celsius" && request.ToUnit.ToLower() == "kelvin")
                {
                    double result1 = _temperatureService1.ConvertCelsiusToKelvin(request.Value);
                    double result2 = _temperatureService2.CelsiusToKelvin(request.Value);
                    result = new { fromValue = request.Value, fromUnit = request.FromUnit, toUnit = request.ToUnit, result = result1, alternativeResult = result2 };
                    message = "Conversión de temperatura usando múltiples servicios";
                }
                else if (request.FromUnit.ToLower() == "kelvin" && request.ToUnit.ToLower() == "celsius")
                {
                    double result1 = _temperatureService1.ConvertKelvinToCelsius(request.Value);
                    double result2 = _temperatureService2.KelvinToCelsius(request.Value);
                    result = new { fromValue = request.Value, fromUnit = request.FromUnit, toUnit = request.ToUnit, result = result1, alternativeResult = result2 };
                    message = "Conversión de temperatura usando múltiples servicios";
                }
                else
                {
                    message = "Conversión de temperatura no soportada";
                }
            }
            else if (request.FromUnit.ToLower() == "meters" || request.FromUnit.ToLower() == "feet" || request.FromUnit.ToLower() == "kilometers" || request.FromUnit.ToLower() == "miles")
            {
                if (request.FromUnit.ToLower() == "meters" && request.ToUnit.ToLower() == "feet")
                {
                    double result1 = _distanceService1.ConvertMetersToFeet(request.Value);
                    double result2 = _distanceService2.MetersToFeet(request.Value);
                    result = new { fromValue = request.Value, fromUnit = request.FromUnit, toUnit = request.ToUnit, result = result1, alternativeResult = result2 };
                    message = "Conversión de distancia usando múltiples servicios";
                }
                else if (request.FromUnit.ToLower() == "feet" && request.ToUnit.ToLower() == "meters")
                {
                    double result1 = _distanceService1.ConvertFeetToMeters(request.Value);
                    double result2 = _distanceService2.FeetToMeters(request.Value);
                    result = new { fromValue = request.Value, fromUnit = request.FromUnit, toUnit = request.ToUnit, result = result1, alternativeResult = result2 };
                    message = "Conversión de distancia usando múltiples servicios";
                }
                else if (request.FromUnit.ToLower() == "kilometers" && request.ToUnit.ToLower() == "miles")
                {
                    double result1 = _distanceService1.ConvertKilometersToMiles(request.Value);
                    double result2 = _distanceService2.KilometersToMiles(request.Value);
                    result = new { fromValue = request.Value, fromUnit = request.FromUnit, toUnit = request.ToUnit, result = result1, alternativeResult = result2 };
                    message = "Conversión de distancia usando múltiples servicios";
                }
                else if (request.FromUnit.ToLower() == "miles" && request.ToUnit.ToLower() == "kilometers")
                {
                    double result1 = _distanceService1.ConvertMilesToKilometers(request.Value);
                    double result2 = _distanceService2.MilesToKilometers(request.Value);
                    result = new { fromValue = request.Value, fromUnit = request.FromUnit, toUnit = request.ToUnit, result = result1, alternativeResult = result2 };
                    message = "Conversión de distancia usando múltiples servicios";
                }
                else
                {
                    message = "Conversión de distancia no soportada";
                }
            }
            else if (request.FromUnit.ToLower() == "kilograms" || request.FromUnit.ToLower() == "pounds" || request.FromUnit.ToLower() == "grams" || request.FromUnit.ToLower() == "ounces")
            {
                if (request.FromUnit.ToLower() == "kilograms" && request.ToUnit.ToLower() == "pounds")
                {
                    double result1 = _weightService1.ConvertKilogramsToPounds(request.Value);
                    double result2 = _weightService2.KilogramsToPounds(request.Value);
                    result = new { fromValue = request.Value, fromUnit = request.FromUnit, toUnit = request.ToUnit, result = result1, alternativeResult = result2 };
                    message = "Conversión de peso usando múltiples servicios";
                }
                else if (request.FromUnit.ToLower() == "pounds" && request.ToUnit.ToLower() == "kilograms")
                {
                    double result1 = _weightService1.ConvertPoundsToKilograms(request.Value);
                    double result2 = _weightService2.PoundsToKilograms(request.Value);
                    result = new { fromValue = request.Value, fromUnit = request.FromUnit, toUnit = request.ToUnit, result = result1, alternativeResult = result2 };
                    message = "Conversión de peso usando múltiples servicios";
                }
                else if (request.FromUnit.ToLower() == "grams" && request.ToUnit.ToLower() == "ounces")
                {
                    double result1 = _weightService1.ConvertGramsToOunces(request.Value);
                    double result2 = _weightService2.GramsToOunces(request.Value);
                    result = new { fromValue = request.Value, fromUnit = request.FromUnit, toUnit = request.ToUnit, result = result1, alternativeResult = result2 };
                    message = "Conversión de peso usando múltiples servicios";
                }
                else if (request.FromUnit.ToLower() == "ounces" && request.ToUnit.ToLower() == "grams")
                {
                    double result1 = _weightService1.ConvertOuncesToGrams(request.Value);
                    double result2 = _weightService2.OuncesToGrams(request.Value);
                    result = new { fromValue = request.Value, fromUnit = request.FromUnit, toUnit = request.ToUnit, result = result1, alternativeResult = result2 };
                    message = "Conversión de peso usando múltiples servicios";
                }
                else
                {
                    message = "Conversión de peso no soportada";
                }
            }
            else
            {
                message = "Tipo de conversión no soportado";
            }

            return Ok(new { result, message });
        }

        // Mal patrón: Método que hace múltiples cosas
        [HttpGet("health")]
        public IActionResult Health()
        {
            // Código redundante: Verificar múltiples servicios innecesariamente
            var healthStatus = new
            {
                status = "OK",
                services = new[]
                {
                    new { name = "TemperatureService1", status = "OK" },
                    new { name = "TemperatureService2", status = "OK" },
                    new { name = "DistanceService1", status = "OK" },
                    new { name = "DistanceService2", status = "OK" },
                    new { name = "WeightService1", status = "OK" },
                    new { name = "WeightService2", status = "OK" }
                },
                timestamp = DateTime.Now,
                message = "Todos los servicios están funcionando correctamente"
            };

            return Ok(healthStatus);
        }
    }

    // Mal patrón: Clase de modelo con propiedades innecesarias
    public class ConversionRequest
    {
        public double Value { get; set; }
        public string FromUnit { get; set; }
        public string ToUnit { get; set; }
        public string Description { get; set; } // Propiedad innecesaria
        public DateTime RequestTime { get; set; } // Propiedad innecesaria
        public string UserId { get; set; } // Propiedad innecesaria
    }
} 