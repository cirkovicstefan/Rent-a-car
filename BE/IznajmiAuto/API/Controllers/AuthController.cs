using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login(KorisnikLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);

            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("registerradnik")]
        public IActionResult RegisterRadnik(KorisnikRegistracijaDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email!);

            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }

            var registerResult = _authService.RegisterRadnik(userForRegisterDto);

            if (registerResult.Success)
            {
                var result = _authService.CreateAccessToken(registerResult.Data);

                if (result.Success)
                {
                    return Ok(result);
                }
            }

            return BadRequest(registerResult);
        }


        [HttpPost("registerkorisnik")]
        public IActionResult RegisterKorisnik(KorisnikRegistracijaDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email!);

            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }

            var registerResult = _authService.RegisterKorisnik(userForRegisterDto);

            if (registerResult.Success)
            {
                var result = _authService.CreateAccessToken(registerResult.Data);

                if (result.Success)
                {
                    return Ok(result);
                }
            }

            return BadRequest(registerResult);
        }


        [HttpPost("promenalozinke")]
        public IActionResult ChangePassword(KorisnikPromenaLozinkeDto userForChangingPasswordDto)
        {
            var result = _authService.ChangePassword(userForChangingPasswordDto);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
