using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class IstorijaIznajmljivanja: IEntity
    {
        [Key]
        public int IdIstorija { get; set; }
        public bool Vracen { get; set; }
        public string? DatumVracanja { get; set; }
        public decimal? Zarada { get; set; } = 0;
        public int IdIznajmljivanja { get; set; }

    }
}
