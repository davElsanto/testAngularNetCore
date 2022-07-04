namespace D_SANTOS_BACKEND.Models
{
    public enum ESTADO{
        INGRESADA,
        EN_ATENCION,
        ATENDIDA,
        NO_RESUELTA
    }
    public class Solicitud
    {
        public long Id { get; set;}
        //campo obligatorio
        public string DescripcionSolicitud {get; set;}

        //campo obligatorio, texto base 64
        public string Justificativo {get; set;}

        public string Estado {get; set;}
        public string DetalleGestion { get; set;}

        public DateTime FechaIngreso { get; set;}
        public DateTime FechaActualizacion { get; set;}
        public DateTime FechaGestion { get; set;}
    }
}