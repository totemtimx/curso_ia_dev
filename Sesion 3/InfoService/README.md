# Servicio de Información REST

Este es un proyecto de servicios REST en C# que proporciona información sobre la fecha y hora actual del sistema.

## Características

- **Endpoint GET**: `/api/info/info` - Devuelve la fecha y hora actual del sistema
- **Tecnología**: ASP.NET Core Web API
- **Documentación**: Swagger/OpenAPI integrado

## Estructura del Proyecto

```
InfoService/
├── Controllers/
│   └── InfoController.cs          # Controlador principal
├── Services/
│   ├── IInfoService.cs           # Interfaz del servicio
│   └── InfoService.cs            # Implementación del servicio
├── Models/
│   └── InfoResponse.cs           # Modelo de respuesta
└── Program.cs                    # Configuración de la aplicación
```

## Respuesta del API

El endpoint `/api/info/info` devuelve un JSON con la siguiente estructura:

```json
{
  "fecha": "2024-01-15",
  "hora": "14:30:25",
  "fechaHoraCompleta": "2024-01-15 14:30:25",
  "timestamp": 637447890250000000,
  "zonaHoraria": "(UTC-06:00) Central Time (US & Canada)"
}
```

## Cómo Ejecutar

1. Navega al directorio del proyecto:
   ```bash
   cd InfoService
   ```

2. Restaura las dependencias:
   ```bash
   dotnet restore
   ```

3. Ejecuta el proyecto:
   ```bash
   dotnet run
   ```

4. Abre tu navegador y ve a:
   - API: `https://localhost:7001/api/info/info`
   - Swagger UI: `https://localhost:7001/swagger`

## Endpoints Disponibles

- `GET /api/info/info` - Obtiene la fecha y hora actual del sistema 