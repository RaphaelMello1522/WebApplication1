using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; } = null!;
        public string SetorUsuario { get; set; } = null!;
        public int? ComputadorId { get; set; }

        public virtual Computadores? Computador { get; set; }
    }
}
