using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelAutomobilaController : ControllerBase
    {
        private readonly IModelAutomobilaService _modelAutomobilaService;
        public ModelAutomobilaController(IModelAutomobilaService modelAutomobilaService)
        {
            _modelAutomobilaService = modelAutomobilaService;
        }
        [HttpPost("add")]
        public IActionResult Add(ModelAutomobila modelAutomobila)
        {
            var result = _modelAutomobilaService?.Add(modelAutomobila);

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

            var result = _modelAutomobilaService?.GetAll();

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

            var result = _modelAutomobilaService?.GetModelAutomobilaDetails();

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
        public IActionResult Update(ModelAutomobila modelAutomobila)
        {
            var result = _modelAutomobilaService?.Update(modelAutomobila);

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
        public IActionResult Delete(ModelAutomobila modelAutomobila)
        {
            var result = _modelAutomobilaService?.Delete(modelAutomobila);

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
