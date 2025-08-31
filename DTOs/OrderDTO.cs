using ItalyShopAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItalyShopAPI.DTOs
{
    public class OrderDTO
    {
        public string Id { get; set; } = null!;

        public DateTime orderDate { get; set; }

        public string paymentStatus { get; set; } = null!;

        public double totalAmount { get; set; }

        public string idClientFk { get; set; } = null!;

        public string clientName { get; set; } = null!;
        public ICollection<OrderItem> orderItems { get; set; } = new List<OrderItem>();
        public ICollection<GoodDTO>? goods { get; set; }
    }
}
