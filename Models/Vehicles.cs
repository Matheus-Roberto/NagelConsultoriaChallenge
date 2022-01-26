using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NagelConsultoriaChallenge.Models
{
    [Table("Vehicles")]
    public class Vehicles
    {
        [Column("Id")]
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Column("Plate")]
        [Display(Name = "Placa")]
        public string Plate { get; set; }

        [Column("Brand")]
        [Display(Name = "Marca")]
        public string Brand { get; set; }

        [Column("Color")]
        [Display(Name = "Cor")]
        public string Color { get; set; }

        [Column("FactoryYear")]
        [Display(Name = "Ano de Fábrica")]
        public string FactoryYear { get; set; }

        [Column("RegistrationData")]
        [Display(Name = "Data de Cadastro")]
        public DateTime RegistrationData { get; set; }

        [Column("Active")]
        [Display(Name = "Ativo")]
        public bool Active { get; set; }

    }
}
