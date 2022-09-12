using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public  class Automobil:IEntity
    {
        [Key]
        public int IdAutomobil { get; set; }
        public int IdModelAutomobila { get; set; }    
        public string? BrojRegistracije { get; set; }
        public string? Boja { get; set; }
        public bool Dostupan { get; set; }
        public bool Rezervisan { get; set; }
        public int Godiste { get; set; } 

    }
}
