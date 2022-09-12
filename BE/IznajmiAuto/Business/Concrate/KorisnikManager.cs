
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrate;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.DTOs;

namespace Business.Concrate
{
    public class KorisnikManager : IKorisnikService
    {
        private readonly IKorisnikDal _korisnikDal;
        private readonly IUgovorIznajmljivanjaDal _ugovorIznajmljivanjaDal;
        private readonly IRezervacijaAutomobilaDal _rezervacijaAutomobilaDal;
        public KorisnikManager(IKorisnikDal korisnikDal, IUgovorIznajmljivanjaDal ugovorIznajmljivanjaDal, IRezervacijaAutomobilaDal rezervacijaAutomobilaDal)
        {
            _korisnikDal = korisnikDal;
            _ugovorIznajmljivanjaDal = ugovorIznajmljivanjaDal;
            _rezervacijaAutomobilaDal = rezervacijaAutomobilaDal;
        }

        public IResult Add(Korisnik korisnik)
        {
            _korisnikDal.Add(korisnik);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(int IdKorisnika)
        {
            var korisnik = _korisnikDal.GetAll().First(c => c.IdKorisnika == IdKorisnika);
            var x = _ugovorIznajmljivanjaDal.GetAll().FirstOrDefault(c => c.IdKorisnika == IdKorisnika);
            var y = _rezervacijaAutomobilaDal.GetAll().FirstOrDefault(c => c.IdKorisnika == IdKorisnika);

            if (x?.IdKorisnika > 0 || y?.IdKorisnika > 0)
            {
                return new SuccessResult(Messages.UserDeletedError);
            }
            else
            {
                _korisnikDal.Delete(korisnik);
                return new SuccessResult(Messages.UserDeleted);
            }


        }

        public IDataResult<List<Korisnik>> GetAll()
        {
            return new SuccessDataResult<List<Korisnik>>(_korisnikDal.GetAll(), Messages.MessageListed);
        }

        public IDataResult<List<Korisnik>> GetAllKlijenti()
        {
            return new SuccessDataResult<List<Korisnik>>(_korisnikDal.GetAll().Where(t => t.IdUloge == 2).ToList(), Messages.MessageListed);
        }

        public IDataResult<List<Korisnik>> GetAllRadnici()
        {
            return new SuccessDataResult<List<Korisnik>>(_korisnikDal.GetAll().Where(t => t.IdUloge == 1).ToList(),Messages.MessageListed);
        }

        public IDataResult<Korisnik> GetByEmail(string email)
        {
            return new SuccessDataResult<Korisnik>(_korisnikDal.Get(t => t.Email == email)!);

        }

        public IDataResult<Korisnik> GetById(int userId)
        {
            return new SuccessDataResult<Korisnik>(_korisnikDal.Get(t => t.IdKorisnika == userId)!);
        }

        public IDataResult<List<KorisnikDto>> GetKorisnikDetails()
        {
            return new SuccessDataResult<List<KorisnikDto>>(_korisnikDal.GetKorisnikDetails());
        }

        public IResult Update(Korisnik korisnik)
        {
            var korisnik1 = _korisnikDal.GetAll().First(t => t.IdKorisnika == korisnik.IdKorisnika);
            korisnik1.IdKorisnika = korisnik.IdKorisnika;
            korisnik1.Ime = korisnik.Ime;
            korisnik1.Prezime = korisnik.Prezime;
            korisnik1.Email = korisnik.Email;
            korisnik1.JMBG = korisnik.JMBG;
            korisnik1.BrojTelefona = korisnik.BrojTelefona;

            _korisnikDal.Update(korisnik1);
            return new SuccessResult(Messages.UserUpdated);
        }
        public IResult UpdateKorisnik(Korisnik korisnik)
        {
           

            _korisnikDal.Update(korisnik);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult UpdateStatus(int IdKorisnika)
        {
            var korisnik = _korisnikDal.GetAll().First(t => t.IdKorisnika == IdKorisnika);
            korisnik.Status = true;
            _korisnikDal.Update(korisnik);
            return new SuccessResult(Messages.UserUpdatedStatus);
        }
    }
}
