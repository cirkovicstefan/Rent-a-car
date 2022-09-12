using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomobilController : ControllerBase
    {
        private readonly IAutomobilService _automobilService;
        public AutomobilController(IAutomobilService automobilService)
        {
            _automobilService = automobilService;
        }
        [HttpPost("add")]
        public IActionResult Add(Automobil automobil)
        {
            var result = _automobilService?.Add(automobil);

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

            var result = _automobilService?.GetAll();

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int idAutomobil)
        {

            var result = _automobilService?.GetById(idAutomobil);

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getautodetails")]
        public IActionResult GetAutomobilDetails(int autoId)
        {
            var result = _automobilService.GetAutomobilDetails(autoId);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getautodetailmodelby")]
        public IActionResult GetAutomobilModelDetails(int modelId)
        {
            var result = _automobilService.GetAutomobilDetails(modelId);

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
        public IActionResult Update(Automobil automobil)
        {
            var result = _automobilService?.Update(automobil);

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
        public IActionResult Delete(Automobil automobil)
        {
            var result = _automobilService?.Delete(automobil);

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getcenabetween/{cena1}/{cena2}")]
        public IActionResult GetAutomobiliCenaBetween(decimal cena1,decimal cena2)
        {
            var result = _automobilService.GetAutomobiliCenaBetween(cena1, cena2);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
   
}
