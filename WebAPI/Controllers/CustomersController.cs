using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = customerService.GetAll();
            return Ok(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            return Ok(customerService.GetById(id).Data);
        }
        [HttpGet("getDetails")]
        public IActionResult GetCustomerDetails()
        {
            var result = customerService.GetCustomerDetails();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            return Ok(customerService.Add(customer));
        }


        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            return Ok(customerService.Update(customer));
        }

        [HttpPost("delete")]
        public IActionResult Delete(int id)
        {
            return Ok(customerService.Delete(id));
        }

    }
}
