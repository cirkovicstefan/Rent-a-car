using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class KorisnikLoginDto: IDto
    {
        public string? Email { get; set; }
        public string? Lozinka { get; set; }
    }
}
