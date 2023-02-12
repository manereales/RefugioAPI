namespace AppRefugio.DTOs
{
    public class VeterinarioCreacionDTO
    {
       
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public List<int> AnimalesIds { get; set; }

    }
}
