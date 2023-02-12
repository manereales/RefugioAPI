namespace AppRefugio.Entidades
{
    public class AnimalAdoptante
    {
        public int Id { get; set; } 
        public int AnimalesId { get; set; }
        public int AdoptanteId { get; set; }
        public Animales Animales { get; set; }
        public Adoptante Adoptante { get; set; }
        public DateTime FechaAdopcion { get; set; }

    }
}
