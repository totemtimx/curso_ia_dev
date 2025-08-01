using InfoService.Models;

namespace InfoService.Services
{
    public interface IInfoService
    {
        InfoResponse GetCurrentDateTime();
    }
} 