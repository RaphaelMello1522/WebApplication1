using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Computadores
    {
        public Computadores()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdComputador { get; set; }
        public int? NumPatrimonio { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public int? NumSerie { get; set; }
        public string? So { get; set; }
        public int? MemoriaRam { get; set; }
        public string? Processador { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
