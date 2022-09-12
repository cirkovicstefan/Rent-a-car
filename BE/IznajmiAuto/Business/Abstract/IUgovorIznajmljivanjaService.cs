using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUgovorIznajmljivanjaService
    {
        IResult Add(UgovorIznajmljivanja ugovorIznajmljivanja);
        IResult Delete(UgovorIznajmljivanja ugovorIznajmljivanja);
        IResult Update(UgovorIznajmljivanja ugovorIznajmljivanja);
        IResult Return(UgovorIznajmljivanja ugovorIznajmljivanja);
        IDataResult<List<UgovorIznajmljivanja>> GetAll();
        IDataResult<UgovorIznajmljivanja> GetById(int autoId);
        IDataResult<List<UgovorIznajmljivanjaDetailDto>> GetDetailDto(int iznjamiId);
    }
}
