# Servicio de Conversión de Unidades

Este es un servicio REST en C# que proporciona utilidades de conversión entre temperaturas, distancias y unidades de peso. **Este proyecto está diseñado intencionalmente con mal uso de patrones y código redundante para propósitos educativos.**

## Características

### Conversiones de Temperatura
- Celsius ↔ Fahrenheit
- Celsius ↔ Kelvin
- Kelvin ↔ Celsius

### Conversiones de Distancia
- Metros ↔ Pies
- Kilómetros ↔ Millas

### Conversiones de Peso
- Kilogramos ↔ Libras
- Gramos ↔ Onzas

## Endpoints Disponibles

### Controladores Específicos

#### TemperatureController
- `GET /api/temperature/celsius-to-fahrenheit/{celsius}`
- `GET /api/temperature/fahrenheit-to-celsius/{fahrenheit}`
- `GET /api/temperature/celsius-to-kelvin/{celsius}`
- `GET /api/temperature/kelvin-to-celsius/{kelvin}`
- `POST /api/temperature/convert-all`

#### DistanceController
- `GET /api/distance/meters-to-feet/{meters}`
- `GET /api/distance/feet-to-meters/{feet}`
- `GET /api/distance/kilometers-to-miles/{kilometers}`
- `GET /api/distance/miles-to-kilometers/{miles}`
- `POST /api/distance/convert-all`

#### WeightController
- `GET /api/weight/kilograms-to-pounds/{kilograms}`
- `GET /api/weight/pounds-to-kilograms/{pounds}`
- `GET /api/weight/grams-to-ounces/{grams}`
- `GET /api/weight/ounces-to-grams/{ounces}`
- `POST /api/weight/convert-all`

### Controlador Principal

#### ConversionController
- `POST /api/conversion/convert` - Conversión general
- `GET /api/conversion/health` - Estado del servicio

## Ejemplos de Uso

### Conversión de Temperatura
```bash
curl -X GET "https://localhost:7001/api/temperature/celsius-to-fahrenheit/25"
```

### Conversión General
```bash
curl -X POST "https://localhost:7001/api/conversion/convert" \
  -H "Content-Type: application/json" \
  -d '{
    "value": 25,
    "fromUnit": "celsius",
    "toUnit": "fahrenheit"
  }'
```

### Verificar Estado del Servicio
```bash
curl -X GET "https://localhost:7001/api/conversion/health"
```

## Patrones de Diseño Incorrectos Implementados

### 1. Código Redundante
- Múltiples métodos que hacen exactamente lo mismo
- Constantes duplicadas en diferentes clases
- Lógica de conversión repetida en múltiples lugares

### 2. Violación del Principio de Responsabilidad Única
- Controladores con lógica de negocio
- Servicios con múltiples responsabilidades
- Middleware que hace más de lo necesario

### 3. Múltiples Instancias Innecesarias
- Varias instancias del mismo servicio
- Múltiples loggers para el mismo propósito
- Registros duplicados en el contenedor de dependencias

### 4. Métodos que Hacen Múltiples Cosas
- Métodos con lógica compleja y múltiples responsabilidades
- Validaciones repetidas
- Código anidado excesivo

### 5. Configuración Redundante
- Clases de configuración duplicadas
- Propiedades innecesarias en modelos
- Middleware redundante

## Cómo Ejecutar

1. Asegúrate de tener .NET 8.0 instalado
2. Navega al directorio del proyecto
3. Ejecuta: `dotnet run`
4. El servicio estará disponible en `https://localhost:7001`
5. La documentación Swagger estará en `https://localhost:7001/swagger`

## Estructura del Proyecto

```
ConversionService/
├── Controllers/
│   ├── TemperatureController.cs
│   ├── DistanceController.cs
│   ├── WeightController.cs
│   └── ConversionController.cs
├── Services/
│   ├── TemperatureService.cs
│   ├── DistanceService.cs
│   └── WeightService.cs
├── Models/
│   └── ConversionConfig.cs
├── Middleware/
│   └── LoggingMiddleware.cs
├── Program.cs
└── README.md
```

## Notas Importantes

⚠️ **ADVERTENCIA**: Este proyecto está diseñado intencionalmente con mal uso de patrones de diseño y código redundante. No debe usarse como referencia para buenas prácticas de desarrollo.

Los problemas de diseño incluyen:
- Código duplicado
- Violación de principios SOLID
- Múltiples responsabilidades en una sola clase
- Configuración redundante
- Middleware innecesario

Este proyecto sirve como ejemplo de lo que NO se debe hacer en un proyecto real. 