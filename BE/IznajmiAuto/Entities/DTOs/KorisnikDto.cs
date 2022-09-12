using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public  class KorisnikDto
    {
        public int IdKorisnika { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? JMBG { get; set; }
        public string? BrojTelefona { get; set; }
        public string? Email { get; set; }
        public byte[]? LozinkaHash { get; set; }
        public byte[]? LozinkaSalt { get; set; }
        public string? DatumUclanjenja { get; set; }
        public bool Status { get; set; }
        public string? NazivUloge { get; set; }
    }
}
