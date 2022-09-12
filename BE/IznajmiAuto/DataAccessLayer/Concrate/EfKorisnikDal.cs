using Core.DataAccess.EntityFramework;
using Core.Entities.Concrate;
using DataAccessLayer.Abstract;
using Entities.DTOs;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrate
{
    public class EfKorisnikDal : EfEntityRepositoryBase<Korisnik, DataBasaContext>, IKorisnikDal
    {
        public List<KorisnikDto> GetKorisnikDetails(Expression<Func<Korisnik, bool>>? filter = null)
        {
            using (var db = new DataBasaContext())
            {
               
                var result = from k in filter==null ?  db.Korisnici:db.Korisnici!.Where(filter)
                             join u in db.Uloge! on k.IdUloge equals u.IdUloge
                             select new KorisnikDto
                             {
                                 IdKorisnika = k.IdKorisnika,
                                 Ime = k.Ime,
                                 Prezime = k.Prezime,
                                 JMBG = k.JMBG,
                                 BrojTelefona = k.BrojTelefona,
                                 Email = k.Email,
                                 LozinkaHash = k.LozinkaHash,
                                 LozinkaSalt = k.LozinkaSalt,
                                 DatumUclanjenja = k.DatumUclanjenja,
                                 Status=k.Status,
                                 NazivUloge = u.Naziv
                             };
                return result.ToList();
            }
        }
    }
}
