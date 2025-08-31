using ItalyShopAPI.Data;
using ItalyShopAPI.DTOs;
using ItalyShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ItalyShopAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly ItalyShopDbContext _context;
        public OrderService(ItalyShopDbContext db) => _context = db;
        async public Task<IEnumerable<OrderDTO>> GetAllOrderAsync()
        {
            var orders = await _context.Orders.Include(o => o.orderItems).Select(o => new OrderDTO
            {
                Id = o.idOrder,
                orderDate = o.orderDate,
                paymentStatus = o.paymentStatus,
                totalAmount = o.totalAmount,
                goods = o.orderItems.Select(i => new GoodDTO
                {
                    Article = i.good.article,
                    Name = i.good.gName,
                    CategoryName = i.good.category.title,
                    Model = i.good.model,
                    Quantity = i.good.gQuantity,
                    Price = i.good.price,
                    Image = i.good.image
                }).ToList(),
                
            }).ToListAsync();

            return orders;
        }

        async public Task<OrderDTO> GetOrderByIdAsync(string orderId)
        {
            var orders = await _context.Orders.Include(o => o.orderItems).Where(o => o.idOrder == orderId).Select(o => new OrderDTO
            {
                Id = o.idOrder,
                orderDate = o.orderDate,
                paymentStatus = o.paymentStatus,
                totalAmount = o.totalAmount,
                goods = o.orderItems.Select(i => new GoodDTO
                {
                    Article = i.good.article,
                    Name = i.good.gName,
                    CategoryName = i.good.category.title,
                    Model = i.good.model,
                    Quantity = i.good.gQuantity,
                    Price = i.good.price,
                    Image = i.good.image
                }).ToList(),

            }).FirstOrDefaultAsync();

            return orders;
        }
        async public Task<IEnumerable<OrderDTO>> GetOrderByStatusAsync(string status)
        {
            var orders = await _context.Orders.Include(o => o.orderItems).Where(o => o.paymentStatus == status).Select(o => new OrderDTO
            {
                Id = o.idOrder,
                orderDate = o.orderDate,
                paymentStatus = o.paymentStatus,
                totalAmount = o.totalAmount,
                goods = o.orderItems.Select(i => new GoodDTO
                {
                    Article = i.good.article,
                    Name = i.good.gName,
                    CategoryName = i.good.category.title,
                    Model = i.good.model,
                    Quantity = i.good.gQuantity,
                    Price = i.good.price,
                    Image = i.good.image
                }).ToList(),

            }).ToListAsync();

            return orders;
        }
    }
}
