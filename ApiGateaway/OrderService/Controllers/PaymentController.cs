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
    public class PaymentController:ControllerBase
    {
        private readonly IPaymentService _service;
        public PaymentController(IPaymentService service)
        {
            _service =service;
        }


        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<PaymentModel>> GetPaymentByOrderId(int orderId)
        {
            var payment = await _service.GetPaymentByOrderIdAsync(orderId);
            if (payment == null) return NotFound($"Payment for Order ID {orderId} not found.");
            return Ok(payment);
        }

        [HttpPost]
        public async Task<ActionResult> AddPayment([FromBody] PaymentModel payment)
        {
            if (payment == null) return BadRequest("Payment data is invalid.");

            await _service.AddPaymentAsync(payment);
            return CreatedAtAction(nameof(GetPaymentByOrderId), new { orderId = payment.OrderId }, payment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePayment(int id, [FromBody] PaymentModel payment)
        {
            if (id != payment.PaymentId) return BadRequest("Payment ID mismatch.");

            var existingPayment = await _service.GetPaymentByOrderIdAsync(payment.OrderId);
            if (existingPayment == null) return NotFound($"Payment with ID {id} not found.");

            await _service.UpdatePaymentAsync(payment);
            return NoContent();
        }
    }
}