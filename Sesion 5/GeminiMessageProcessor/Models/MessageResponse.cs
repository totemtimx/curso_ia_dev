namespace GeminiMessageProcessor.Models;

public class MessageResponse
{
    public string Response { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public bool Success { get; set; }
} 