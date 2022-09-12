using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace Business.Concrate
{
    public class CenaIznajmljivanjaPoDanuMenager : ICenaIznajmljivanjaPoDanuService
    {
        private readonly ICenaPoDanuDal _cenaPoDanuDal;
        public CenaIznajmljivanjaPoDanuMenager(ICenaPoDanuDal cenaPoDanuDal)
        {
            _cenaPoDanuDal = cenaPoDanuDal;
        }

        public IResult Add(CenaIznjmljivanjaPoDanu cenaIznjmljivanjaPoDanu)
        {
            _cenaPoDanuDal.Add(cenaIznjmljivanjaPoDanu);
            return new SuccessResult(Messages.CenaPoDanucAdded);
        }

        public IResult Delete(CenaIznjmljivanjaPoDanu cenaIznjmljivanjaPoDanu)
        {
            _cenaPoDanuDal.Delete(cenaIznjmljivanjaPoDanu);
            return new SuccessResult(Messages.CenaPoDanuDeleted);
        }

        public IDataResult<List<CenaIznjmljivanjaPoDanu>> GetAll()
        {
            return new SuccessDataResult<List<CenaIznjmljivanjaPoDanu>>(_cenaPoDanuDal.GetAll(), Messages.MessageListed);
        }

        public IDataResult<CenaIznjmljivanjaPoDanu> GetById(int cenaId)
        {
            return new SuccessDataResult<CenaIznjmljivanjaPoDanu>(_cenaPoDanuDal.Get(t => t.IdCena == cenaId)!);
        }

        public IDataResult<List<CenaPoDanuDto>> GetCenaPoDanuDetails(int cenaId)
        {
            if (cenaId == 0)
            {
                return new SuccessDataResult<List<CenaPoDanuDto>>(_cenaPoDanuDal.GetCenaPoDanuDetails(), Messages.MessageListed);
            }
            else
            {
                return new SuccessDataResult<List<CenaPoDanuDto>>(_cenaPoDanuDal.GetCenaPoDanuDetails(c=>c.IdCena==cenaId), Messages.MessageListed);
            }
        }

        public IResult Update(CenaIznjmljivanjaPoDanu cenaIznjmljivanjaPoDanu)
        {
            _cenaPoDanuDal.Update(cenaIznjmljivanjaPoDanu);
            return new SuccessResult(Messages.CenaPoDanuUpdated);
        }
    }
}
