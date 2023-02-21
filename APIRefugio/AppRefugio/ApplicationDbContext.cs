using AppRefugio.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppRefugio
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VeterinariosAnimal>().HasKey(x => new { x.VeterinarioId, x.AnimalesId });
            //modelBuilder.Entity<AnimalAdoptante>().HasKey(x => new { x.AdoptanteId, x.AnimalesId });


        }

        public DbSet<Animales> Animales { get; set; }
        public DbSet<Veterinarios> Veterinarios { get; set; }
        public DbSet<VeterinariosAnimal> veterinariosAnimales { get; set; }
        public DbSet<Adoptante> Adoptantes { get; set; }
        public DbSet<Adopcion> Adopcion { get; set; } 

    }
}
