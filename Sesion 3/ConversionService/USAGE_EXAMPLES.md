# Ejemplos de Uso del Servicio de Conversión

Este documento contiene ejemplos prácticos de cómo usar el servicio REST de conversión de unidades.

## Endpoints Disponibles

### 1. Conversiones de Temperatura

#### Celsius a Fahrenheit
```bash
curl -X GET "http://localhost:5059/api/temperature/celsius-to-fahrenheit/25"
```
**Respuesta:**
```json
{
  "celsius": 25,
  "fahrenheit": 77,
  "message": "Conversión exitosa"
}
```

#### Fahrenheit a Celsius
```bash
curl -X GET "http://localhost:5059/api/temperature/fahrenheit-to-celsius/77"
```
**Respuesta:**
```json
{
  "fahrenheit": 77,
  "celsius": 25,
  "message": "Conversión exitosa"
}
```

#### Celsius a Kelvin
```bash
curl -X GET "http://localhost:5059/api/temperature/celsius-to-kelvin/25"
```
**Respuesta:**
```json
{
  "celsius": 25,
  "kelvin": 298.15,
  "message": "Conversión exitosa"
}
```

#### Kelvin a Celsius
```bash
curl -X GET "http://localhost:5059/api/temperature/kelvin-to-celsius/298.15"
```
**Respuesta:**
```json
{
  "kelvin": 298.15,
  "celsius": 25,
  "message": "Conversión exitosa"
}
```

### 2. Conversiones de Distancia

#### Metros a Pies
```bash
curl -X GET "http://localhost:5059/api/distance/meters-to-feet/10"
```
**Respuesta:**
```json
{
  "meters": 10,
  "feet": 32.8084,
  "message": "Conversión exitosa"
}
```

#### Pies a Metros
```bash
curl -X GET "http://localhost:5059/api/distance/feet-to-meters/32.8084"
```
**Respuesta:**
```json
{
  "feet": 32.8084,
  "meters": 10,
  "message": "Conversión exitosa"
}
```

#### Kilómetros a Millas
```bash
curl -X GET "http://localhost:5059/api/distance/kilometers-to-miles/10"
```
**Respuesta:**
```json
{
  "kilometers": 10,
  "miles": 6.21371,
  "message": "Conversión exitosa"
}
```

#### Millas a Kilómetros
```bash
curl -X GET "http://localhost:5059/api/distance/miles-to-kilometers/6.21371"
```
**Respuesta:**
```json
{
  "miles": 6.21371,
  "kilometers": 10,
  "message": "Conversión exitosa"
}
```

### 3. Conversiones de Peso

#### Kilogramos a Libras
```bash
curl -X GET "http://localhost:5059/api/weight/kilograms-to-pounds/10"
```
**Respuesta:**
```json
{
  "kilograms": 10,
  "pounds": 22.0462,
  "message": "Conversión exitosa"
}
```

#### Libras a Kilogramos
```bash
curl -X GET "http://localhost:5059/api/weight/pounds-to-kilograms/22.0462"
```
**Respuesta:**
```json
{
  "pounds": 22.0462,
  "kilograms": 10,
  "message": "Conversión exitosa"
}
```

#### Gramos a Onzas
```bash
curl -X GET "http://localhost:5059/api/weight/grams-to-ounces/100"
```
**Respuesta:**
```json
{
  "grams": 100,
  "ounces": 3.5274,
  "message": "Conversión exitosa"
}
```

#### Onzas a Gramos
```bash
curl -X GET "http://localhost:5059/api/weight/ounces-to-grams/3.5274"
```
**Respuesta:**
```json
{
  "ounces": 3.5274,
  "grams": 100,
  "message": "Conversión exitosa"
}
```

### 4. Conversión General (Controlador Principal)

#### Conversión de Temperatura
```bash
curl -X POST "http://localhost:5059/api/conversion/convert" \
  -H "Content-Type: application/json" \
  -d '{
    "value": 25,
    "fromUnit": "celsius",
    "toUnit": "fahrenheit",
    "description": "Conversión de temperatura de prueba",
    "userId": "usuario123"
  }'
```
**Respuesta:**
```json
{
  "result": {
    "fromValue": 25,
    "fromUnit": "celsius",
    "toUnit": "fahrenheit",
    "result": 77,
    "alternativeResult": 77
  },
  "message": "Conversión de temperatura usando múltiples servicios"
}
```

#### Conversión de Distancia
```bash
curl -X POST "http://localhost:5059/api/conversion/convert" \
  -H "Content-Type: application/json" \
  -d '{
    "value": 10,
    "fromUnit": "meters",
    "toUnit": "feet",
    "description": "Conversión de distancia de prueba",
    "userId": "usuario123"
  }'
```
**Respuesta:**
```json
{
  "result": {
    "fromValue": 10,
    "fromUnit": "meters",
    "toUnit": "feet",
    "result": 32.8084,
    "alternativeResult": 32.8084
  },
  "message": "Conversión de distancia usando múltiples servicios"
}
```

#### Conversión de Peso
```bash
curl -X POST "http://localhost:5059/api/conversion/convert" \
  -H "Content-Type: application/json" \
  -d '{
    "value": 10,
    "fromUnit": "kilograms",
    "toUnit": "pounds",
    "description": "Conversión de peso de prueba",
    "userId": "usuario123"
  }'
```
**Respuesta:**
```json
{
  "result": {
    "fromValue": 10,
    "fromUnit": "kilograms",
    "toUnit": "pounds",
    "result": 22.0462,
    "alternativeResult": 22.0462
  },
  "message": "Conversión de peso usando múltiples servicios"
}
```

### 5. Estado del Servicio

#### Verificar Health
```bash
curl -X GET "http://localhost:5059/api/conversion/health"
```
**Respuesta:**
```json
{
  "status": "OK",
  "services": [
    {"name": "TemperatureService1", "status": "OK"},
    {"name": "TemperatureService2", "status": "OK"},
    {"name": "DistanceService1", "status": "OK"},
    {"name": "DistanceService2", "status": "OK"},
    {"name": "WeightService1", "status": "OK"},
    {"name": "WeightService2", "status": "OK"}
  ],
  "timestamp": "2025-07-25T16:55:01.741652-06:00",
  "message": "Todos los servicios están funcionando correctamente"
}
```

## Notas sobre el Código Redundante

Como puedes ver en las respuestas del controlador principal (`/api/conversion/convert`), el servicio devuelve tanto `result` como `alternativeResult` con el mismo valor. Esto es intencional y demuestra el código redundante implementado:

- **result**: Calculado usando el primer servicio (ej: `_temperatureService1`)
- **alternativeResult**: Calculado usando el segundo servicio (ej: `_temperatureService2`)

Ambos servicios hacen exactamente lo mismo, pero están implementados de manera redundante para demostrar mal uso de patrones de diseño.

## Errores Comunes

### Error de Validación
Si no incluyes las propiedades `description` y `userId` en el endpoint `/api/conversion/convert`, obtendrás un error 400:

```bash
curl -X POST "http://localhost:5059/api/conversion/convert" \
  -H "Content-Type: application/json" \
  -d '{"value": 25, "fromUnit": "celsius", "toUnit": "fahrenheit"}'
```

**Respuesta:**
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "UserId": ["The UserId field is required."],
    "Description": ["The Description field is required."]
  }
}
```

Esto es intencional para demostrar propiedades innecesarias en el modelo de datos. 