namespace ConversionService.Services
{
    // Mal patrón: Clase con responsabilidades múltiples
    public class WeightService
    {
        // Mal patrón: Variables globales innecesarias
        private readonly double _kilogramsToPoundsFactor = 2.20462;
        private readonly double _gramsToOuncesFactor = 0.035274;

        // Mal patrón: Métodos que hacen lo mismo pero con nombres diferentes
        public double ConvertKilogramsToPounds(double kilograms)
        {
            return kilograms * _kilogramsToPoundsFactor;
        }

        public double KilogramsToPounds(double kilograms)
        {
            // Código redundante: Misma lógica que el método anterior
            return kilograms * 2.20462;
        }

        public double ConvertPoundsToKilograms(double pounds)
        {
            return pounds / _kilogramsToPoundsFactor;
        }

        public double PoundsToKilograms(double pounds)
        {
            // Código redundante: Misma lógica que el método anterior
            return pounds / 2.20462;
        }

        public double ConvertGramsToOunces(double grams)
        {
            return grams * _gramsToOuncesFactor;
        }

        public double GramsToOunces(double grams)
        {
            // Código redundante: Misma lógica que el método anterior
            return grams * 0.035274;
        }

        public double ConvertOuncesToGrams(double ounces)
        {
            return ounces / _gramsToOuncesFactor;
        }

        public double OuncesToGrams(double ounces)
        {
            // Código redundante: Misma lógica que el método anterior
            return ounces / 0.035274;
        }

        // Mal patrón: Método que hace múltiples cosas
        public object ConvertAll(double value, string fromUnit, string toUnit)
        {
            double result = 0;
            string message = "";

            if (fromUnit.ToLower() == "kilograms" && toUnit.ToLower() == "pounds")
            {
                result = ConvertKilogramsToPounds(value);
                message = "Conversión de Kilogramos a Libras";
            }
            else if (fromUnit.ToLower() == "pounds" && toUnit.ToLower() == "kilograms")
            {
                result = ConvertPoundsToKilograms(value);
                message = "Conversión de Libras a Kilogramos";
            }
            else if (fromUnit.ToLower() == "grams" && toUnit.ToLower() == "ounces")
            {
                result = ConvertGramsToOunces(value);
                message = "Conversión de Gramos a Onzas";
            }
            else if (fromUnit.ToLower() == "ounces" && toUnit.ToLower() == "grams")
            {
                result = ConvertOuncesToGrams(value);
                message = "Conversión de Onzas a Gramos";
            }
            else
            {
                message = "Conversión no soportada";
            }

            return new { fromValue = value, fromUnit, toUnit, result, message };
        }
    }
} 