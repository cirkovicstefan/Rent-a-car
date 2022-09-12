using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CenaIznjmljivanjaPoDanu:IEntity
    {
        [Key]
        public int IdCena { get; set; }
        public string? Datum { get; set; }
        public decimal Cena { get; set; }
        public int IdModelAutomobila { get; set; }
    }
}
