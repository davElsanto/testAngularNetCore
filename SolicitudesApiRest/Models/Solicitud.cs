namespace SolicitudesApiRest.Model
{
    public class Solicitud
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public string DescripcionSolicitud { get; set; } = null!;
        public string Justificativo { get; set; } = null!;
        public string? Estado { get; set; }
        public string? DetalleGestion { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaGestion { get; set; }
    }
}