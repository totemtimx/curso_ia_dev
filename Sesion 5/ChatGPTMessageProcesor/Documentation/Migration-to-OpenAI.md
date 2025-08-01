# Migración de Gemini a OpenAI

Este documento describe los cambios realizados para migrar el proyecto de Google Gemini a OpenAI (ChatGPT).

## Cambios Principales

### 1. Configuración (`appsettings.json`)

**Antes (Gemini):**
```json
{
  "Gemini": {
    "ApiKey": "tu-api-key-de-gemini"
  }
}
```

**Después (OpenAI):**
```json
{
  "OpenAI": {
    "ApiKey": "tu-api-key-de-openai-aqui",
    "Model": "gpt-3.5-turbo"
  }
}
```

### 2. Servicios

#### Renombrado de Archivos
- `Services/GeminiService.cs` → `Services/OpenAIService.cs`
- `Services/IGeminiService.cs` → `Services/IOpenAIService.cs`

#### Cambios en la Implementación

**Antes (Gemini):**
```csharp
public class GeminiService : IGeminiService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://generativelanguage.googleapis.com/v1/models/gemini-1.5-flash:generateContent";
    
    // Usaba HttpClient para llamadas REST a Gemini API
}
```

**Después (OpenAI):**
```csharp
public class OpenAIService : IOpenAIService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://api.openai.com/v1/chat/completions";
    
    // Usa HttpClient para llamadas REST a OpenAI API
}
```

### 3. Dependencias del Proyecto

**Removidas:**
- No se requieren dependencias adicionales para OpenAI (usa HttpClient nativo)

**Mantenidas:**
- `Microsoft.SemanticKernel` - Para orquestación de funciones
- `Swashbuckle.AspNetCore` - Para documentación de API

### 4. Formato de Llamadas a la API

#### Gemini API
```json
{
  "contents": [
    {
      "parts": [
        {
          "text": "prompt"
        }
      ]
    }
  ]
}
```

#### OpenAI API
```json
{
  "model": "gpt-3.5-turbo",
  "messages": [
    {
      "role": "user",
      "content": "prompt"
    }
  ],
  "max_tokens": 150,
  "temperature": 0.1
}
```

### 5. Respuestas de la API

#### Gemini Response
```json
{
  "candidates": [
    {
      "content": {
        "parts": [
          {
            "text": "respuesta"
          }
        ]
      }
    }
  ]
}
```

#### OpenAI Response
```json
{
  "choices": [
    {
      "message": {
        "content": "respuesta"
      }
    }
  ]
}
```

## Ventajas de la Migración

### 1. **Mejor Compatibilidad**
- OpenAI tiene mejor soporte para .NET
- Menos conflictos de dependencias
- Más librerías y herramientas disponibles

### 2. **Simplicidad**
- Usa HttpClient nativo de .NET
- No requiere dependencias adicionales complejas
- Código más limpio y mantenible

### 3. **Flexibilidad**
- Fácil cambio de modelos (gpt-3.5-turbo, gpt-4, etc.)
- Configuración más granular
- Mejor control sobre parámetros

### 4. **Costos**
- OpenAI puede ser más económico para ciertos casos de uso
- Mejor transparencia en precios
- Más opciones de modelos según necesidades

## Configuración Requerida

### 1. Obtener API Key de OpenAI
1. Ve a [OpenAI Platform](https://platform.openai.com/)
2. Crea una cuenta o inicia sesión
3. Ve a "API Keys"
4. Crea una nueva API key
5. Copia la key

### 2. Configurar el Proyecto
1. Edita `appsettings.json`
2. Reemplaza `"tu-api-key-de-openai-aqui"` con tu API key real
3. Opcionalmente, cambia el modelo si deseas usar gpt-4

### 3. Verificar Funcionamiento
1. Ejecuta `dotnet restore`
2. Ejecuta `dotnet build`
3. Ejecuta `dotnet run`
4. Prueba con los ejemplos en `Examples/test-requests.http`

## Funcionalidades Mantenidas

- ✅ Clasificación automática de mensajes
- ✅ Extracción de nombres de usuario
- ✅ Validación de información
- ✅ Almacenamiento de archivos
- ✅ Integración con Semantic Kernel
- ✅ Logging y manejo de errores
- ✅ Documentación con Swagger

## Notas Importantes

1. **API Key**: Asegúrate de tener créditos suficientes en tu cuenta de OpenAI
2. **Modelo**: El proyecto usa `gpt-3.5-turbo` por defecto, pero puedes cambiarlo a `gpt-4` si tienes acceso
3. **Costos**: Monitorea el uso de la API para controlar costos
4. **Rate Limits**: OpenAI tiene límites de velocidad, considera implementar retry logic si es necesario

## Próximos Pasos

1. **Testing**: Ejecuta pruebas exhaustivas con diferentes tipos de mensajes
2. **Monitoreo**: Implementa logging para monitorear el uso de la API
3. **Optimización**: Ajusta parámetros como `max_tokens` y `temperature` según necesidades
4. **Backup**: Considera mantener una versión con Gemini como respaldo 