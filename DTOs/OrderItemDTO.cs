using ItalyShopAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItalyShopAPI.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }

        public string orderIdFk { get; set; } = null!;

        public int articleFk { get; set; }

        public int oQuantity { get; set; }

        public double priceAtPurchase { get; set; }

        public Order order { get; set; } = null!;
        public Good good { get; set; } = null!;
    }
}
