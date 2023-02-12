using AppRefugio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace AppRefugio.DTOs
{
    public class AdoptanteDTO
    {
        public string Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        [EmailAddress]
        public string Direccion { get; set; }
        public string Correo { get; set; }

    }
}
