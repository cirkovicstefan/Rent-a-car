using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CenaRezervacijePoDanuController : ControllerBase
    {
        private readonly ICenaIznajmljivanjaPoDanuService _cenaIznajmljivanjaPoDanuService;
        public CenaRezervacijePoDanuController(ICenaIznajmljivanjaPoDanuService cenaIznajmljivanjaPoDanuService)
        {
            _cenaIznajmljivanjaPoDanuService = cenaIznajmljivanjaPoDanuService;
        }
        [HttpPost("add")]
        public IActionResult Add(CenaIznjmljivanjaPoDanu cenaIznjmljivanjaPoDanu)
        {
            var result = _cenaIznajmljivanjaPoDanuService?.Add(cenaIznjmljivanjaPoDanu);

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

            var result = _cenaIznajmljivanjaPoDanuService?.GetAll();

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getallDetails")]
        public IActionResult GetCenaPoDanuDetails()
        {

            var result = _cenaIznajmljivanjaPoDanuService?.GetCenaPoDanuDetails(0);

            if (result!.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getcenapodanubyid")]
        public IActionResult GetCenaPoDanuById(int cenaId)
        {
            var result = _cenaIznajmljivanjaPoDanuService.GetById(cenaId);

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
        public IActionResult Update(CenaIznjmljivanjaPoDanu cenaIznjmljivanjaPoDanu)
        {
            var result = _cenaIznajmljivanjaPoDanuService?.Update(cenaIznjmljivanjaPoDanu);

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
        public IActionResult Delete(CenaIznjmljivanjaPoDanu cenaIznjmljivanjaPoDanu)
        {
            var result = _cenaIznajmljivanjaPoDanuService?.Delete(cenaIznjmljivanjaPoDanu);

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
