using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IIstorijaIznajmljivanjaService
    {
        IResult Add(IstorijaIznajmljivanja istorijaIznajmljivanja);
        IResult Delete(IstorijaIznajmljivanja istorijaIznajmljivanja);
        IResult Update(IstorijaIznajmljivanja istorijaIznajmljivanja);
        IDataResult<List<IstorijaIznajmljivanja>> GetAll();
        IDataResult<List<IstorijaIznajmljivanjaDerailDto>> GetIstorijaByIdKorisnik(int IdKorisnika);
        IDataResult<IstorijaIznajmljivanja> GetById(int istorijaId);
        IDataResult<List<IstorijaIznajmljivanjaDerailDto>> GetIstorijaDetails(int idIstorija);
    }
}
