using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICenaIznajmljivanjaPoDanuService
    {
        IResult Add(CenaIznjmljivanjaPoDanu cenaIznjmljivanjaPoDanu);
        IResult Delete(CenaIznjmljivanjaPoDanu cenaIznjmljivanjaPoDanu);
        IResult Update(CenaIznjmljivanjaPoDanu cenaIznjmljivanjaPoDanu);
        IDataResult<List<CenaIznjmljivanjaPoDanu>> GetAll();
        IDataResult<CenaIznjmljivanjaPoDanu> GetById(int cenaId);
        IDataResult<List<CenaPoDanuDto>> GetCenaPoDanuDetails(int cenaId);
    }
}
