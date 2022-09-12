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
    public interface IUgovorIznajmljivanjaDal:IEntityRepository<UgovorIznajmljivanja>
    {
        List<UgovorIznajmljivanjaDetailDto> GetRentalDetails(Expression<Func<UgovorIznajmljivanja, bool>>? filter = null);
    }
}
