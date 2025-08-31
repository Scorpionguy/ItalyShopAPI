using ItalyShopAPI.DTOs;
using ItalyShopAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ItalyShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IOrderService _ordersService;
        private readonly ILogService _logService;

        public OrderController(ILogger<ProductController> logger, IOrderService ordersService, ILogService logService)
        {
            _logger = logger;
            _ordersService = ordersService;
            _logService = logService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<OrderDTO>> GetAll()
        {
            var orders = await _ordersService.GetAllOrderAsync();

            return Ok(orders);
        }
        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<OrderDTO>> GetById(string id)
        {
            var orders = await _ordersService.GetOrderByIdAsync(id);

            return Ok(orders);
        }

        [HttpGet("by-status/{paymentStatus}")]
        public async Task<ActionResult<OrderDTO>> GetByStatus(string paymentStatus)
        {
            var orders = await _ordersService.GetOrderByStatusAsync(paymentStatus);

            return Ok(orders);
        }
    }
}
