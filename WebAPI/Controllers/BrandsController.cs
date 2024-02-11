using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService brandService;
        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService; 
        }

        [HttpGet("getAll")]
        public IActionResult GetAll() 
        {
            var result = brandService.GetAll();
            return Ok(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            return Ok(brandService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(Brand brand) 
        {
            return Ok(brandService.Add(brand));
        }


        [HttpPost("update")]
        public IActionResult Update(Brand brand)
        {
            return Ok(brandService.Update(brand));
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            return Ok(brandService.Delete(id));
        }

    }
}
