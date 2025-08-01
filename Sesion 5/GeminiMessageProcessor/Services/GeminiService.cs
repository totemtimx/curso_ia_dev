using System.Text;
using System.Text.Json;
using GeminiMessageProcessor.Models;

namespace GeminiMessageProcessor.Services;

public class GeminiService : IGeminiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<GeminiService> _logger;
    private readonly string _apiKey;
    private readonly string _baseUrl = "https://generativelanguage.googleapis.com/v1/models/gemini-1.5-flash:generateContent";

    public GeminiService(HttpClient httpClient, IConfiguration configuration, ILogger<GeminiService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
        _apiKey = _configuration["Gemini:ApiKey"] ?? throw new InvalidOperationException("Gemini API Key no configurada");
    }

    public async Task<MessageCategory> ClassifyMessageAsync(string message)
    {
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

        var response = await CallGeminiApiAsync(prompt);
        
        _logger.LogInformation("Gemini clasificación - Mensaje: {Message}, Respuesta: {Response}", message, response);
        
        // Limpiar la respuesta y buscar el número
        var cleanResponse = response.Trim().ToLower();
        
        if (cleanResponse.Contains("1") || cleanResponse.Contains("uno"))
        {
            _logger.LogInformation("Clasificado como: UserCreation");
            return MessageCategory.UserCreation;
        }
        else if (cleanResponse.Contains("2") || cleanResponse.Contains("dos"))
        {
            _logger.LogInformation("Clasificado como: ProductInformation");
            return MessageCategory.ProductInformation;
        }
        else
        {
            _logger.LogInformation("Clasificado como: Other");
            return MessageCategory.Other;
        }
    }

    public async Task<string> ExtractUserNameAsync(string message)
    {
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

        var response = await CallGeminiApiAsync(prompt);
        _logger.LogInformation("Extracción de nombre - Mensaje: {Message}, Nombre extraído: {Name}", message, response);
        
        return response.Trim();
    }

    public async Task<string> ValidateUserCreationInfoAsync(string message)
    {
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

        var response = await CallGeminiApiAsync(prompt);
        _logger.LogInformation("Validación de información de usuario - Mensaje: {Message}, Resultado: {Result}", message, response);
        
        return response.Trim().ToUpper();
    }

    public async Task<string> ValidateProductInfoAsync(string message)
    {
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

        var response = await CallGeminiApiAsync(prompt);
        _logger.LogInformation("Validación de información de producto - Mensaje: {Message}, Resultado: {Result}", message, response);
        
        return response.Trim().ToUpper();
    }

    private async Task<string> CallGeminiApiAsync(string prompt)
    {
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
        
        try
        {
            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var geminiResponse = JsonSerializer.Deserialize<GeminiResponse>(responseContent);
                
                var result = geminiResponse?.candidates?.FirstOrDefault()?.content?.parts?.FirstOrDefault()?.text ?? "Error";
                _logger.LogInformation("Respuesta de Gemini: {Response}", result);
                return result;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Error en llamada a Gemini: {StatusCode}, {Error}", response.StatusCode, errorContent);
                return "Error al procesar la solicitud";
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Excepción al llamar a Gemini");
            return "Error al procesar la solicitud";
        }
    }
}

// Clases para deserializar la respuesta de Gemini
public class GeminiResponse
{
    public Candidate[]? candidates { get; set; }
}

public class Candidate
{
    public Content? content { get; set; }
}

public class Content
{
    public Part[]? parts { get; set; }
}

public class Part
{
    public string? text { get; set; }
} 