using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Rezervacija: IEntity
    {
        [Key]
        public int IdRezervacije { get; set; }
        public string? Datum { get; set; }
        public int IdKorisnika { get; set; }
        public int IdAutomobila { get; set; }

    }
}
