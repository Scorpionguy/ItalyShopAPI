using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItalyShopAPI.Models
{
    [Table("sizes")]
    public class Size
    {
        
        [Column("id_size")] 
        public int idSize { get; set; }

        [Column("name_s")]
        public string name { get; set; } = null!;

        [Column("quantity_s")]
        public int quantity { get; set; }

        [Column("good_fk")]
        public int goodFk{ get; set; }

        public Good good { get; set; } = null!;
    }
}
