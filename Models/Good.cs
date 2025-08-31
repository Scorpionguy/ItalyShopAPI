using System.ComponentModel.DataAnnotations.Schema;

namespace ItalyShopAPI.Models
{
    [Table("goods")]
    public class Good
    {
        public int article { get; set; }

        [Column("g_name")]
        public string gName { get; set; } = null!;

        [Column("category_fk")]
        public int categoryFk { get; set; }
        public string? model { get; set; }

        [Column("g_quantity")]
        public int gQuantity { get; set; }
        public double price { get; set; }
        public int? sale { get; set; }

        [Column("add_date")]
        public DateTime? addDate { get; set; }
        public string? image { get; set; }

        [Column("is_new")]
        public bool isNew { get; set; }

        public Category category { get; set; } = null!;
        public ICollection<OrderItem> orderItems { get; set; } = new List<OrderItem>();
    }
}
