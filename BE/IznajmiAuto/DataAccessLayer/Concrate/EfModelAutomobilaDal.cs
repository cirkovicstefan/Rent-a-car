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
    public class EfModelAutomobilaDal : EfEntityRepositoryBase<ModelAutomobila, DataBasaContext>, IModelAutomobilaDal
    {
        public List<ModelAutomobilaDetailDto> GetModelAutomobilaDetails()
        {
            using(var db=new DataBasaContext())
            {
                var result = from m in db.ModelAutomobila!
                             join p in db.ProizvodjacAutomobila!
                             on m.IdProizvodjacAutomobila equals p.IdProizvodjacAutomobila
                             select new ModelAutomobilaDetailDto
                             {
                                 IdModelAutomobila = m.IdModelAutomobila,
                                 IdProizvodjacAutomobila = m.IdProizvodjacAutomobila,
                                 Naziv = m.Naziv,
                                 Gorivo = m.Gorivo,
                                 Kubikaza = m.Kubikaza,
                                 BrojSedista = m.BrojSedista,
                                 Menjac = m.Menjac,
                                 NazivProizvodjaca = p.Naziv,
                                 Drzava = p.Drzava
                             };
                return result.ToList();
            }
        }
    }
}
