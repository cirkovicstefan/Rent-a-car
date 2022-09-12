using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICenaPoDanuDal : IEntityRepository<CenaIznjmljivanjaPoDanu>
    {
        List<CenaPoDanuDto> GetCenaPoDanuDetails(Expression<Func<CenaIznjmljivanjaPoDanu, bool>>? filter = null);
    }
}
