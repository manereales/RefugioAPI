namespace AppRefugio.Entidades
{
    public class Adopcion
    {
        public int Id { get; set; }
        public int AnimalesId { get; set; }
        public int AdoptanteId { get; set; }
        public string Descripcion { get; set; }
        public Animales animales { get; set; }
        public Adoptante Adoptante { get; set; }
        public DateTime FechaAdopcion { get; set; }

    }
}
