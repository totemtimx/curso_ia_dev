using Microsoft.AspNetCore.Mvc;
using InfoService.Services;
using InfoService.Models;

namespace InfoService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly IInfoService _infoService;

        public InfoController(IInfoService infoService)
        {
            _infoService = infoService;
        }

        [HttpGet("info")]
        public ActionResult<InfoResponse> GetInfo()
        {
            var info = _infoService.GetCurrentDateTime();
            return Ok(info);
        }
    }
} 