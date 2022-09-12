using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervacijaController : ControllerBase
    {
        private readonly IRezervacijaAutomobilaService _rezervacijaAutomobilaService;
        public RezervacijaController(IRezervacijaAutomobilaService rezervacijaAutomobilaService)
        {
            _rezervacijaAutomobilaService = rezervacijaAutomobilaService;
        }
        [HttpPost("add")]
        public IActionResult Add(Rezervacija rezervacija)
        {
            var result = _rezervacijaAutomobilaService?.Add(rezervacija);

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

            var result = _rezervacijaAutomobilaService?.GetAll();

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getalldetail")]
        public IActionResult GetAllDetail(int idRezervacije)
        {

            var result = _rezervacijaAutomobilaService?.GetRezervacijeDetails(idRezervacije);

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getRezervacijaById")]
        public IActionResult GetAutomobilModelDetails(int rezId)
        {
            var result = _rezervacijaAutomobilaService.GetById(rezId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpPost("update")]
        public IActionResult Update(Rezervacija rezervacija)
        {
            var result = _rezervacijaAutomobilaService?.Update(rezervacija);

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpPost("delete")]
        public IActionResult Delete(Rezervacija rezervacija)
        {
            var result = _rezervacijaAutomobilaService?.Delete(rezervacija);

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyidkorisnik")]
        public IActionResult GetRezervacijaByIdKorisnik(int idKorisnika)
        {
            var result = _rezervacijaAutomobilaService.GetRezervacijeByIdKorisnika(idKorisnika);

            if (result.Success)
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
