using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodjacController : ControllerBase
    {
        private readonly IProizvodjacAutomobilaService _proizvodjacAutomobilaService;
        public ProizvodjacController(IProizvodjacAutomobilaService proizvodjacAutomobilaService)
        {
            _proizvodjacAutomobilaService = proizvodjacAutomobilaService;
        }
      
        [HttpPost("add")]
        public IActionResult Add(Proizvodjac proizvodjac)
        {
            var result = _proizvodjacAutomobilaService?.Add(proizvodjac);

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
            
           var result = _proizvodjacAutomobilaService?.GetAll();

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
        public IActionResult Update(Proizvodjac proizvodjac)
        {
            var result = _proizvodjacAutomobilaService?.Update(proizvodjac);

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
        public IActionResult Delete(Proizvodjac proizvodjac)
        {
            var result = _proizvodjacAutomobilaService?.Delete(proizvodjac);

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
