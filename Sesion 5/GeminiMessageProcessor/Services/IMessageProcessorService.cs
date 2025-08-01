using GeminiMessageProcessor.Models;

namespace GeminiMessageProcessor.Services;

public interface IMessageProcessorService
{
    Task<MessageResponse> ProcessMessageAsync(MessageRequest request);
} 