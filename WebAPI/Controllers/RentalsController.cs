using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService rentalService;

        public RentalsController(IRentalService rentalService)
        {
            this.rentalService = rentalService;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = rentalService.GetAll();
            return Ok(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = rentalService.GetById(id);
            return Ok(result);
        }
        [HttpGet("getDetails")]
        public IActionResult GetCarDetails()
        {
            var result = rentalService.GetRentalDetails();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Post(Rental rental)
        {
            return Ok(rentalService.Add(rental));
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            return Ok(rentalService.Update(rental));
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            return Ok(rentalService.Delete(id));
        }

        [HttpPost("updateReturnDate")]
        public IActionResult UpdateReturn(int id)
        {

            return Ok(rentalService.UpdateReturnDate(id));

        }

    }
}
