using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using unittesting.DTOs;
using unittesting.Interfaces;

namespace unittesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("getallorders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(_orderService.GetAllOrders());
        }

        [HttpPost]
        [Route("delete/order")]
        public async Task<IActionResult> DeleteOrder([FromBody] int idOrder)
        {
            _orderService.DeleteOrder(idOrder);
            return Ok();
        }

        [HttpPost]
        [Route("create/order")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest createOrderRequest)
        {
            _orderService.CreateOrder(createOrderRequest.IdCustomer, createOrderRequest.Code);
            return Ok();
        }



    }
}
