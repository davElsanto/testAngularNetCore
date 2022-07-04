using System;
using System.Collections.Generic;

namespace D_SANTOS_BACKEND.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Solicitudes = new HashSet<Solicitude>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Clave { get; set; } = null!;

        public virtual ICollection<Solicitude> Solicitudes { get; set; }
    }
}
