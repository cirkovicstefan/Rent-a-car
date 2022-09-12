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
    public interface IRezervacijaAutomobilaDal : IEntityRepository<Rezervacija>
    {
        List<RezervacijaDetailDto> GetRezervacijeDetails(Expression<Func<Rezervacija, bool>>? filter = null);
    }
}
