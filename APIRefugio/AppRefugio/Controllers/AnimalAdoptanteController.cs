using AppRefugio.DTOs;
using AppRefugio.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System.Data;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;

namespace AppRefugio.Controllers
{
    [ApiController]
    [Route("api/Adopcion")]

    public class AnimalAdoptanteController : ControllerBase
    {


        private readonly string _connectionString;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AnimalAdoptanteController(IConfiguration icontext, ApplicationDbContext context, IMapper mapper)
        {
            _connectionString = icontext.GetConnectionString("defaultConnection");
            this.context=context;
            this.mapper=mapper;
        }


        [HttpGet]
        public async Task<List<AnimalAdoptanteDTO>> GetAdopciones()
        {


            var lista = await context.Adopcion.Include(x => x.animales).Include(x => x.Adoptante).ToListAsync();

            var map = mapper.Map<List<AnimalAdoptanteDTO>>(lista);

            return map;
        }



        [HttpGet("{id}", Name = "GetAdopcion")]
        public async Task<ActionResult<Adopcion>> GetAdopcion(int id)
        {
            var adopcion = await context.Adopcion.Include(a => a.AnimalesId).Include(a => a.AdoptanteId).FirstOrDefaultAsync(a => a.Id == id);

            if (adopcion == null)
            {
                return NotFound();
            }

            return adopcion;
        }


        [HttpPost]
        public async Task<ActionResult<Adopcion>> PostAdopcion([FromForm] Adopcion adopcion)
        {
            var animal = await context.Animales.FindAsync(adopcion.AnimalesId);
            if (animal == null)
            {
                return NotFound("Animal no encontrado");
            }

            var adoptante = await context.Adoptantes.FindAsync(adopcion.AdoptanteId);
            if (adoptante == null)
            {
                return NotFound("Adoptante no encontrado");
            }

            var nuevaAdopcion = new Adopcion
            {
                AnimalesId = animal.Id,
                AdoptanteId = adoptante.Id,
                FechaAdopcion = adopcion.FechaAdopcion
            };

            context.Adopcion.Add(nuevaAdopcion);
            
                await context.SaveChangesAsync();
            
         

            return CreatedAtAction("GetAdopcion", new { id = nuevaAdopcion.Id }, nuevaAdopcion);
        }

        private bool AdopcionExists(int id)
        {
            return context.Adopcion.Any(e => e.Id == id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdopcion(int id, [FromForm]Adopcion adopcion)
        {
            if (id != adopcion.Id)
            {
                return BadRequest();
            }

            context.Entry(adopcion).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdopcionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Adopcion>> DeleteAdopcion(int id)
        //{
        //    var adopcion = await context.AnimalAdoptantes.FindAsync(id);
        //    if (adopcion == null)
        //    {
        //        return NotFound();
        //    }

        //    context.AnimalAdoptantes.Remove(adopcion);
        //    await context.SaveChangesAsync();

        //    return adopcion;
        //}

       







    }







}