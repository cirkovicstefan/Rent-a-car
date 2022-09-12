using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UgovorIznajmljivanjaController : ControllerBase
    {
        private readonly IUgovorIznajmljivanjaService _ugovorIznajmljivanjaService;
        public UgovorIznajmljivanjaController(IUgovorIznajmljivanjaService ugovorIznajmljivanjaService)
        {
            _ugovorIznajmljivanjaService = ugovorIznajmljivanjaService;
        }

        [HttpPost("add")]
        public IActionResult Add(UgovorIznajmljivanja ugovorIznajmljivanja)
        {
            var result = _ugovorIznajmljivanjaService?.Add(ugovorIznajmljivanja);

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

            var result = _ugovorIznajmljivanjaService?.GetAll();

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
        public IActionResult GetAllDetail()
        {

            var result = _ugovorIznajmljivanjaService?.GetDetailDto(0);

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getiznajmljivanjebyid")]
        public IActionResult GetIznjamljivanjeById(int iznajmiId)
        {
            var result = _ugovorIznajmljivanjaService.GetById(iznajmiId);

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
        public IActionResult Update(UgovorIznajmljivanja ugovorIznajmljivanja)
        {
            var result = _ugovorIznajmljivanjaService?.Update(ugovorIznajmljivanja);

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
        public IActionResult Delete(UgovorIznajmljivanja ugovorIznajmljivanja)
        {
            var result = _ugovorIznajmljivanjaService?.Delete(ugovorIznajmljivanja);

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("returnauto")]
        public IActionResult Return(UgovorIznajmljivanja ugovorIznajmljivanja)
        {
            var result = _ugovorIznajmljivanjaService.Return(ugovorIznajmljivanja);
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

