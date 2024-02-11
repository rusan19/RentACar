using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService userService;
        public UsersController(IUserService userService) 
        {
            this.userService = userService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = userService.GetAll();
            return Ok(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            return Ok(userService.GetById(id));
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            return Ok(userService.Add(user));
        }


        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            return Ok(userService.Update(user));
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            return Ok(userService.Delete(id));
        }
    }
}
