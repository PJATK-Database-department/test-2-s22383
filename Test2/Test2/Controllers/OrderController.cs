using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test2.Dto;
using Test2.Exception;
using Test2.Service;

namespace Test2.Controllers
{
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPatch("{orderId}")]
        public async Task<IActionResult> AddProductToOrder(int orderId,[FromBody] ProductsDto products)
        {
            try
            {
                await _orderService.AddProductToOrder(orderId, products.Products);
                return Ok();
            }
            catch (NotFoundException e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }
    }
}