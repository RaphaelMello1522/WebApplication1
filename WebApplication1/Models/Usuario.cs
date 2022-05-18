using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Setor { get; set; } = null!;
        public int? IdComputador { get; set; }

        public virtual Computadores? IdComputadorNavigation { get; set; }
    }
}
