using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Models;

namespace OrderService.Repositories
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly OrderDbContext _context ;
        public PaymentRepository(OrderDbContext context)
        {
            _context= context;
        }

        public async Task AddPaymentAsync(PaymentModel payment)
        {
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();
        }

        public async Task<PaymentModel> GetPaymentByOrderIdAsync(int orderId)
        {
            return await _context.Payments
                .FirstOrDefaultAsync(p => p.OrderId == orderId);        }

        public async Task UpdatePaymentAsync(PaymentModel payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
        }
    }
}