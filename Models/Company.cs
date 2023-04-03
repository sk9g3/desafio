using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.Models.Abstract;

namespace desafio.Models
{
    public class Company : Entity
    {
        public string? id { get; set; }
        public string? status { get; set; }
        public string? date_ingestion { get; set; }
        public string? last_update { get; set; }
        public List<Cost>? custos { get; set; }

    }
}