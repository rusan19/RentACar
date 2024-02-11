using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            this.carImageService = carImageService;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll(int id) 
        {
            var result = carImageService.GetAll();
            return Ok(result);  
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm]IFormFile file,[FromForm] CarImage carImage)
        {
            var result = carImageService.Add(file,carImage);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            var result = carImageService.Delete(id);
            return Ok(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file,[FromForm] CarImage carImage)
        {
            var result = carImageService.Update(file, carImage);
            return Ok(result);
        }

        [HttpGet("getByCarId")]
        public IActionResult GetImagesByCarId(int carId)
        {
            var result = carImageService.GetImagesByCarId(carId);
            return Ok(result);
        }

    }
}
