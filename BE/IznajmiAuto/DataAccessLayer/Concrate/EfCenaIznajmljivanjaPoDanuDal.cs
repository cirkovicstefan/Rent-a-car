using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrate
{
    public class EfCenaIznajmljivanjaPoDanuDal : EfEntityRepositoryBase<CenaIznjmljivanjaPoDanu, DataBasaContext>, ICenaPoDanuDal
    {
        public List<CenaPoDanuDto> GetCenaPoDanuDetails(Expression<Func<CenaIznjmljivanjaPoDanu, bool>>? filter = null)
        {
             using (var db = new DataBasaContext())
              {
                  var result = from c in filter == null ? db.CenaIznajmljivanjaPoDanu : db.CenaIznajmljivanjaPoDanu!.Where(filter)
                               join m in db.ModelAutomobila! on c.IdModelAutomobila equals m.IdModelAutomobila
                               join p in db.ProizvodjacAutomobila! on m.IdProizvodjacAutomobila equals p.IdProizvodjacAutomobila
                               select new CenaPoDanuDto
                               {
                                   IdCena = c.IdCena,
                                   Datum = c.Datum,
                                   Cena = c.Cena,
                                   IdModelAutomobila = c.IdModelAutomobila,
                                   NazivModela = m.Naziv,
                                   NazivProizvodjaca = p.Naziv
                               };
                  return result.ToList();
              }
           // throw new NotImplementedException();
        }
    }
}
