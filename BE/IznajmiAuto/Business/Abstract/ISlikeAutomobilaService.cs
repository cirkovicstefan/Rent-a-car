using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ISlikeAutomobilaService
    {
        IResult Add(SlikaAutomobila slikaAutomobila, IFormFile file);
        IResult Delete(SlikaAutomobila slikaAutomobila);
        IResult Update(SlikaAutomobila slikaAutomobila, IFormFile file);
        IDataResult<List<SlikaAutomobila>> GetAll();
        IDataResult<SlikaAutomobila> GetById(int slikaId);
        IDataResult<List<SlikaAutomobilaDetailDto>> GetSlikeDetails(int idSlike);
    }
}