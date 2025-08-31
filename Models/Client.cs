using System.ComponentModel.DataAnnotations.Schema;

namespace ItalyShopAPI.Models
{
    [Table("client")]
    public class Client
    {
        [Column("id_client")]
        public string idClient { get; set; } = null!;
        [Column("c_name")]
        public string cName { get; set; } = null!;
        [Column("c_family")]
        public string cFamily { get; set; } = null!;
        [Column("c_otchestvo")]
        public string? cOtchestvo { get; set; }
        public string? index { get; set; }
        public string? adress { get; set; }
        [Column("c_phone")]
        public string? cPhone { get; set; }
        [Column("c_mail")]
        public string? cMail { get; set; }

        public ICollection<Order> orders { get; set; } = new List<Order>();
    }
}
