using AppRefugio.Entidades;

namespace AppRefugio.DTOs
{
    public class AnimalAdoptanteCreacionDTO
    {
        public int AnimalesId { get; set; }
        public int AdoptanteId { get; set; }
        //public Animales Animales { get; set; }
        //public Adoptante Adoptante { get; set; }
        public DateTime FechaAdopcion { get; set; }
        public string Descripcion { get; set; } 
        //public List<int> animalId { get; set; }  

    }
}
