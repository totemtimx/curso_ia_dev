using Microsoft.AspNetCore.Mvc;
using GeminiMessageProcessor.Models;
using GeminiMessageProcessor.Services;

namespace GeminiMessageProcessor.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageProcessorService _messageProcessorService;

    public MessageController(IMessageProcessorService messageProcessorService)
    {
        _messageProcessorService = messageProcessorService;
    }

    [HttpPost("process")]
    public async Task<ActionResult<MessageResponse>> ProcessMessage([FromBody] MessageRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Message))
        {
            return BadRequest(new MessageResponse
            {
                Response = "El mensaje no puede estar vacío",
                Category = "Error",
                Success = false
            });
        }

        var response = await _messageProcessorService.ProcessMessageAsync(request);
        
        if (response.Success)
        {
            return Ok(response);
        }
        else
        {
            return BadRequest(response);
        }
    }

    [HttpGet("health")]
    public ActionResult<string> Health()
    {
        return Ok("API funcionando correctamente");
    }
} 