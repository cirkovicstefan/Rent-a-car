using Core.Entities;

namespace Entities.DTOs
{
    public class SlikaAutomobilaDetailDto : IDto
    {
        public int IdSlike { get; set; }
        public int IdAutomobila { get; set; }
        public string? PutanjaSlike { get; set; }
        public string? Datum { get; set; }
        public int IdModelAutomobila { get; set; }
        public string? NazivModela { get; set; }
        public int IdProizvodjacAutomobila { get; set; }
        public string? NazivProizvodjaca { get; set; }

    }
}
