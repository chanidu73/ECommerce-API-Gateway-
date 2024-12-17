using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Models;
using OrderService.Repositories;

namespace OrderService.Services
{
    public class PaymentService:IPaymentService
    {
        private readonly IPaymentRepository _repository;
        public PaymentService(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task AddPaymentAsync(PaymentModel payment)
        {
            await _repository.AddPaymentAsync(payment);
        }

        public async Task<PaymentModel> GetPaymentByOrderIdAsync(int orderId)
        {
            return await _repository.GetPaymentByOrderIdAsync(orderId);
        }

        public async Task UpdatePaymentAsync(PaymentModel payment)
        {
            await _repository.UpdatePaymentAsync(payment);
        }
    }
}