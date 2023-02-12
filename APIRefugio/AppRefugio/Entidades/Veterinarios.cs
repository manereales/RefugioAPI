﻿namespace AppRefugio.Entidades
{
    public class Veterinarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Email { get; set; }
        public List<VeterinariosAnimal> VeterinarioAnimales { get; set; }    


    }
}
