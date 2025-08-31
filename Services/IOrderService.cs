using ItalyShopAPI.DTOs;
using ItalyShopAPI.Models;

namespace ItalyShopAPI.Services
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDTO>> GetAllOrderAsync();
        public Task<OrderDTO> GetOrderByIdAsync(string orderId);
        public Task<IEnumerable<OrderDTO>> GetOrderByStatusAsync(string status);
        //public Task<Order> CreateOrderAsync();
    }
}
