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
    public class EfIstorijaIznajmljivanjaDal : EfEntityRepositoryBase<IstorijaIznajmljivanja, DataBasaContext>, IIstorijaIznajmljivanjaDal
    {
        public List<IstorijaIznajmljivanjaDerailDto> GetIstorijaDetails(Expression<Func<IstorijaIznajmljivanja, bool>>? filter = null)
        {
            using(DataBasaContext db=new DataBasaContext())
            {
                var result = from i in filter == null ? db.IstorijaIznajmljivanja : db.IstorijaIznajmljivanja!.Where(filter)
                             join u in db.UgovorIznajmljivanja! on i.IdIznajmljivanja equals u.IdIznajmljivanja
                             join k in db.Korisnici! on u.IdKorisnika equals k.IdKorisnika
                             join ce in db.CenaIznajmljivanjaPoDanu! on u.IdCena equals ce.IdCena
                             join a in db.Automobil! on u.IdAutomobila equals a.IdAutomobil
                             join m in db.ModelAutomobila! on a.IdModelAutomobila equals m.IdModelAutomobila
                             join p in db.ProizvodjacAutomobila! on m.IdProizvodjacAutomobila equals p.IdProizvodjacAutomobila
                             select new IstorijaIznajmljivanjaDerailDto
                             {
                                 IdIstorija = i.IdIstorija,
                                 Vracen = i.Vracen,
                                 DatumVracanja = i.DatumVracanja,
                                 Zarada = i.Zarada,
                                 IdIznajmljivanja = u.IdIznajmljivanja,
                                 IdKorisnika = k.IdKorisnika,
                                 Ime = k.Ime,
                                 Prezime = k.Prezime,
                                 Cena = ce.Cena,
                                 NazivModela = m.Naziv,
                                 NazivProizvodjaca = p.Naziv
                             };
                return result.ToList();

            }
        }
    }
}
