using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrate
{
    public class ModelAutomobilaManager : IModelAutomobilaService
    {
        private readonly IModelAutomobilaDal _modelAutomobilaDal;
        private readonly IAutomobilDal _automobilDal;
        public ModelAutomobilaManager(IModelAutomobilaDal modelAutomobilaDal, IAutomobilDal automobilDal)
        {
            _modelAutomobilaDal = modelAutomobilaDal;
            _automobilDal = automobilDal;
        }


        public IResult Add(ModelAutomobila modelAutomobila)
        {
            _modelAutomobilaDal.Add(modelAutomobila);
            return new SuccessResult(Messages.ModelAutomobilaAdded);
        }

        public IResult Delete(ModelAutomobila modelAutomobila)
        {
            var x = _automobilDal.GetAll().FirstOrDefault(c => c.IdModelAutomobila == modelAutomobila.IdModelAutomobila) ?? new Automobil();
            if (x.IdModelAutomobila == modelAutomobila.IdModelAutomobila)
            {
                return new SuccessResult(Messages.ModelAutomobilaDeletedError);
            }
            _modelAutomobilaDal.Delete(modelAutomobila);
            return new SuccessResult(Messages.ModelAutomobilaDeleted);
        }

        public IDataResult<List<ModelAutomobila>> GetAll()
        {
            return new SuccessDataResult<List<ModelAutomobila>>(_modelAutomobilaDal?.GetAll()!, Messages.MessageListed);
        }

        public IDataResult<ModelAutomobila> GetById(int modelId)
        {
            return new SuccessDataResult<ModelAutomobila>(_modelAutomobilaDal.Get(t => t.IdModelAutomobila == modelId)!);

        }

        public IDataResult<List<ModelAutomobilaDetailDto>> GetModelAutomobilaDetails()
        {
            return new SuccessDataResult<List<ModelAutomobilaDetailDto>>(_modelAutomobilaDal?.GetModelAutomobilaDetails()!, Messages.MessageListed);
        }

        public IResult Update(ModelAutomobila modelAutomobila)
        {
            _modelAutomobilaDal.Update(modelAutomobila);
            return new SuccessResult(Messages.ModelAutomobilaUpdated);
        }
    }
}
