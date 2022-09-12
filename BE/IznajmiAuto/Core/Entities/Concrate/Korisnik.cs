using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Concrate
{
    public class Korisnik : IEntity
    {
        [Key]
        public int IdKorisnika { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? JMBG { get; set; }
        public string? BrojTelefona { get; set; }
        public string? Email { get; set; }
        public byte[]? LozinkaHash { get; set; }
        public byte[]? LozinkaSalt { get; set; }
        public string? DatumUclanjenja { get; set; }
        public bool Status { get; set; }
        public int IdUloge { get; set; }

    }
}
