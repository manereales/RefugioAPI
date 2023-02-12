using AppRefugio.Entidades;
using AppRefugio.Migrations;

namespace AppRefugio.DTOs
{
    public class AnimalAdoptanteDTO
    {
        public int Id { get; set; }
        public int AnimalesId { get; set; }
        public int AdoptanteId { get; set; }
        //public Animales Animales { get; set; }
        //public Adoptante Adoptante { get; set; }
        public DateTime FechaAdopcion { get; set; }
        public List<AnimalAdoptante> AnimalAdoptantes { get; set; }

    }
}
