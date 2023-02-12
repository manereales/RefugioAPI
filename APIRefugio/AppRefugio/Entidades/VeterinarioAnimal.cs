namespace AppRefugio.Entidades
{
    public class VeterinariosAnimal 
    {
        public int VeterinarioId { get; set; } 
        public int AnimalesId { get; set; }  
        public Veterinarios Veterinario { get; set; }
        public Animales Animales { get; set; }

    }
}
