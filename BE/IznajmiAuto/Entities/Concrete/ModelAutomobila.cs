using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ModelAutomobila: IEntity
    {
        [Key]
        public int IdModelAutomobila { get; set; }
        public int IdProizvodjacAutomobila { get; set; }
        public string? Naziv { get; set; }
        public string? Gorivo { get; set; }
        public string? Kubikaza { get; set; }
        public int BrojSedista { get; set; }
        public string? Menjac { get; set; }

    }
}
