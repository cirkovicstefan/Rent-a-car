using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrate
{
    public class EfSlikaAutomobilaDal : EfEntityRepositoryBase<SlikaAutomobila, DataBasaContext>, ISlikaAutomobilaDal
    {
        public List<SlikaAutomobilaDetailDto> GetSlikeDetails(Expression<Func<SlikaAutomobila, bool>>? filter = null)
        {
            using (DataBasaContext db = new DataBasaContext())
            {
                var result = from s in filter == null ? db.SlikeAutomobila : db.SlikeAutomobila!.Where(filter)
                             join a in db.Automobil! on s.IdAutomobila equals a.IdAutomobil
                             join m in db.ModelAutomobila! on a.IdModelAutomobila equals m.IdModelAutomobila
                             join p in db.ProizvodjacAutomobila! on m.IdProizvodjacAutomobila equals p.IdProizvodjacAutomobila
                             select new SlikaAutomobilaDetailDto
                             {
                                 IdSlike = s.IdSlike,
                                 PutanjaSlike = s.PutanjaSlike,
                                 Datum = s.Datum,
                                 IdModelAutomobila = m.IdModelAutomobila,
                                 IdProizvodjacAutomobila = p.IdProizvodjacAutomobila,
                                 NazivModela = m.Naziv,
                                 NazivProizvodjaca = p.Naziv
                             };
                return result.ToList();
            }
        }
    }
}
