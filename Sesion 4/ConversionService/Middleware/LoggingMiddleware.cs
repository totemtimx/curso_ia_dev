using System.Text;

namespace ConversionService.Middleware
{
    // Mal patrón: Middleware con responsabilidades múltiples
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        // Mal patrón: Múltiples loggers innecesarios
        private readonly ILogger<LoggingMiddleware> _logger1;
        private readonly ILogger<LoggingMiddleware> _logger2;
        private readonly ILogger<LoggingMiddleware> _logger3;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            
            // Código redundante: Crear múltiples loggers innecesarios
            _logger1 = logger;
            _logger2 = logger;
            _logger3 = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Código redundante: Múltiples logs del mismo evento
            _logger.LogInformation("Iniciando request: {Method} {Path}", context.Request.Method, context.Request.Path);
            _logger1.LogInformation("Request iniciado: {Method} {Path}", context.Request.Method, context.Request.Path);
            _logger2.LogInformation("Nuevo request: {Method} {Path}", context.Request.Method, context.Request.Path);
            _logger3.LogInformation("Request recibido: {Method} {Path}", context.Request.Method, context.Request.Path);

            // Mal patrón: Lógica de negocio en el middleware
            var startTime = DateTime.UtcNow;
            var requestBody = await GetRequestBody(context.Request);

            // Código redundante: Múltiples validaciones innecesarias
            if (context.Request.Method == "POST")
            {
                _logger.LogInformation("Request POST detectado");
                _logger1.LogInformation("Request POST identificado");
                _logger2.LogInformation("Request POST encontrado");
            }

            if (context.Request.Path.Value.Contains("temperature"))
            {
                _logger.LogInformation("Request de temperatura detectado");
                _logger1.LogInformation("Request de temperatura identificado");
                _logger2.LogInformation("Request de temperatura encontrado");
            }

            if (context.Request.Path.Value.Contains("distance"))
            {
                _logger.LogInformation("Request de distancia detectado");
                _logger1.LogInformation("Request de distancia identificado");
                _logger2.LogInformation("Request de distancia encontrado");
            }

            if (context.Request.Path.Value.Contains("weight"))
            {
                _logger.LogInformation("Request de peso detectado");
                _logger1.LogInformation("Request de peso identificado");
                _logger2.LogInformation("Request de peso encontrado");
            }

            await _next(context);

            var endTime = DateTime.UtcNow;
            var duration = endTime - startTime;

            // Código redundante: Múltiples logs del mismo evento
            _logger.LogInformation("Request completado: {Method} {Path} - Duración: {Duration}ms", 
                context.Request.Method, context.Request.Path, duration.TotalMilliseconds);
            _logger1.LogInformation("Request finalizado: {Method} {Path} - Tiempo: {Duration}ms", 
                context.Request.Method, context.Request.Path, duration.TotalMilliseconds);
            _logger2.LogInformation("Request terminado: {Method} {Path} - Duración: {Duration}ms", 
                context.Request.Method, context.Request.Path, duration.TotalMilliseconds);
            _logger3.LogInformation("Request completado exitosamente: {Method} {Path} - Duración: {Duration}ms", 
                context.Request.Method, context.Request.Path, duration.TotalMilliseconds);
        }

        // Mal patrón: Método que hace múltiples cosas
        private async Task<string> GetRequestBody(HttpRequest request)
        {
            // Código redundante: Múltiples intentos de leer el body
            string body = "";
            
            try
            {
                request.EnableBuffering();
                using var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true);
                body = await reader.ReadToEndAsync();
                request.Body.Position = 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error leyendo request body");
                _logger1.LogError(ex, "Error al leer request body");
                _logger2.LogError(ex, "Error en lectura de request body");
            }

            return body;
        }
    }

    // Mal patrón: Clase de extensión redundante
    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }

        // Código redundante: Método que hace lo mismo
        public static IApplicationBuilder UseCustomLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }

        // Código redundante: Método que hace lo mismo
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
} 