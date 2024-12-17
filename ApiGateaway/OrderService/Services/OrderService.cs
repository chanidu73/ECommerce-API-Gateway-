using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderService.Models;
using OrderService.Repositories;

namespace OrderService.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateOrderAsync(OrderModel order)
        {
            await _repository.CreateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            await _repository.DeleteOrderAsync(orderId);
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            return await _repository.GetAllOrdersAsync();
        }

        public async Task<OrderModel> GetOrderByIdAsync(int orderId)
        {
            return await _repository.GetOrderByIdAsync(orderId);
        }

        public async Task UpdateOrderAsync(OrderModel order)
        {
            await _repository.UpdateOrderAsync(order);
        }
    }
}