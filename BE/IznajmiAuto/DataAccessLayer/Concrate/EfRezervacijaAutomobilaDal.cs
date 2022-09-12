using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrate
{
    public class EfRezervacijaAutomobilaDal : EfEntityRepositoryBase<Rezervacija, DataBasaContext>, IRezervacijaAutomobilaDal
    {
        public List<RezervacijaDetailDto> GetRezervacijeDetails(Expression<Func<Rezervacija, bool>>? filter = null)
        {
            using(DataBasaContext db=new DataBasaContext())
            {
                var result = from r in filter == null ? db.RezervacijaAutomobila! : db.RezervacijaAutomobila!.Where(filter)
                             join k in db.Korisnici! on r.IdKorisnika equals k.IdKorisnika
                             join a in db.Automobil! on r.IdAutomobila equals a.IdAutomobil
                             join m in db.ModelAutomobila! on a.IdModelAutomobila equals m.IdModelAutomobila
                             join p in db.ProizvodjacAutomobila! on m.IdProizvodjacAutomobila equals p.IdProizvodjacAutomobila
                             select new RezervacijaDetailDto
                             {
                                 IdRezervacije = r.IdRezervacije,
                                 Datum = r.Datum,
                                 IdKorisnika=k.IdKorisnika,
                                 IdAutomobila =a.IdAutomobil,
                                 Ime = k.Ime,
                                 Prezime= k.Prezime,
                                 IdModelAutomobila=m.IdModelAutomobila,
                                 NazivModela = m.Naziv,
                                 IdProizvodjacAutomobila = p.IdProizvodjacAutomobila,
                                 NazivProizvodjaca = p.Naziv
                             };
                return result.ToList();

            }
        }
    }
}
