using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class AutomobilDetailDto: IDto
    {
        public int IdAutomobil { get; set; }
        public int IdModelAutomobila { get; set; }
        public string? NazivProizvodjaca { get; set; }
        public string? NazivModela { get; set; }
        public string? BrojRegistracije { get; set; }
        public string? Boja { get; set; }
        public bool Dostupan { get; set; }
        public bool Rezervisan { get; set; }
        public int Godiste { get; set; }
        public string? Gorivo { get; set; }
        public string? Kubikaza { get; set; }
        public int BrojSedista { get; set; }
        public string? Menjac { get; set; }
        public decimal Cena { get; set; }
        public List<SlikaAutomobila> SlikaPutanje { get; set; } = new List<SlikaAutomobila>() { };

    }
}
