using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Concrate
{
    public class SlikeAutomobilaManager : ISlikeAutomobilaService
    {
        private readonly ISlikaAutomobilaDal _slikaAutomobilaDal;
        public SlikeAutomobilaManager(ISlikaAutomobilaDal slikaAutomobilaDal)
        {
            _slikaAutomobilaDal = slikaAutomobilaDal;
        }

        public IResult Add(SlikaAutomobila slikaAutomobila, IFormFile file)
        {
            var result = BusinessRules.Run(CheckCarImageCount(slikaAutomobila.IdSlike));
            if (result != null)
            {
                return result;
            }

            slikaAutomobila.Datum = DateTime.Now.ToString();
            slikaAutomobila.PutanjaSlike = FileHelper.AddFile(file);

            _slikaAutomobilaDal.Add(slikaAutomobila);

            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(SlikaAutomobila slikaAutomobila)
        {
            var image = _slikaAutomobilaDal.Get(c => c.IdSlike == slikaAutomobila.IdSlike);

            if (image == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            FileHelper.DeleteFile(image.PutanjaSlike!);

            _slikaAutomobilaDal.Delete(slikaAutomobila);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<SlikaAutomobila>> GetAll()
        {
            return new SuccessDataResult<List<SlikaAutomobila>>(_slikaAutomobilaDal.GetAll(), Messages.MessageListed);
        }

        public IDataResult<SlikaAutomobila> GetById(int slikaId)
        {
            return new SuccessDataResult<SlikaAutomobila>(_slikaAutomobilaDal.Get(ci => ci.IdSlike == slikaId)!);
        }

        public IDataResult<List<SlikaAutomobilaDetailDto>> GetSlikeDetails(int idSlike)
        {
            if (idSlike == 0)
            {
                return new SuccessDataResult<List<SlikaAutomobilaDetailDto>>(_slikaAutomobilaDal.GetSlikeDetails(), Messages.MessageListed);
            }
            else
            {
                return new SuccessDataResult<List<SlikaAutomobilaDetailDto>>(_slikaAutomobilaDal.GetSlikeDetails(t => t.IdSlike == idSlike), Messages.MessageListed);
            }
        }

        public IResult Update(SlikaAutomobila slikaAutomobila, IFormFile file)
        {
            var oldImage = _slikaAutomobilaDal.Get(c => c.IdSlike == slikaAutomobila.IdSlike);

            if (oldImage == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            slikaAutomobila.Datum = DateTime.Now.ToString();
            slikaAutomobila.PutanjaSlike = FileHelper.UpdateFile(file, oldImage.PutanjaSlike!);

            _slikaAutomobilaDal.Update(slikaAutomobila);

            return new SuccessResult(Messages.CarImageUpdated);
        }
        private IResult CheckCarImageCount(int carId)
        {
            if (_slikaAutomobilaDal.GetAll(ci => ci.IdSlike == carId).Count >= 5)
            {
                return new ErrorResult(Messages.CarImageNumberError);
            }
            return new SuccessResult();
        }

    }
}
