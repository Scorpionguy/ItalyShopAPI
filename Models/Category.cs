using System.ComponentModel.DataAnnotations.Schema;

namespace ItalyShopAPI.Models
{
    [Table("category")]
    public class Category
    {
        [Column("id_category")]
        public int idCategory { get; set; }
        public string title { get; set; } = null!;

        public ICollection<Good> goods { get; set; } = new List<Good>();
    }
}
