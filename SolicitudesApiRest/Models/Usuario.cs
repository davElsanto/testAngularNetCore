namespace SolicitudesApiRest.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Clave { get; set; }
        public bool EsAdmin { get; set; }
    }
}