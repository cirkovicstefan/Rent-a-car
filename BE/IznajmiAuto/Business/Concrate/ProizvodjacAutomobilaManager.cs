using Business.Abstract;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
namespace Business.Concrate
{
    public class ProizvodjacAutomobilaManager : IProizvodjacAutomobilaService
    {
        private readonly IProizvodjacDal _proizvodjacDal;
        private readonly IModelAutomobilaDal _modelAutomobilaDal;
        public ProizvodjacAutomobilaManager(IProizvodjacDal proizvodjacDal, IModelAutomobilaDal modelAutomobilaDal)
        {
            _proizvodjacDal = proizvodjacDal;
            _modelAutomobilaDal = modelAutomobilaDal;
        }
        public IResult Add(Proizvodjac proizvodjac)
        {
            _proizvodjacDal.Add(proizvodjac);
            return new SuccessResult(Messages.ProizvodjacAdded);
        }

        public IResult Delete(Proizvodjac proizvodjac)
        {
            var x = _modelAutomobilaDal.GetAll().FirstOrDefault(c => c.IdProizvodjacAutomobila == proizvodjac.IdProizvodjacAutomobila) ?? new ModelAutomobila();
            if (x.IdProizvodjacAutomobila==proizvodjac.IdProizvodjacAutomobila)
            {
                return new SuccessResult(Messages.ProizvodjacDeletedError);
            }
            _proizvodjacDal.Delete(proizvodjac);
            return new SuccessResult(Messages.ProizvodjacDeleted);
        }

        public IDataResult<List<Proizvodjac>> GetAll()
        {
           
          return new SuccessDataResult<List<Proizvodjac>>(_proizvodjacDal?.GetAll()!,Messages.MessageListed);
            
        }

        public IDataResult<Proizvodjac> GetById(int proizvodjacId)
        {
            return new SuccessDataResult<Proizvodjac>(_proizvodjacDal.Get(t => t.IdProizvodjacAutomobila == proizvodjacId)!);
        }

        public IResult Update(Proizvodjac proizvodjac)
        {
            _proizvodjacDal.Update(proizvodjac);
            return new SuccessResult(Messages.ProizvodjacUpdated);
        }
    }
}
