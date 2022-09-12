using Core.Entities.Concrate;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Korisnik> RegisterRadnik(KorisnikRegistracijaDto korisnikRegistracijaDto);
        IDataResult<Korisnik> Login(KorisnikLoginDto korisnikLoginDto);
        IDataResult<Korisnik> LoginKorisnik(KorisnikLoginDto korisnikLoginDto);
        IDataResult<AccessToken> CreateAccessToken(Korisnik korisnik);
        IResult UserExists(string email);
        IResult ChangePassword(KorisnikPromenaLozinkeDto korisnikPromenaLozinkeDto);
        IDataResult<Korisnik> RegisterKorisnik(KorisnikRegistracijaDto korisnikRegistracijaDto);
    }
}