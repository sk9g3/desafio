using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.Models.Abstract;

namespace desafio.Models
{
    public class Group : Entity
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string category { get; set; }
        public string date_ingestion { get; set; }
        public List<string> companys { get; set; }
    }
}