
using Core.Entities.Concrate;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrate
{
    public class DataBasaContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=IznajmiAuto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<Automobil>? Automobil { get; set; }
        public DbSet<Korisnik>? Korisnici { get; set; }
        public DbSet<Uloga>? Uloge { get; set; }
        public DbSet<ModelAutomobila>? ModelAutomobila { get; set; }
        public DbSet<Proizvodjac>? ProizvodjacAutomobila { get; set; }
        public DbSet<SlikaAutomobila>? SlikeAutomobila { get; set; }
        public DbSet<UgovorIznajmljivanja>? UgovorIznajmljivanja { get; set; }
        public DbSet<IstorijaIznajmljivanja>? IstorijaIznajmljivanja { get; set; }
        public DbSet<CenaIznjmljivanjaPoDanu>? CenaIznajmljivanjaPoDanu { get; set; }
        public DbSet<Rezervacija>? RezervacijaAutomobila { get; set; }



    }
}
