namespace GeminiMessageProcessor.Services;

public interface IFileService
{
    Task SaveUserAsync(string userName);
    Task SavePendingMessageAsync(string message, string timestamp);
} 