# Documentación Completa: GeminiService.cs

## Descripción General

El archivo `GeminiService.cs` es el núcleo de la integración con la API de Google Gemini en el proyecto. Esta clase implementa la interfaz `IGeminiService` y proporciona todas las funcionalidades de procesamiento de lenguaje natural utilizando la inteligencia artificial de Gemini.

## Ubicación del Archivo
```
GeminiMessageProcessor/
└── Services/
    └── GeminiService.cs
```

## Dependencias y Usings

```csharp
using System.Text;
using System.Text.Json;
using GeminiMessageProcessor.Models;
```

- **System.Text**: Para codificación de caracteres en las peticiones HTTP
- **System.Text.Json**: Para serialización/deserialización de JSON
- **GeminiMessageProcessor.Models**: Para acceder a los modelos de datos del proyecto

## Estructura de la Clase

### Constructor y Configuración

```csharp
public class GeminiService : IGeminiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<GeminiService> _logger;
    private readonly string _apiKey;
    private readonly string _baseUrl = "https://generativelanguage.googleapis.com/v1/models/gemini-1.5-flash:generateContent";
```

#### Campos Privados:
- **`_httpClient`**: Cliente HTTP para realizar peticiones a la API de Gemini
- **`_configuration`**: Configuración de la aplicación (para obtener la API key)
- **`_logger`**: Logger para registrar eventos y errores
- **`_apiKey`**: Clave de API de Gemini almacenada en memoria
- **`_baseUrl`**: URL base de la API de Gemini (modelo gemini-1.5-flash)

#### Constructor:
```csharp
public GeminiService(HttpClient httpClient, IConfiguration configuration, ILogger<GeminiService> logger)
{
    _httpClient = httpClient;
    _configuration = configuration;
    _logger = logger;
    _apiKey = _configuration["Gemini:ApiKey"] ?? throw new InvalidOperationException("Gemini API Key no configurada");
}
```

**Inyección de Dependencias:**
- Recibe las dependencias a través del constructor (patrón DI)
- Valida que la API key esté configurada, lanzando una excepción si no existe

## Métodos Públicos

### 1. ClassifyMessageAsync(string message)

**Propósito:** Clasifica un mensaje en una de las tres categorías predefinidas.

**Parámetros:**
- `message` (string): El mensaje a clasificar

**Retorna:** `Task<MessageCategory>` - La categoría clasificada

**Funcionamiento:**

#### Prompt de Clasificación:
```csharp
var prompt = $@"
Analiza el siguiente mensaje y clasifícalo en una de estas categorías:

CATEGORÍA 1 - CREACIÓN DE USUARIO:
- El mensaje pide crear un usuario, cuenta, perfil o registro
- Contiene palabras como: crear, registrar, nuevo usuario, cuenta, perfil, inscribir
- Ejemplos: ""quiero crear un usuario"", ""necesito una cuenta"", ""registrarme"", ""inscribir usuario""

CATEGORÍA 2 - INFORMACIÓN DE PRODUCTO:
- El mensaje pide información sobre productos, servicios o catálogos
- Contiene palabras como: información, producto, servicio, catálogo, detalles, precios, características
- Ejemplos: ""información del producto"", ""detalles del servicio"", ""catálogo"", ""precios""

CATEGORÍA 3 - OTROS:
- Cualquier otra consulta que no sea creación de usuario ni información de producto
- Incluye consultas generales, soporte, quejas, sugerencias, etc.

MENSAJE A CLASIFICAR: ""{message}""

Responde ÚNICAMENTE con el número de la categoría (1, 2 o 3).";
```

#### Procesamiento de Respuesta:
```csharp
var response = await CallGeminiApiAsync(prompt);
var cleanResponse = response.Trim().ToLower();

if (cleanResponse.Contains("1") || cleanResponse.Contains("uno"))
    return MessageCategory.UserCreation;
else if (cleanResponse.Contains("2") || cleanResponse.Contains("dos"))
    return MessageCategory.ProductInformation;
else
    return MessageCategory.Other;
```

**Características:**
- Utiliza un prompt estructurado con ejemplos claros
- Maneja respuestas en español ("uno", "dos") y números
- Registra la clasificación en los logs para debugging

### 2. ExtractUserNameAsync(string message)

**Propósito:** Extrae el nombre del usuario de un mensaje de creación de usuario.

**Parámetros:**
- `message` (string): El mensaje que contiene información del usuario

**Retorna:** `Task<string>` - El nombre extraído del usuario

**Funcionamiento:**

#### Prompt de Extracción:
```csharp
var prompt = $@"
Extrae el nombre del usuario del siguiente mensaje que pide crear un usuario.

Reglas:
1. Si el mensaje menciona un nombre específico, úsalo exactamente como aparece
2. Si hay un email en el mensaje, extrae el nombre de la parte antes del @
3. Si no hay un nombre claro, responde 'Usuario'
4. Si hay múltiples nombres, usa el primero mencionado
5. Limpia el nombre de caracteres especiales innecesarios

Ejemplos:
- ""Quiero crear un usuario llamado Juan Pérez"" → Juan Pérez
- ""Necesito una cuenta para María"" → María
- ""Crear usuario con email juan.perez@email.com"" → juan.perez
- ""Registrarme como Ana María López"" → Ana María López
- ""Crear usuario"" → Usuario

Mensaje: ""{message}""

Responde solo con el nombre del usuario.";
```

**Características:**
- Maneja múltiples formatos de entrada (nombres completos, emails, nombres simples)
- Extrae nombres de direcciones de email
- Proporciona un valor por defecto ("Usuario") cuando no hay información clara
- Limpia la respuesta con `Trim()`

### 3. ValidateUserCreationInfoAsync(string message)

**Propósito:** Valida si un mensaje de creación de usuario contiene información suficiente.

**Parámetros:**
- `message` (string): El mensaje a validar

**Retorna:** `Task<string>` - "COMPLETO" o "FALTA_NOMBRE"

**Funcionamiento:**

#### Prompt de Validación:
```csharp
var prompt = $@"
Analiza el siguiente mensaje de creación de usuario y determina si falta información esencial.

Información necesaria para crear un usuario:
- Nombre del usuario (puede ser nombre completo, nombre de pila, o email)

Reglas de validación:
1. Si el mensaje contiene un nombre específico, email, o identificación clara del usuario → ""COMPLETO""
2. Si el mensaje solo dice ""crear usuario"", ""registrarme"", ""necesito una cuenta"" sin más detalles → ""FALTA_NOMBRE""
3. Si el mensaje es muy vago o genérico → ""FALTA_NOMBRE""

Ejemplos:
- ""Quiero crear un usuario llamado Juan Pérez"" → COMPLETO
- ""Crear usuario con email maria@email.com"" → COMPLETO
- ""Necesito una cuenta"" → FALTA_NOMBRE
- ""Registrarme"" → FALTA_NOMBRE
- ""Crear usuario"" → FALTA_NOMBRE

Mensaje: ""{message}""

Responde únicamente con: COMPLETO o FALTA_NOMBRE";
```

**Características:**
- Valida la completitud de la información
- Distingue entre mensajes completos e incompletos
- Proporciona ejemplos claros para el modelo de IA

### 4. ValidateProductInfoAsync(string message)

**Propósito:** Valida si un mensaje de solicitud de información de producto contiene detalles suficientes.

**Parámetros:**
- `message` (string): El mensaje a validar

**Retorna:** `Task<string>` - "COMPLETO" o "FALTA_DETALLES"

**Funcionamiento:**

#### Prompt de Validación:
```csharp
var prompt = $@"
Analiza el siguiente mensaje de solicitud de información de producto y determina si falta información específica.

Información útil para proporcionar información de producto:
- Nombre específico del producto
- Tipo de producto o categoría
- Características específicas de interés

Reglas de validación:
1. Si el mensaje menciona un producto específico, categoría, o características → ""COMPLETO""
2. Si el mensaje es muy genérico como ""información de productos"", ""catálogo"", ""precios"" sin especificar → ""FALTA_DETALLES""
3. Si el mensaje es vago o no especifica qué información necesita → ""FALTA_DETALLES""

Ejemplos:
- ""Información sobre el iPhone 15"" → COMPLETO
- ""Detalles del servicio de hosting"" → COMPLETO
- ""Precios de laptops"" → COMPLETO
- ""Información de productos"" → FALTA_DETALLES
- ""Necesito el catálogo"" → FALTA_DETALLES
- ""¿Qué productos tienen?"" → FALTA_DETALLES

Mensaje: ""{message}""

Responde únicamente con: COMPLETO o FALTA_DETALLES";
```

**Características:**
- Evalúa la especificidad de la solicitud
- Distingue entre solicitudes específicas y genéricas
- Ayuda a proporcionar información más útil al usuario

## Método Privado

### CallGeminiApiAsync(string prompt)

**Propósito:** Método interno que realiza la comunicación con la API de Gemini.

**Parámetros:**
- `prompt` (string): El prompt a enviar a Gemini

**Retorna:** `Task<string>` - La respuesta de Gemini

**Funcionamiento:**

#### 1. Preparación de la Petición:
```csharp
var requestBody = new
{
    contents = new[]
    {
        new
        {
            parts = new[]
            {
                new { text = prompt }
            }
        }
    }
};

var json = JsonSerializer.Serialize(requestBody);
var content = new StringContent(json, Encoding.UTF8, "application/json");
var url = $"{_baseUrl}?key={_apiKey}";
```

#### 2. Estructura de la Petición:
- **Modelo**: gemini-1.5-flash (modelo rápido y eficiente)
- **Formato**: JSON con estructura específica de Gemini
- **Autenticación**: API key como parámetro de query

#### 3. Manejo de Respuesta:
```csharp
var response = await _httpClient.PostAsync(url, content);

if (response.IsSuccessStatusCode)
{
    var responseContent = await response.Content.ReadAsStringAsync();
    var geminiResponse = JsonSerializer.Deserialize<GeminiResponse>(responseContent);
    
    var result = geminiResponse?.candidates?.FirstOrDefault()?.content?.parts?.FirstOrDefault()?.text ?? "Error";
    _logger.LogInformation("Respuesta de Gemini: {Response}", result);
    return result;
}
```

#### 4. Manejo de Errores:
```csharp
else
{
    var errorContent = await response.Content.ReadAsStringAsync();
    _logger.LogError("Error en llamada a Gemini: {StatusCode}, {Error}", response.StatusCode, errorContent);
    return "Error al procesar la solicitud";
}
```

**Características:**
- Manejo robusto de errores HTTP
- Logging detallado para debugging
- Deserialización segura con null-coalescing operator
- Timeout y excepciones manejadas

## Clases de Respuesta

### GeminiResponse
```csharp
public class GeminiResponse
{
    public Candidate[]? candidates { get; set; }
}
```

### Candidate
```csharp
public class Candidate
{
    public Content? content { get; set; }
}
```

### Content
```csharp
public class Content
{
    public Part[]? parts { get; set; }
}
```

### Part
```csharp
public class Part
{
    public string? text { get; set; }
}
```

**Nota:** Estas clases están definidas al final del archivo para deserializar la respuesta JSON de Gemini.

## Patrones de Diseño Utilizados

### 1. **Inyección de Dependencias (DI)**
- Constructor recibe dependencias externas
- Facilita testing y mantenimiento

### 2. **Strategy Pattern**
- Diferentes prompts para diferentes tareas
- Fácil extensión para nuevas funcionalidades

### 3. **Template Method**
- Estructura común en todos los métodos públicos
- Llamada a `CallGeminiApiAsync` como template

### 4. **Error Handling**
- Manejo centralizado de errores
- Logging consistente

## Consideraciones de Rendimiento

### 1. **Optimización de Prompts**
- Prompts concisos pero informativos
- Instrucciones claras para respuestas específicas

### 2. **Caching**
- API key almacenada en memoria
- HttpClient reutilizado (configurado en DI)

### 3. **Async/Await**
- Operaciones asíncronas para no bloquear el hilo principal
- Manejo eficiente de recursos

## Logging y Debugging

### Niveles de Log:
- **Information**: Clasificaciones, extracciones, respuestas exitosas
- **Error**: Errores HTTP, excepciones

### Información Registrada:
- Mensajes de entrada
- Respuestas de Gemini
- Errores con detalles completos
- Resultados de validaciones

## Configuración Requerida

### appsettings.json:
```json
{
  "Gemini": {
    "ApiKey": "TU_API_KEY_DE_GEMINI_AQUI"
  }
}
```

### Program.cs (registro del servicio):
```csharp
builder.Services.AddScoped<IGeminiService, GeminiService>();
builder.Services.AddHttpClient();
```

## Casos de Uso

### 1. **Clasificación de Mensajes**
```csharp
var category = await geminiService.ClassifyMessageAsync("Quiero crear un usuario");
// Retorna: MessageCategory.UserCreation
```

### 2. **Extracción de Nombres**
```csharp
var userName = await geminiService.ExtractUserNameAsync("Crear usuario Juan Pérez");
// Retorna: "Juan Pérez"
```

### 3. **Validación de Información**
```csharp
var validation = await geminiService.ValidateUserCreationInfoAsync("Crear usuario");
// Retorna: "FALTA_NOMBRE"
```

## Ventajas del Diseño

### 1. **Modularidad**
- Cada método tiene una responsabilidad específica
- Fácil testing individual

### 2. **Extensibilidad**
- Fácil agregar nuevos métodos de validación
- Prompts configurables

### 3. **Mantenibilidad**
- Código bien estructurado y documentado
- Logging detallado

### 4. **Robustez**
- Manejo completo de errores
- Validaciones de entrada

## Limitaciones y Consideraciones

### 1. **Dependencia Externa**
- Requiere conexión a internet
- Depende de la disponibilidad de la API de Gemini

### 2. **Costo**
- Cada llamada a la API tiene un costo
- Debe monitorearse el uso

### 3. **Latencia**
- Las llamadas a la API pueden tomar tiempo
- Debe considerarse en el diseño de la UI

### 4. **Rate Limiting**
- La API de Gemini tiene límites de uso
- Debe implementarse retry logic si es necesario

## Mejoras Futuras Sugeridas

### 1. **Caching de Respuestas**
- Cachear respuestas similares
- Reducir llamadas a la API

### 2. **Retry Logic**
- Reintentos automáticos en caso de fallo
- Backoff exponencial

### 3. **Métricas**
- Monitoreo de uso de la API
- Métricas de rendimiento

### 4. **Configuración Dinámica**
- Prompts configurables desde archivo
- Ajuste de parámetros sin recompilar

## Conclusión

El `GeminiService.cs` es una implementación robusta y bien diseñada que proporciona una interfaz clara y funcional para interactuar con la API de Google Gemini. Su arquitectura modular, manejo de errores completo y logging detallado lo hacen ideal para aplicaciones de producción que requieren procesamiento de lenguaje natural.

La clase sigue las mejores prácticas de desarrollo en .NET y proporciona una base sólida para futuras extensiones y mejoras. 