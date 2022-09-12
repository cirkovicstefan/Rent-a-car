using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IstorijaIznajmljivanjaController : ControllerBase
    {
        private readonly IIstorijaIznajmljivanjaService _istorijaIznajmljivanjaService;
        public IstorijaIznajmljivanjaController(IIstorijaIznajmljivanjaService istorijaIznajmljivanjaService)
        {
            _istorijaIznajmljivanjaService = istorijaIznajmljivanjaService;
        }
        [HttpPost("add")]
        public IActionResult Add(IstorijaIznajmljivanja istorijaIznajmljivanja)
        {
            var result = _istorijaIznajmljivanjaService?.Add(istorijaIznajmljivanja);

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

            var result = _istorijaIznajmljivanjaService?.GetAll();

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
        public IActionResult GetAllDetail(int idIstorija)
        {
            var result = _istorijaIznajmljivanjaService.GetIstorijaDetails(idIstorija);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getistorijaiznajmljivanjabyid")]
        public IActionResult GetIstorijaById(int istorijaId)
        {
            var result = _istorijaIznajmljivanjaService.GetById(istorijaId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }


        [HttpPut("update")]
        public IActionResult Update(IstorijaIznajmljivanja istorijaIznajmljivanja)
        {
            var result = _istorijaIznajmljivanjaService?.Update(istorijaIznajmljivanja);

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
        public IActionResult Delete(IstorijaIznajmljivanja istorijaIznajmljivanja)
        {
            var result = _istorijaIznajmljivanjaService?.Delete(istorijaIznajmljivanja);

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getistorijaiznajmljivanjabyidKorisnika")]
        public IActionResult GetIstorijaByIdKorisnika(int idKorisnika)
        {
            var result = _istorijaIznajmljivanjaService.GetIstorijaByIdKorisnik(idKorisnika);

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
