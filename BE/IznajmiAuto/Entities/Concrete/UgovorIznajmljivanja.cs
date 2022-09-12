using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UgovorIznajmljivanja: IEntity
    {
        [Key]
        public int IdIznajmljivanja { get; set; }
        public string? IznajmljivanjeOd { get; set; }
        public string? IznajmljivanjeDo { get; set; }
        public string? NacinPlacanja { get; set; }
        public int IdCena { get; set; }
        public int IdKorisnika { get; set; }
        public int IdAutomobila { get; set; }
        public bool Status { get; set; }
       

    }
}
