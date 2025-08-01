using Microsoft.SemanticKernel;
using System.ComponentModel;
using GeminiMessageProcessor.Models;

namespace GeminiMessageProcessor.Services;

public class MessageProcessorService : IMessageProcessorService
{
    private readonly IOpenAIService _openAIService;
    private readonly IFileService _fileService;
    private readonly Kernel _kernel;

    public MessageProcessorService(IOpenAIService openAIService, IFileService fileService)
    {
        _openAIService = openAIService;
        _fileService = fileService;
        _kernel = Kernel.CreateBuilder().Build();
        
        // Registrar las funciones nativas como actividades de Semantic Kernel
        _kernel.ImportPluginFromObject(new FileOperations(_fileService), "file");
    }

    public async Task<MessageResponse> ProcessMessageAsync(MessageRequest request)
    {
        try
        {
            // Clasificar el mensaje usando OpenAI
            var category = await _openAIService.ClassifyMessageAsync(request.Message);
            
            string response;
            string categoryName;

            switch (category)
            {
                case MessageCategory.UserCreation:
                    // Validar si falta información para crear el usuario
                    var userValidation = await _openAIService.ValidateUserCreationInfoAsync(request.Message);
                    
                    if (userValidation == "FALTA_NOMBRE")
                    {
                        response = "Para crear un usuario necesito que me proporciones el nombre. Por favor, indícame el nombre completo o email del usuario que deseas crear.";
                        categoryName = "Solicitud de Información";
                    }
                    else
                    {
                        // Extraer nombre del usuario
                        var userName = await _openAIService.ExtractUserNameAsync(request.Message);
                        
                        // Usar Semantic Kernel para ejecutar la actividad de guardar usuario
                        var userResult = await _kernel.InvokeAsync("file", "SaveUser", new() 
                        { 
                            ["userName"] = userName 
                        });
                        
                        response = $"Usuario {userName} creado exitosamente.";
                        categoryName = "Creación de Usuario";
                    }
                    break;

                case MessageCategory.ProductInformation:
                    // Validar si falta información específica del producto
                    var productValidation = await _openAIService.ValidateProductInfoAsync(request.Message);
                    
                    if (productValidation == "FALTA_DETALLES")
                    {
                        response = "Para proporcionarte la información más útil, necesito que me especifiques qué producto o servicio te interesa. Por favor, indícame el nombre del producto, categoría o características específicas que buscas.";
                        categoryName = "Solicitud de Información";
                    }
                    else
                    {
                        response = "Gracias por solicitar la información. En breve recibirá un correo con la información solicitada.";
                        categoryName = "Información de Producto";
                    }
                    break;

                default:
                    // Guardar mensaje pendiente usando Semantic Kernel
                    var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    var pendingResult = await _kernel.InvokeAsync("file", "SavePendingMessage", new() 
                    { 
                        ["message"] = request.Message,
                        ["timestamp"] = timestamp
                    });
                    
                    response = "Su mensaje ha sido recibido y será atendido en el transcurso del día.";
                    categoryName = "Otros";
                    break;
            }

            return new MessageResponse
            {
                Response = response,
                Category = categoryName,
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new MessageResponse
            {
                Response = $"Error al procesar el mensaje: {ex.Message}",
                Category = "Error",
                Success = false
            };
        }
    }
}

// Clase para las operaciones de archivo que se registran como actividades en Semantic Kernel
public class FileOperations
{
    private readonly IFileService _fileService;

    public FileOperations(IFileService fileService)
    {
        _fileService = fileService;
    }

    [KernelFunction, Description("Guarda un usuario en la carpeta de usuarios")]
    public async Task<string> SaveUser([Description("Nombre del usuario a guardar")] string userName)
    {
        await _fileService.SaveUserAsync(userName);
        return $"Usuario {userName} guardado correctamente";
    }

    [KernelFunction, Description("Guarda un mensaje pendiente en la carpeta de pendientes")]
    public async Task<string> SavePendingMessage(
        [Description("Mensaje a guardar")] string message,
        [Description("Timestamp para el nombre del archivo")] string timestamp)
    {
        await _fileService.SavePendingMessageAsync(message, timestamp);
        return "Mensaje pendiente guardado correctamente";
    }
} 