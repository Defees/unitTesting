using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using unittesting.DTOs;
using unittesting.Entities;
using unittesting.Interfaces;

namespace unittesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("getallcustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(_customerService.GetAllCustomers());
        }

        [HttpPost]
        [Route("getcustomerorders")]
        public async Task<IActionResult> GetCustomerOrders([FromBody] int idCustomer)
        {
            return Ok(_customerService.GetCustomerOrders(idCustomer));
        }

        [HttpPost]
        [Route("create/customer")]
        public async Task<IActionResult> CreateCustomer([FromBody] string name)
        {
            _customerService.CreateCustomer(name);
            return Ok();
        } 

        [HttpPost]
        [Route("delete/customer")]
        public async Task<IActionResult> DeleteCustomer([FromBody] int id)
        {
            _customerService.DeleteCustomer(id);
            return Ok();
        }

        [HttpPost]
        [Route("updatecustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequest updateCustomerRequest)
        {
            _customerService.UpdateCustomer(updateCustomerRequest.Id, updateCustomerRequest.NewName);
            return Ok();
        }

    }
}
