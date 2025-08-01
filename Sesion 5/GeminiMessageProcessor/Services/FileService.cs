using System.Text;

namespace GeminiMessageProcessor.Services;

public class FileService : IFileService
{
    private readonly string _usersDirectory = "Data/Users";
    private readonly string _pendingDirectory = "Data/Pendientes";

    public FileService()
    {
        // Asegurar que las carpetas existan
        Directory.CreateDirectory(_usersDirectory);
        Directory.CreateDirectory(_pendingDirectory);
    }

    public async Task SaveUserAsync(string userName)
    {
        var fileName = $"{userName}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        var filePath = Path.Combine(_usersDirectory, fileName);
        
        var content = $"Usuario: {userName}\nFecha de creación: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
        await File.WriteAllTextAsync(filePath, content, Encoding.UTF8);
    }

    public async Task SavePendingMessageAsync(string message, string timestamp)
    {
        var fileName = $"{timestamp}.txt";
        var filePath = Path.Combine(_pendingDirectory, fileName);
        
        var content = $"Mensaje: {message}\nFecha: {DateTime.Now:yyyy-MM-dd HH:mm:ss}";
        await File.WriteAllTextAsync(filePath, content, Encoding.UTF8);
    }
} 