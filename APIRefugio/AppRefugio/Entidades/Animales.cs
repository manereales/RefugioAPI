using System.ComponentModel.DataAnnotations;

namespace AppRefugio.Entidades
{
    public class Animales
    {
        public int Id { get; set; }
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
        public bool Adoptado { get; set; }
        public string Descripcion { get; set; }

        //public List<Adoptante> Adoptantes { get; set; } 
        public List<VeterinariosAnimal> VeterinariosAnimales { get; set; }
        


    }
}
