using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorService colorService;
        public ColorsController(IColorService colorService)
        {
            this.colorService = colorService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = colorService.GetAll();
            return Ok(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = colorService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Post(Color color)
        {
            return Ok(colorService.Add(color));
        }

        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            return Ok(colorService.Update(color));
        }
        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            return Ok(colorService.Delete(id));
        }
    }
}
