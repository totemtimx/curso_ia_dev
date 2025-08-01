namespace ConversionService.Services
{
    // Mal patrón: Clase con responsabilidades múltiples
    public class DistanceService
    {
        // Mal patrón: Variables globales innecesarias
        private readonly double _metersToFeetFactor = 3.28084;
        private readonly double _kilometersToMilesFactor = 0.621371;

        // Mal patrón: Métodos que hacen lo mismo pero con nombres diferentes
        public double ConvertMetersToFeet(double meters)
        {
            return meters * _metersToFeetFactor;
        }

        public double MetersToFeet(double meters)
        {
            // Código redundante: Misma lógica que el método anterior
            return meters * 3.28084;
        }

        public double ConvertFeetToMeters(double feet)
        {
            return feet / _metersToFeetFactor;
        }

        public double FeetToMeters(double feet)
        {
            // Código redundante: Misma lógica que el método anterior
            return feet / 3.28084;
        }

        public double ConvertKilometersToMiles(double kilometers)
        {
            return kilometers * _kilometersToMilesFactor;
        }

        public double KilometersToMiles(double kilometers)
        {
            // Código redundante: Misma lógica que el método anterior
            return kilometers * 0.621371;
        }

        public double ConvertMilesToKilometers(double miles)
        {
            return miles / _kilometersToMilesFactor;
        }

        public double MilesToKilometers(double miles)
        {
            // Código redundante: Misma lógica que el método anterior
            return miles / 0.621371;
        }

        // Mal patrón: Método que hace múltiples cosas
        public object ConvertAll(double value, string fromUnit, string toUnit)
        {
            double result = 0;
            string message = "";

            if (fromUnit.ToLower() == "meters" && toUnit.ToLower() == "feet")
            {
                result = ConvertMetersToFeet(value);
                message = "Conversión de Metros a Pies";
            }
            else if (fromUnit.ToLower() == "feet" && toUnit.ToLower() == "meters")
            {
                result = ConvertFeetToMeters(value);
                message = "Conversión de Pies a Metros";
            }
            else if (fromUnit.ToLower() == "kilometers" && toUnit.ToLower() == "miles")
            {
                result = ConvertKilometersToMiles(value);
                message = "Conversión de Kilómetros a Millas";
            }
            else if (fromUnit.ToLower() == "miles" && toUnit.ToLower() == "kilometers")
            {
                result = ConvertMilesToKilometers(value);
                message = "Conversión de Millas a Kilómetros";
            }
            else
            {
                message = "Conversión no soportada";
            }

            return new { fromValue = value, fromUnit, toUnit, result, message };
        }
    }
} 