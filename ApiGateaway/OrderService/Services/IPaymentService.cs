using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Models;

namespace OrderService.Services
{
    public interface IPaymentService
    {
        Task<PaymentModel> GetPaymentByOrderIdAsync(int orderId);
        Task AddPaymentAsync(PaymentModel payment);
        Task UpdatePaymentAsync(PaymentModel payment);
    }
}