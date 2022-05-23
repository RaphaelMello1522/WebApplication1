using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class AreaDoCandidato
    {
        public int IdCandidato { get; set; }
        public string? NomeCandidato { get; set; }
        public string? CpfCandidato { get; set; }
        public bool? Desempregado { get; set; }
        public string? TelefoneCandidato { get; set; }
        public string? EmailCandidato { get; set; }
    }
}
