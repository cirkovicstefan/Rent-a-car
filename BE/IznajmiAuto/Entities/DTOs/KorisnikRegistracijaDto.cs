using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class KorisnikRegistracijaDto: IDto
    {
       
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? JMBG { get; set; }
        public string? BrojTelefona { get; set; }
        public string? Email { get; set; }
        public string? Lozinka { get; set; }
        public string? NazivUloge { get; set; }
    }
}
