using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
        public bool Status { get; set; }
    }
}
