
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities.Concrete;

namespace Entities.DTOs
{
    public class IstorijaIznajmljivanjaDerailDto: IDto
    {
        public int IdIstorija { get; set; }
        public bool Vracen { get; set; }
        public string? DatumVracanja { get; set; }
        public decimal? Zarada { get; set; }
        public int IdIznajmljivanja { get; set; }
        public int IdKorisnika { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public decimal Cena { get; set; }
        public string? NazivModela { get; set; }
        public string? NazivProizvodjaca { get; set; }
    }
}
