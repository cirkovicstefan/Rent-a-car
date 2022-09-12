using Core.Entities;

namespace Entities.DTOs
{
    public class UgovorIznajmljivanjaDetailDto : IDto
    {
        public int IdIznajmljivanja { get; set; }
        public string? IznajmljenOd { get; set; }
        public string? IznajmljenDo { get; set; }
        public string? NacinPlacanja { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? JMBG { get; set; }
        public string? NazivModela { get; set; }
        public string? NazivProizvodjaca { get; set; }
        public string? BrojRegistracije { get; set; }
        public decimal Cena { get; set; }
        public int IdCena { get; set; }
        public int IdKorisnika { get; set; }
        public int IdAutomobila { get; set; }
        public bool Dostupan { get; set; }
        public bool Rezervisan { get; set; }
        public bool Status { get; set; }
    }
}
