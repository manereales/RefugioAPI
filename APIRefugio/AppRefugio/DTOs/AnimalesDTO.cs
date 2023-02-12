using AppRefugio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace AppRefugio.DTOs
{
    public class AnimalesDTO
    {
        public int Id { get; set; }

        public string Especie { get; set; }
        
        public string Nombre { get; set; }
        
        public bool Vacunas { get; set; }
        
        public int Edad { get; set; }
        
        public string Raza { get; set; }
       
        public string Genero { get; set; }
        public bool Adoptado { get; set; }
        public string Descripcion { get; set; }

       public List<VeterinarioDTO> VeterinariosDTO  { get; set; }

    }
}
