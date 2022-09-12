using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrate
{
    public class UgovorIznajmljivanjaMenager : IUgovorIznajmljivanjaService
    {
        private readonly IUgovorIznajmljivanjaDal _ugovorIznajmljivanjaDal;
        private readonly IAutomobilDal _automobilDal;
        private readonly IIstorijaIznajmljivanjaDal _istorijaIznajmljivanjaDal;
        private readonly IKorisnikDal _korisnikDal;
        private readonly IRezervacijaAutomobilaDal _rezervacijaIznajmljivanjaDal;
        public UgovorIznajmljivanjaMenager(IUgovorIznajmljivanjaDal ugovorIznajmljivanjaDal, IAutomobilDal automobilDal, IIstorijaIznajmljivanjaDal istorijaIznajmljivanjaDal, IKorisnikDal korisnikDal, IRezervacijaAutomobilaDal rezervacijaIznajmljivanjaDal)
        {
            _ugovorIznajmljivanjaDal = ugovorIznajmljivanjaDal;
            _automobilDal = automobilDal;
            _istorijaIznajmljivanjaDal = istorijaIznajmljivanjaDal;
            _korisnikDal = korisnikDal;
            _rezervacijaIznajmljivanjaDal = rezervacijaIznajmljivanjaDal;
        }

        public IResult Add(UgovorIznajmljivanja ugovorIznajmljivanja)
        {
            SuccessResult poruka = new SuccessResult();
            var listaAutomobila = _automobilDal.GetAll();
            var korisnik = _korisnikDal.Get(t => t.IdKorisnika == ugovorIznajmljivanja.IdKorisnika)!;
            if (korisnik.Status == true)
            {
                foreach (var item in listaAutomobila)
                {
                    if (item.IdAutomobil == ugovorIznajmljivanja.IdAutomobila)
                    {
                        var rezervacije = _rezervacijaIznajmljivanjaDal.Get(x => x.IdAutomobila == ugovorIznajmljivanja.IdAutomobila && x.IdKorisnika == ugovorIznajmljivanja.IdKorisnika);

                        if ((item.Dostupan == true && item.Rezervisan == false) || rezervacije != null)
                        {
                            if (rezervacije != null)
                            {
                                _rezervacijaIznajmljivanjaDal.Delete(rezervacije!);
                            }

                            ugovorIznajmljivanja.Status = false;
                            _ugovorIznajmljivanjaDal.Add(ugovorIznajmljivanja);
                            Automobil automobil = _automobilDal.Get(t => t.IdAutomobil == item.IdAutomobil)!;
                            automobil.Dostupan = false;
                            automobil.Rezervisan = true;
                            _automobilDal.Update(automobil);
                            poruka = new SuccessResult(Messages.RentalAdded);
                            break;


                        }
                        else
                        {
                            poruka = new SuccessResult(Messages.CarIsAlreadyRented);
                            break;
                        }

                    }
                }
            }
            else
            {
                poruka = new SuccessResult(Messages.AktivanNalog);

            }



            return poruka;
        }

        public IResult Return(UgovorIznajmljivanja ugovorIznajmljivanja)
        {
            Automobil automobil = new Automobil();
            foreach (var item in _automobilDal.GetAll())
            {
                if (item.IdAutomobil == ugovorIznajmljivanja.IdAutomobila)
                {
                    automobil = item; break;
                }
            }

            automobil.Dostupan = true;
            automobil.Rezervisan = false;
            _automobilDal.Update(automobil);

            UgovorIznajmljivanja ugovorIznajmljivanja1 = new UgovorIznajmljivanja();
            foreach (var item in _ugovorIznajmljivanjaDal.GetAll())
            {
                if (item.Status == false && item.IdKorisnika == ugovorIznajmljivanja.IdKorisnika && item.IdAutomobila == ugovorIznajmljivanja.IdAutomobila)
                {

                    ugovorIznajmljivanja1 = item;
                    break;

                }
            }
            //  var ugovoriznajmljivanja2 = _ugovorIznajmljivanjaDal.Get(x => x.IdKorisnika == ugovorIznajmljivanja.IdKorisnika && x.IdAutomobila == ugovorIznajmljivanja.IdAutomobila);

            ugovorIznajmljivanja1.Status = true;
            _ugovorIznajmljivanjaDal.Update(ugovorIznajmljivanja1);
            return new SuccessResult(Messages.CarReturn);
        }

        public IResult Delete(UgovorIznajmljivanja ugovorIznajmljivanja)
        {
            var automobil = _automobilDal.Get(t => t.IdAutomobil == ugovorIznajmljivanja.IdAutomobila)!;
            automobil.Dostupan = true;
            automobil.Rezervisan = false;
            _automobilDal.Update(automobil);

            _ugovorIznajmljivanjaDal.Delete(ugovorIznajmljivanja);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<UgovorIznajmljivanja>> GetAll()
        {
            return new SuccessDataResult<List<UgovorIznajmljivanja>>(_ugovorIznajmljivanjaDal.GetAll(), Messages.MessageListed);
        }

        public IDataResult<UgovorIznajmljivanja> GetById(int autoId)
        {
            return new SuccessDataResult<UgovorIznajmljivanja>(_ugovorIznajmljivanjaDal.Get(t => t.IdIznajmljivanja == autoId)!);
        }

        public IDataResult<List<UgovorIznajmljivanjaDetailDto>> GetDetailDto(int iznjamiId)
        {

            if (iznjamiId == 0)
            {
                return new SuccessDataResult<List<UgovorIznajmljivanjaDetailDto>>(_ugovorIznajmljivanjaDal.GetRentalDetails());
            }
            else
            {
                return new SuccessDataResult<List<UgovorIznajmljivanjaDetailDto>>(_ugovorIznajmljivanjaDal.GetRentalDetails(t => t.IdIznajmljivanja == iznjamiId));
            }


        }

        public IResult Update(UgovorIznajmljivanja ugovorIznajmljivanja)
        {
            _ugovorIznajmljivanjaDal.Update(ugovorIznajmljivanja);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
