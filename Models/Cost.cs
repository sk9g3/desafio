using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.Models.Abstract;

namespace desafio.Models
{
    public class Cost : Entity
    {
        public int ano { get; set; }
        public string? id_type { get; set; }
        public string? last_update { get; set; }
        public double valor { get; set; }
    }
}