using System.ComponentModel.DataAnnotations.Schema;

namespace ItalyShopAPI.Models
{
    [Table("log")]
    public class Logs
    {
        [Column("id_log")]
        public int idLog { get; set; }

        [Column("id_emp_fk")]
        public int idEmpFk { get; set; }
        public string action { get; set; } = null!;

        [Column("log_date")]
        public DateTime logDate { get; set; }

        [Column("log_time")]
        public TimeSpan logTime { get; set; }

        public Employee employee { get; set; } = null!;
    }
}
