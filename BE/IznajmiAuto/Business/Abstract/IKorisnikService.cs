using Core.Entities.Concrate;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IKorisnikService
    {
        IResult Add(Korisnik korisnik);
        IResult Delete(int IdKorisnika);
        IResult Update(Korisnik korisnik);
        IResult UpdateStatus(int IdKorisnika);
        IDataResult<List<Korisnik>> GetAll();
        IDataResult<List<Korisnik>> GetAllKlijenti();
        IDataResult<List<Korisnik>> GetAllRadnici();
        IDataResult<Korisnik> GetById(int userId);
        IDataResult<Korisnik> GetByEmail(string email);
        IDataResult<List<KorisnikDto>> GetKorisnikDetails();
        IResult UpdateKorisnik(Korisnik korisnik);

    }
}
