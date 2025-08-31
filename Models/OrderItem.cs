using System.ComponentModel.DataAnnotations.Schema;

namespace ItalyShopAPI.Models
{

    [Table("order_items")]
    public class OrderItem
    {
        [Column("id_items")]
        public int idItems { get; set; }

        [Column("order_id_fk")]
        public string orderIdFk { get; set; } = null!;
        
        [Column("article_fk")]
        public int articleFk { get; set; }

        [Column("o_quantity")]
        public int oQuantity { get; set; }

        [Column("price_at_purchase")]
        public double priceAtPurchase { get; set; }

        public Order order { get; set; } = null!;
        public Good good { get; set; } = null!;
    }
}
