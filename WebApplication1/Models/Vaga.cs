using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Vaga
    {
        public int IdVaga { get; set; }
        public string? NomeVaga { get; set; }
        public string? DescricaoVaga { get; set; }
        public string? RequisitosVaga { get; set; }
    }
}
