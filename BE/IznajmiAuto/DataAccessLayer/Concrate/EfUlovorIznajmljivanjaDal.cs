using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrate
{
    public class EfUlovorIznajmljivanjaDal : EfEntityRepositoryBase<UgovorIznajmljivanja, DataBasaContext>, IUgovorIznajmljivanjaDal
    {
        public List<UgovorIznajmljivanjaDetailDto> GetRentalDetails(Expression<Func<UgovorIznajmljivanja, bool>>? filter = null)
        {
            using (DataBasaContext db = new DataBasaContext())
            {
                var result = from u in filter == null ? db.UgovorIznajmljivanja : db.UgovorIznajmljivanja!.Where(filter)
                             join k in db.Korisnici! on u.IdKorisnika equals k.IdKorisnika
                             join c in db.CenaIznajmljivanjaPoDanu! on u.IdCena equals c.IdCena
                             join a in db.Automobil! on u.IdAutomobila equals a.IdAutomobil
                             join m in db.ModelAutomobila! on a.IdModelAutomobila equals m.IdModelAutomobila
                             join p in db.ProizvodjacAutomobila! on m.IdProizvodjacAutomobila equals p.IdProizvodjacAutomobila
                             select new UgovorIznajmljivanjaDetailDto
                             {
                                 IdIznajmljivanja = u.IdIznajmljivanja,
                                 IznajmljenOd = u.IznajmljivanjeOd,
                                 IznajmljenDo = u.IznajmljivanjeDo,
                                 NacinPlacanja = u.NacinPlacanja,
                                 Ime = k.Ime,
                                 Prezime = k.Prezime,
                                 JMBG = k.JMBG,
                                 NazivModela = m.Naziv,
                                 NazivProizvodjaca = p.Naziv,
                                 BrojRegistracije = a.BrojRegistracije,
                                 Cena = c.Cena,
                                 IdCena = c.IdCena,
                                 IdAutomobila = a.IdAutomobil,
                                 IdKorisnika = k.IdKorisnika,
                                 Rezervisan = a.Rezervisan,
                                 Dostupan = a.Dostupan,
                                 Status = u.Status
                             };
                return result.ToList();

            }
        }
    }

}
