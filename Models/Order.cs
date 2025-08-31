using System.ComponentModel.DataAnnotations.Schema;

namespace ItalyShopAPI.Models
{
    [Table("orders")]
    public class Order
    {
        [Column("id_order")]
        public string idOrder { get; set; } = null!;
        
        [Column("id_client_fk")]
        public string idClientFk { get; set; } = null!;
        
        [Column("order_date")]
        public DateTime orderDate { get; set; }
        
        [Column("payment_status")]
        public string paymentStatus { get; set; } = null!;
        
        [Column("total_amount")]
        public double totalAmount { get; set; }

        public Client client { get; set; } = null!;
        public ICollection<OrderItem> orderItems { get; set; } = new List<OrderItem>();
    }
}
