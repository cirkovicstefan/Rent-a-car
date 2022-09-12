using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProizvodjacAutomobilaService
    {
        IResult Add(Proizvodjac proizvodjac);
        IResult Delete(Proizvodjac proizvodjac);
        IResult Update(Proizvodjac proizvodjac);
        IDataResult<List<Proizvodjac>> GetAll();
        IDataResult<Proizvodjac> GetById(int proizvodjacId);
    }
}
