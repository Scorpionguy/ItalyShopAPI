using ItalyShopAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItalyShopAPI.DTOs
{
    public class GoodDTO
    {
        public int Article { get; set; }
        public string Name { get; set; } = null!;
        public string? CategoryName { get; set; }
        public string? Model { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int? Sale { get; set; }
        public string? Image { get; set; }
        public bool IsNew { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Size> Sizes { get; set; } = new List<Size>();
    }
}
