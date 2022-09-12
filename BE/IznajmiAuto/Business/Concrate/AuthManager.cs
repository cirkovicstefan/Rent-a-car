using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrate;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;

using Entities.DTOs;

namespace Business.Concrate
{
    public class AuthManager : IAuthService
    {
        private readonly IKorisnikService _korisnikService;
        private readonly ITokenHelper _tokenHelper;
        public AuthManager(IKorisnikService korisnikService, ITokenHelper tokenHelper)
        {
            _korisnikService = korisnikService;
            _tokenHelper = tokenHelper;
        }

        public IResult ChangePassword(KorisnikPromenaLozinkeDto korisnikPromenaLozinkeDto)
        {
            Korisnik korisnik = _korisnikService.GetById(korisnikPromenaLozinkeDto.Id).Data;
            if (!HashingHelper.VerifyPasswordHash(korisnikPromenaLozinkeDto.TrenutnaLozinka!,
                korisnik.LozinkaHash!, korisnik.LozinkaSalt!))
            {
                return new ErrorResult(Messages.CurrentPasswordIsWrong);
            }
            HashingHelper.CreatePasswordHash(korisnikPromenaLozinkeDto.NovaLozinka!,
                                            out byte[] passwordHash,
                                            out byte[] passwordSalt);

            korisnik.LozinkaHash = passwordHash;
            korisnik.LozinkaSalt = passwordSalt;
            _korisnikService.UpdateKorisnik(korisnik);
            return new SuccessResult(Messages.PasswordUpdated);

        }

        public IDataResult<AccessToken> CreateAccessToken(Korisnik korisnik)
        {
            var accessToken = _tokenHelper.CreateToken(korisnik);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenCreated);
        }

        public IDataResult<Korisnik> Login(KorisnikLoginDto korisnikLoginDto)
        {
            // || usertToCheck.Data.IdUloge == 2
            var usertToCheck = _korisnikService.GetByEmail(korisnikLoginDto.Email!);
            if (usertToCheck.Data == null)
            {
                return new ErrorDataResult<Korisnik>(Messages.UserNotFound);
            }
            else if (usertToCheck.Data.Status == false)
            {
                return new ErrorDataResult<Korisnik>(Messages.NalogNijeAktivan);
            }
            if (!HashingHelper.VerifyPasswordHash(korisnikLoginDto.Lozinka!,
                                                  usertToCheck.Data.LozinkaHash!,
                                                  usertToCheck.Data.LozinkaSalt!))
            {
                return new ErrorDataResult<Korisnik>(Messages.WrongPassword);
            }
            return new SuccessDataResult<Korisnik>(usertToCheck.Data, Messages.LoginSuccessful);

        }

        public IDataResult<Korisnik> LoginKorisnik(KorisnikLoginDto korisnikLoginDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Korisnik> RegisterKorisnik(KorisnikRegistracijaDto korisnikRegistracijaDto)
        {
            HashingHelper.CreatePasswordHash(korisnikRegistracijaDto.Lozinka!,
                                              out byte[] passwordHash,
                                              out byte[] passwordSalt);
            var user = new Korisnik
            {
                Email = korisnikRegistracijaDto.Email,
                Ime = korisnikRegistracijaDto.Ime,
                Prezime = korisnikRegistracijaDto.Prezime,
                JMBG = korisnikRegistracijaDto.JMBG,
                BrojTelefona = korisnikRegistracijaDto.BrojTelefona,
                DatumUclanjenja = DateTime.Now.ToString(),
                LozinkaHash = passwordHash,
                LozinkaSalt = passwordSalt,
                Status = true,
                IdUloge = 2
            };

            _korisnikService.Add(user);

            return new SuccessDataResult<Korisnik>(user, Messages.Registered);
        }

        public IDataResult<Korisnik> RegisterRadnik(KorisnikRegistracijaDto korisnikRegistracijaDto)
        {
            HashingHelper.CreatePasswordHash(korisnikRegistracijaDto.Lozinka!,
                                              out byte[] passwordHash,
                                              out byte[] passwordSalt);
            var user = new Korisnik();
            if (korisnikRegistracijaDto.NazivUloge == "radnik")
            {
                user = new Korisnik
                {
                    Email = korisnikRegistracijaDto.Email,
                    Ime = korisnikRegistracijaDto.Ime,
                    Prezime = korisnikRegistracijaDto.Prezime,
                    JMBG = korisnikRegistracijaDto.JMBG,
                    BrojTelefona = korisnikRegistracijaDto.BrojTelefona,
                    DatumUclanjenja = DateTime.Now.ToString(),
                    LozinkaHash = passwordHash,
                    LozinkaSalt = passwordSalt,
                    Status = true,
                    IdUloge = 1
                };
            }
            else
            {
                user = new Korisnik
                {
                    Email = korisnikRegistracijaDto.Email,
                    Ime = korisnikRegistracijaDto.Ime,
                    Prezime = korisnikRegistracijaDto.Prezime,
                    JMBG = korisnikRegistracijaDto.JMBG,
                    BrojTelefona = korisnikRegistracijaDto.BrojTelefona,
                    DatumUclanjenja = DateTime.Now.ToString(),
                    LozinkaHash = passwordHash,
                    LozinkaSalt = passwordSalt,
                    Status = false,
                    IdUloge = 2
                };
            }


            _korisnikService.Add(user);

            return new SuccessDataResult<Korisnik>(user, Messages.Registered);
        }

        public IResult UserExists(string email)
        {
            if (_korisnikService.GetByEmail(email).Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
