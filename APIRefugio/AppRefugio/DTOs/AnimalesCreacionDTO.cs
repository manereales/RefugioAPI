using System.ComponentModel.DataAnnotations;

namespace AppRefugio.DTOs
{
    public class AnimalesCreacionDTO
    {
        [Required]
        public string Especie { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public bool Vacunas { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public string Raza { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public bool Adoptado { get; set; } 
        public string Descripcion { get; set; }

    }
}
