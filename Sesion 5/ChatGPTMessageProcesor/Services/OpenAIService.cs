using System.Text;
using System.Text.Json;
using GeminiMessageProcessor.Models;

namespace GeminiMessageProcessor.Services;

public class OpenAIService : IOpenAIService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<OpenAIService> _logger;
    private readonly string _apiKey;
    private readonly string _model;
    private readonly string _baseUrl = "https://api.openai.com/v1/chat/completions";

    public OpenAIService(HttpClient httpClient, IConfiguration configuration, ILogger<OpenAIService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;
        _apiKey = _configuration["OpenAI:ApiKey"] ?? throw new InvalidOperationException("OpenAI API Key no configurada");
        _model = _configuration["OpenAI:Model"] ?? "gpt-3.5-turbo";
        
        // Configurar headers para OpenAI
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
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

        var response = await CallOpenAIAsync(prompt);
        
        _logger.LogInformation("OpenAI clasificación - Mensaje: {Message}, Respuesta: {Response}", message, response);
        
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

        var response = await CallOpenAIAsync(prompt);
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

        var response = await CallOpenAIAsync(prompt);
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

        var response = await CallOpenAIAsync(prompt);
        _logger.LogInformation("Validación de información de producto - Mensaje: {Message}, Resultado: {Result}", message, response);
        
        return response.Trim().ToUpper();
    }

    private async Task<string> CallOpenAIAsync(string prompt)
    {
        var requestBody = new
        {
            model = _model,
            messages = new[]
            {
                new { role = "user", content = prompt }
            },
            max_tokens = 150,
            temperature = 0.1
        };

        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync(_baseUrl, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var openAIResponse = JsonSerializer.Deserialize<OpenAIResponse>(responseContent);
                
                var result = openAIResponse?.choices?.FirstOrDefault()?.message?.content ?? "Error";
                _logger.LogInformation("Respuesta de OpenAI: {Response}", result);
                return result;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                _logger.LogError("Error en llamada a OpenAI: {StatusCode}, {Error}", response.StatusCode, errorContent);
                return "Error al procesar la solicitud";
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Excepción al llamar a OpenAI");
            return "Error al procesar la solicitud";
        }
    }
}

// Clases para deserializar la respuesta de OpenAI
public class OpenAIResponse
{
    public Choice[]? choices { get; set; }
}

public class Choice
{
    public Message? message { get; set; }
}

public class Message
{
    public string? content { get; set; }
} 