using System.ComponentModel.DataAnnotations.Schema;

namespace GO2PET.Models
{
    [Table("t-mascota")]
    public class Mascota
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public long Id { get; set; }
        public string? Nombre { get; set; } 
        public string? Raza { get; set; } 
        public string? Color { get; set; } 
        public DateTime FechaNacimiento { get; set; } 
    }
}