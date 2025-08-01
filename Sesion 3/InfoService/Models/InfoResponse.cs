namespace InfoService.Models
{
    public class InfoResponse
    {
        public string Fecha { get; set; } = string.Empty;
        public string Hora { get; set; } = string.Empty;
        public string FechaHoraCompleta { get; set; } = string.Empty;
        public long Timestamp { get; set; }
        public string ZonaHoraria { get; set; } = string.Empty;
    }
} 