namespace ConversionService.Services
{
    // Mal patrón: Clase con responsabilidades múltiples
    public class TemperatureService
    {
        // Mal patrón: Variables globales innecesarias
        private readonly double _celsiusToFahrenheitFactor = 9.0 / 5.0;
        private readonly double _fahrenheitOffset = 32.0;
        private readonly double _kelvinOffset = 273.15;

        // Mal patrón: Métodos que hacen lo mismo pero con nombres diferentes
        public double ConvertCelsiusToFahrenheit(double celsius)
        {
            return (celsius * _celsiusToFahrenheitFactor) + _fahrenheitOffset;
        }

        public double CelsiusToFahrenheit(double celsius)
        {
            // Código redundante: Misma lógica que el método anterior
            return (celsius * 9.0 / 5.0) + 32.0;
        }

        public double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - _fahrenheitOffset) / _celsiusToFahrenheitFactor;
        }

        public double FahrenheitToCelsius(double fahrenheit)
        {
            // Código redundante: Misma lógica que el método anterior
            return (fahrenheit - 32.0) * 5.0 / 9.0;
        }

        public double ConvertCelsiusToKelvin(double celsius)
        {
            return celsius + _kelvinOffset;
        }

        public double CelsiusToKelvin(double celsius)
        {
            // Código redundante: Misma lógica que el método anterior
            return celsius + 273.15;
        }

        public double ConvertKelvinToCelsius(double kelvin)
        {
            return kelvin - _kelvinOffset;
        }

        public double KelvinToCelsius(double kelvin)
        {
            // Código redundante: Misma lógica que el método anterior
            return kelvin - 273.15;
        }

        // Mal patrón: Método que hace múltiples cosas
        public object ConvertAll(double value, string fromUnit, string toUnit)
        {
            double result = 0;
            string message = "";

            if (fromUnit.ToLower() == "celsius" && toUnit.ToLower() == "fahrenheit")
            {
                result = ConvertCelsiusToFahrenheit(value);
                message = "Conversión de Celsius a Fahrenheit";
            }
            else if (fromUnit.ToLower() == "fahrenheit" && toUnit.ToLower() == "celsius")
            {
                result = ConvertFahrenheitToCelsius(value);
                message = "Conversión de Fahrenheit a Celsius";
            }
            else if (fromUnit.ToLower() == "celsius" && toUnit.ToLower() == "kelvin")
            {
                result = ConvertCelsiusToKelvin(value);
                message = "Conversión de Celsius a Kelvin";
            }
            else if (fromUnit.ToLower() == "kelvin" && toUnit.ToLower() == "celsius")
            {
                result = ConvertKelvinToCelsius(value);
                message = "Conversión de Kelvin a Celsius";
            }
            else
            {
                message = "Conversión no soportada";
            }

            return new { fromValue = value, fromUnit, toUnit, result, message };
        }
    }
} 