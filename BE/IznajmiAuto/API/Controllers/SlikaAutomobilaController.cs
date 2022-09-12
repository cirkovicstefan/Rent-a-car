using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlikaAutomobilaController : ControllerBase
    {
        private readonly ISlikeAutomobilaService _slikeAutomobilaService;
        private readonly IConfiguration _configuration;
        public SlikaAutomobilaController(ISlikeAutomobilaService slikeAutomobilaService, IConfiguration configuration)
        {
            _slikeAutomobilaService = slikeAutomobilaService;
            _configuration = configuration;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] SlikaAutomobila slika, [FromForm(Name = "slika")] IFormFile file)
        {
            var result = _slikeAutomobilaService.Add(slika, file);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("delete")]
        public IActionResult Delete(SlikaAutomobila slikaAutomobila)
        {
            var result = _slikeAutomobilaService.Delete(slikaAutomobila);

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
        public IActionResult Update([FromForm] SlikaAutomobila slika, [FromForm(Name = "slika")] IFormFile file)
        {
            var result = _slikeAutomobilaService.Update(slika, file);

            if (result.Success)
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
            var result = _slikeAutomobilaService.GetAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("getalldetail")]
        public IActionResult GetAllDetail(int idSlike)
        {
            var result = _slikeAutomobilaService.GetSlikeDetails(idSlike);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _slikeAutomobilaService.GetById(id);

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
