using ItalyShopAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItalyShopAPI.Models
{
    [Table("employee")]
    public class Employee
    {
        [Column("id_empl")]
        public int idEmp { get; set; }
        [Column("e_family")]
        public string eFamily { get; set; } = null!;
        [Column("e_name")]
        public string eName { get; set; } = null!;
        [Column("e_otchestvo")]
        public string? eOtchestvo { get; set; }
        [Column("job_title_fk")]
        public int jobTitleFk { get; set; }
        public string login { get; set; } = null!;
        public string password { get; set; } = null!; 
        public Title jobTitle { get; set; } = null!;
        public ICollection<Logs> logs { get; set; } = new List<Logs>();
    }
}
