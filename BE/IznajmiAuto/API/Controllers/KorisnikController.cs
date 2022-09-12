
using Business.Abstract;
using Core.Entities.Concrate;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _korisnikService;
        public KorisnikController(IKorisnikService korisnikService)
        {
            _korisnikService = korisnikService;
        }
        [HttpPost("add")]
        public IActionResult Add(Korisnik korisnik)
        {
            var result = _korisnikService?.Add(korisnik);

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _korisnikService?.GetAll();

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getallradnici")]
        public IActionResult GetAllRadnici()
        {

            var result = _korisnikService?.GetAllRadnici();

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getallklijenti")]
        public IActionResult GetAllKlijenti()
        {

            var result = _korisnikService?.GetAllKlijenti();

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getdetail")]
        public IActionResult GetKorisnikUloge()
        {

            var result = _korisnikService?.GetKorisnikDetails();

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpPost("update")]
        public IActionResult Update(Korisnik korisnik)
        {
            var result = _korisnikService?.Update(korisnik);

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPut("updatestatus")]
        public IActionResult UpdateStatus([FromBody]int IdKorisnika)
        {
           
            var result = _korisnikService?.UpdateStatus(IdKorisnika);

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }




        [HttpDelete("delete/{IdKorisnika}")]
        public IActionResult Delete(int IdKorisnika)
        {
            var result = _korisnikService?.Delete(IdKorisnika);

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbyemail")]
        public IActionResult GetKorisnikByEmail(string email)
        {
            var x = HttpUtility.UrlDecode(email);
            var result = _korisnikService?.GetByEmail(x);

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
