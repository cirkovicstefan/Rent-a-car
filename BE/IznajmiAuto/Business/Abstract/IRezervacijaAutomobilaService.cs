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
    public interface IRezervacijaAutomobilaService
    {
        IResult Add(Rezervacija rezervacija);
        IResult Delete(Rezervacija rezervacija);
        IResult Update(Rezervacija rezervacija);
        IDataResult<List<Rezervacija>> GetAll();
        IDataResult<Rezervacija> GetById(int rezId);
        IDataResult<List<RezervacijaDetailDto>>GetRezervacijeByIdKorisnika(int idKorisnika);
        IDataResult<List<RezervacijaDetailDto>> GetRezervacijeDetails(int idRezervacije);
    }
}
