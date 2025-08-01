using GeminiMessageProcessor.Models;

namespace GeminiMessageProcessor.Services;

public interface IGeminiService
{
    Task<MessageCategory> ClassifyMessageAsync(string message);
    Task<string> ExtractUserNameAsync(string message);
    Task<string> ValidateUserCreationInfoAsync(string message);
    Task<string> ValidateProductInfoAsync(string message);
} 