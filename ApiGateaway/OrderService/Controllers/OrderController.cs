using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Services;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllOrders()
        {
            var orders= await _service.GetAllOrdersAsync();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _service.GetOrderByIdAsync(id);
            if (order ==null)return NotFound();
            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderModel order)
        {
            if(!ModelState.IsValid) return BadRequest();
            await _service.CreateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id )
        {
            var order = await _service.GetOrderByIdAsync(id);
            if(order == null)return NotFound();
            await _service.DeleteOrderAsync(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateOrder(int id , OrderModel order)
        {
            if(id != order.OrderId)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)return NotFound();
            await _service.UpdateOrderAsync(order);
            return Ok(order);
        }

    }
}