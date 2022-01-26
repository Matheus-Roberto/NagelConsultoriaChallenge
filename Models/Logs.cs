using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NagelConsultoriaChallenge.Models
{
    [Table("Logs")]
    public class Logs
    {
        [Column("Id")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Column("Details")]
        [Display(Name = "Detales")]
        public string Details { get; set; }

    }
}
