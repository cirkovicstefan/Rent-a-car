using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CenaPoDanuDto:IDto
    {
        public int IdCena { get; set; }
        public string? Datum { get; set; }
        public decimal Cena { get; set; }
        public int IdModelAutomobila { get; set; }
        public string? NazivModela { get; set; }
        public string? NazivProizvodjaca { get; set; }
    }
}
