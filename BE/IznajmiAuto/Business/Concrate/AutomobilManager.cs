using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrate
{
    public class AutomobilManager : IAutomobilService
    {
        private readonly IAutomobilDal _automobilDal;
        public AutomobilManager(IAutomobilDal automobilDal)
        {
            _automobilDal = automobilDal;
        }

        public IResult Add(Automobil automobil)
        {
            _automobilDal.Add(automobil);
            return new SuccessResult(Messages.AutomobilAdded);
        }

        public IResult Delete(Automobil automobil)
        {
            _automobilDal.Delete(automobil);
            return new SuccessResult(Messages.AutomobilDeleted);

        }

        public IDataResult<List<Automobil>> GetAll()
        {
            return new SuccessDataResult<List<Automobil>>(_automobilDal.GetAll(), Messages.MessageListed);
        }

        public IDataResult<List<AutomobilDetailDto>> GetAutomobilDetails(int autoId)
        {
            if (autoId == 0)
            {
                return new SuccessDataResult<List<AutomobilDetailDto>>(_automobilDal.GetAutomobilDetails());
            }
            else
            {
                return new SuccessDataResult<List<AutomobilDetailDto>>(_automobilDal.GetAutomobilDetails(c => c.IdAutomobil == autoId));
            }
        }

        public IDataResult<List<AutomobilDetailDto>> GetAutomobilDetailsByFilter(int modelId, int proizvodjacId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<AutomobilDetailDto>> GetAutomobilDetailsByModel(int modelId)
        {
            return new SuccessDataResult<List<AutomobilDetailDto>>(_automobilDal.GetAutomobilDetails(t => t.IdModelAutomobila == modelId));
        }

        public IDataResult<List<AutomobilDetailDto>> GetAutomobilDetailsByProizvodjac(int proizvodjacId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<AutomobilDetailDto>> GetAutomobiliCenaBetween(decimal cena1, decimal cena2)
        {
            var result = from n in _automobilDal.GetAutomobilDetails()
                         where n.Cena >= cena1 && n.Cena <= cena2 select n;

            return new SuccessDataResult<List<AutomobilDetailDto>>(result.ToList(),Messages.MessageListed);
        }

        public IDataResult<Automobil> GetById(int autoId)
        {
            return new SuccessDataResult<Automobil>(_automobilDal.Get(t => t.IdAutomobil == autoId)!);
        }

        public IResult Update(Automobil automobil)
        {
            _automobilDal.Update(automobil);
            return new SuccessResult(Messages.AutomobilUpdated);
        }
    }
}
