using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RezervacijaDetailDto :IDto
    {
        public int IdRezervacije { get; set; }
        public string? Datum { get; set; }
        public int IdKorisnika { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public int IdAutomobila { get; set; }
        public int IdModelAutomobila { get; set; }
        public string? NazivModela { get; set; }
        public int IdProizvodjacAutomobila { get; set; }
        public string? NazivProizvodjaca { get; set; }
    }
}
