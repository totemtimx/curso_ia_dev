namespace ConversionService.Models
{
    // Mal patrón: Clase con responsabilidades múltiples
    public class ConversionConfig
    {
        // Mal patrón: Variables globales innecesarias
        public static readonly double CELSIUS_TO_FAHRENHEIT_FACTOR = 9.0 / 5.0;
        public static readonly double FAHRENHEIT_OFFSET = 32.0;
        public static readonly double KELVIN_OFFSET = 273.15;
        public static readonly double METERS_TO_FEET_FACTOR = 3.28084;
        public static readonly double KILOMETERS_TO_MILES_FACTOR = 0.621371;
        public static readonly double KILOGRAMS_TO_POUNDS_FACTOR = 2.20462;
        public static readonly double GRAMS_TO_OUNCES_FACTOR = 0.035274;

        // Mal patrón: Propiedades redundantes
        public double CelsiusToFahrenheitFactor { get; set; } = 9.0 / 5.0;
        public double FahrenheitOffset { get; set; } = 32.0;
        public double KelvinOffset { get; set; } = 273.15;
        public double MetersToFeetFactor { get; set; } = 3.28084;
        public double KilometersToMilesFactor { get; set; } = 0.621371;
        public double KilogramsToPoundsFactor { get; set; } = 2.20462;
        public double GramsToOuncesFactor { get; set; } = 0.035274;

        // Mal patrón: Métodos que hacen lo mismo
        public double GetCelsiusToFahrenheitFactor()
        {
            return CELSIUS_TO_FAHRENHEIT_FACTOR;
        }

        public double GetCelsiusToFahrenheitFactor2()
        {
            // Código redundante: Misma lógica que el método anterior
            return 9.0 / 5.0;
        }

        public double GetFahrenheitOffset()
        {
            return FAHRENHEIT_OFFSET;
        }

        public double GetFahrenheitOffset2()
        {
            // Código redundante: Misma lógica que el método anterior
            return 32.0;
        }

        // Mal patrón: Método que hace múltiples cosas
        public object GetAllFactors()
        {
            return new
            {
                temperature = new
                {
                    celsiusToFahrenheit = CELSIUS_TO_FAHRENHEIT_FACTOR,
                    fahrenheitOffset = FAHRENHEIT_OFFSET,
                    kelvinOffset = KELVIN_OFFSET
                },
                distance = new
                {
                    metersToFeet = METERS_TO_FEET_FACTOR,
                    kilometersToMiles = KILOMETERS_TO_MILES_FACTOR
                },
                weight = new
                {
                    kilogramsToPounds = KILOGRAMS_TO_POUNDS_FACTOR,
                    gramsToOunces = GRAMS_TO_OUNCES_FACTOR
                }
            };
        }
    }

    // Mal patrón: Clase redundante que hace lo mismo
    public class ConversionFactors
    {
        // Código redundante: Mismas constantes que ConversionConfig
        public const double CELSIUS_TO_FAHRENHEIT_FACTOR = 9.0 / 5.0;
        public const double FAHRENHEIT_OFFSET = 32.0;
        public const double KELVIN_OFFSET = 273.15;
        public const double METERS_TO_FEET_FACTOR = 3.28084;
        public const double KILOMETERS_TO_MILES_FACTOR = 0.621371;
        public const double KILOGRAMS_TO_POUNDS_FACTOR = 2.20462;
        public const double GRAMS_TO_OUNCES_FACTOR = 0.035274;

        // Mal patrón: Métodos que hacen lo mismo que ConversionConfig
        public double GetCelsiusToFahrenheitFactor()
        {
            return CELSIUS_TO_FAHRENHEIT_FACTOR;
        }

        public double GetFahrenheitOffset()
        {
            return FAHRENHEIT_OFFSET;
        }

        public double GetKelvinOffset()
        {
            return KELVIN_OFFSET;
        }
    }
} 