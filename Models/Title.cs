using System.ComponentModel.DataAnnotations.Schema;

namespace ItalyShopAPI.Models
{
    [Table("title")]
    public class Title
    {


        [Column("id_title")]
        public int idTitle { get; set; }

        [Column("title_name")]
        public string titleName { get; set; } = null!;

        public ICollection<Employee> employees { get; set; } = new List<Employee>();
    }
}
