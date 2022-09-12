using Core.DataAccess;
using Core.Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IKorisnikDal:IEntityRepository<Korisnik>
    {
        List<KorisnikDto> GetKorisnikDetails(Expression<Func<Korisnik, bool>>? filter = null);
    }
}
