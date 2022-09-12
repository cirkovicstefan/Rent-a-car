using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrate
{
    public class IstorijaIznajmljivanjaMenager : IIstorijaIznajmljivanjaService
    {
        private readonly IIstorijaIznajmljivanjaDal _istorijaIznajmljivanjaDal;
        private readonly IUgovorIznajmljivanjaDal _ugovorIznajmljivanjaDal;
        private readonly ICenaPoDanuDal _cenaPoDanuDal;
        private readonly IKorisnikDal _korisnikDal;
        public IstorijaIznajmljivanjaMenager(IIstorijaIznajmljivanjaDal istorijaIznajmljivanjaDal, IUgovorIznajmljivanjaDal ugovorIznajmljivanjaDal, ICenaPoDanuDal cenaPoDanuDal, IKorisnikDal korisnikDal)
        {
            _istorijaIznajmljivanjaDal = istorijaIznajmljivanjaDal;
            _ugovorIznajmljivanjaDal = ugovorIznajmljivanjaDal;
            _cenaPoDanuDal = cenaPoDanuDal;
            _korisnikDal = korisnikDal;
        }

        public IResult Add(IstorijaIznajmljivanja istorijaIznajmljivanja)
        {
            IstorijaIznajmljivanja istorija = _istorijaIznajmljivanjaDal.Get(t => t.IdIznajmljivanja == istorijaIznajmljivanja.IdIznajmljivanja)!;
            if (istorija == null)
            {
                istorija = new IstorijaIznajmljivanja();
            }
            UgovorIznajmljivanja ugovorIznajmljivanja = _ugovorIznajmljivanjaDal.Get(t => t.IdIznajmljivanja == istorijaIznajmljivanja.IdIznajmljivanja)!;

            var cena = _cenaPoDanuDal.Get(t => t.IdCena == ugovorIznajmljivanja.IdCena)!;

            istorijaIznajmljivanja.Vracen = true;
            istorijaIznajmljivanja.DatumVracanja = DateTime.Now.ToString();
           
            DateTime iznajmljivanjeOd = DateTime.Parse(ugovorIznajmljivanja.IznajmljivanjeOd!);
            DateTime iznajmljivanjeDo = DateTime.Parse(ugovorIznajmljivanja.IznajmljivanjeDo!);
            long brojDana = (long)(iznajmljivanjeDo - iznajmljivanjeOd).TotalMilliseconds;
            brojDana = brojDana / (1000 * 60 * 60 * 24);

            istorijaIznajmljivanja.Zarada = cena.Cena*(int)brojDana;
            _istorijaIznajmljivanjaDal.Add(istorijaIznajmljivanja);
            return new SuccessResult(Messages.IstorijaAdded);
        }

        public IResult Delete(IstorijaIznajmljivanja istorijaIznajmljivanja)
        {
            _istorijaIznajmljivanjaDal.Delete(istorijaIznajmljivanja);
            return new SuccessResult(Messages.IstorijaDeleted);
        }

        public IDataResult<List<IstorijaIznajmljivanja>> GetAll()
        {
            return new SuccessDataResult<List<IstorijaIznajmljivanja>>(_istorijaIznajmljivanjaDal.GetAll(), Messages.MessageListed);
        }

        public IDataResult<List<IstorijaIznajmljivanjaDerailDto>> GetIstorijaDetails(int idIstorija)
        {
            if (idIstorija == 0)
            {
                return new SuccessDataResult<List<IstorijaIznajmljivanjaDerailDto>>(_istorijaIznajmljivanjaDal.GetIstorijaDetails());
            }
            else
            {
                return new SuccessDataResult<List<IstorijaIznajmljivanjaDerailDto>>(_istorijaIznajmljivanjaDal.GetIstorijaDetails(t => t.IdIstorija == idIstorija));

            }
        }

        public IDataResult<IstorijaIznajmljivanja> GetById(int istorijaId)
        {
            return new SuccessDataResult<IstorijaIznajmljivanja>(_istorijaIznajmljivanjaDal.Get(t => t.IdIstorija == istorijaId)!);
        }

        public IResult Update(IstorijaIznajmljivanja istorijaIznajmljivanja)
        {
            _istorijaIznajmljivanjaDal.Update(istorijaIznajmljivanja);
            return new SuccessResult(Messages.IstorijaUpdated);
        }

        public IDataResult<List<IstorijaIznajmljivanjaDerailDto>> GetIstorijaByIdKorisnik(int IdKorisnika)
        {

            var list = _istorijaIznajmljivanjaDal.GetIstorijaDetails().Where(x => x.IdKorisnika == IdKorisnika).ToList();

            return new SuccessDataResult<List<IstorijaIznajmljivanjaDerailDto>>(list, Messages.MessageListed);
        }
    }
}
