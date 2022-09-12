using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrate
{
    public class RezervacijaAutomobilaManager : IRezervacijaAutomobilaService
    {
        private readonly IRezervacijaAutomobilaDal _rezervacijaAutomobilaDal;
        private readonly IUgovorIznajmljivanjaDal _ugovorIznajmljivanjaDal;
        private readonly IAutomobilDal _automobilDal;
        private readonly IKorisnikDal _korisnikDal;
        public RezervacijaAutomobilaManager(IRezervacijaAutomobilaDal rezervacijaAutomobilaDal, IUgovorIznajmljivanjaDal ugovorIznajmljivanjaDal, IAutomobilDal automobilDal, IKorisnikDal korisnikDal)
        {
            _rezervacijaAutomobilaDal = rezervacijaAutomobilaDal;
            _ugovorIznajmljivanjaDal = ugovorIznajmljivanjaDal;
            _automobilDal = automobilDal;
            _korisnikDal = korisnikDal;
        }

        public IResult Add(Rezervacija rezervacija)
        {
            var auto = _automobilDal.Get(t => t.IdAutomobil == rezervacija.IdAutomobila)!;
            var korisnik = _korisnikDal.Get(x => x.IdKorisnika == rezervacija.IdKorisnika);
            if (korisnik!.Status == true)
            {
                if (auto.Dostupan == true && auto.Rezervisan == false)
                {
                    auto.Dostupan = false;
                    auto.Rezervisan = true;
                    _automobilDal.Update(auto);
                    _rezervacijaAutomobilaDal.Add(rezervacija);
                    return new SuccessResult(Messages.RezervacijaAdded);
                }
            }
            else
            {
                return new SuccessResult(Messages.AktivanNalog);
            }


            return new SuccessResult(Messages.RezervacijaNeuspesna);
        }

        public IResult Delete(Rezervacija rezervacija)
        {
            var auto = _automobilDal.Get(t => t.IdAutomobil == rezervacija.IdAutomobila)!;
            auto.Dostupan = true;
            auto.Rezervisan = false;
            _automobilDal.Update(auto);
            _rezervacijaAutomobilaDal.Delete(rezervacija);
            return new SuccessResult(Messages.RezervacijaDeleted);
        }

        public IDataResult<List<Rezervacija>> GetAll()
        {
            return new SuccessDataResult<List<Rezervacija>>(_rezervacijaAutomobilaDal.GetAll(), Messages.MessageListed);
        }

        public IDataResult<Rezervacija> GetById(int rezId)
        {
            return new SuccessDataResult<Rezervacija>(_rezervacijaAutomobilaDal.Get(t => t.IdRezervacije == rezId)!);
        }

        public IDataResult<List<RezervacijaDetailDto>> GetRezervacijeByIdKorisnika(int idKorisnika)
        {
            var list = _rezervacijaAutomobilaDal.GetRezervacijeDetails(x => x.IdKorisnika == idKorisnika);
            return new SuccessDataResult<List<RezervacijaDetailDto>>(list, Messages.MessageListed);
        }

        public IDataResult<List<RezervacijaDetailDto>> GetRezervacijeDetails(int idRezervacije)
        {
            if (idRezervacije == 0)
            {
                return new SuccessDataResult<List<RezervacijaDetailDto>>(_rezervacijaAutomobilaDal.GetRezervacijeDetails(), Messages.MessageListed);
            }
            else
            {
                return new SuccessDataResult<List<RezervacijaDetailDto>>(_rezervacijaAutomobilaDal.GetRezervacijeDetails(t => t.IdRezervacije == idRezervacije), Messages.MessageListed);
            }
        }

        public IResult Update(Rezervacija rezervacija)
        {
            var auto = _automobilDal.Get(t => t.IdAutomobil == rezervacija.IdAutomobila)!;
            auto.Dostupan = false;
            auto.Rezervisan = !false;
            _automobilDal.Update(auto);
            _rezervacijaAutomobilaDal.Update(rezervacija);
            return new SuccessResult(Messages.RezervacijaUpdated);
        }
    }
}
