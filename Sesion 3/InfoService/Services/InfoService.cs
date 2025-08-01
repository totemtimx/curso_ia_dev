using InfoService.Models;

namespace InfoService.Services
{
    public class InfoService : IInfoService
    {
        public InfoResponse GetCurrentDateTime()
        {
            var currentDateTime = DateTime.Now;
            
            return new InfoResponse
            {
                Fecha = currentDateTime.ToString("yyyy-MM-dd"),
                Hora = currentDateTime.ToString("HH:mm:ss"),
                FechaHoraCompleta = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss"),
                Timestamp = currentDateTime.Ticks,
                ZonaHoraria = TimeZoneInfo.Local.DisplayName
            };
        }
    }
} 