using Business.Abstract;
using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll() 
        {
            var result = carService.GetAll();
            return Ok(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = carService.GetById(id);
            return Ok(result);
        }
        [HttpGet("getDetails")]
        public IActionResult GetCarDetails()
        {
            var result = carService.GetCarDetails();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Post(Car car)
        {
            return Ok(carService.Add(car));
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            return Ok(carService.Update(car));
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            return Ok(carService.Delete(id));
        }


    }
}
