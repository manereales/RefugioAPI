using AppRefugio.DTOs;
using AppRefugio.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppRefugio.Controllers
{
    [ApiController]
    [Route("api/Adopcion")]

    public class AnimalAdoptanteController: ControllerBase
    {


        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AnimalAdoptanteController(ApplicationDbContext context, IMapper mapper)
        {
            this.context=context;
            this.mapper=mapper;
        }

        [HttpGet]
        public async Task<List<AnimalAdoptanteDTO>> get()
        {
            var entidad = await context.AnimalAdoptantes.ToListAsync();

            var dtos = mapper.Map<List<AnimalAdoptanteDTO>>(entidad);

            return dtos; 
        }

        [HttpGet("{id}", Name = "obtenerAdopcion")]
        public async Task<List<AnimalAdoptanteDTO>> get(int id)
        {
            var entidad = await context.AnimalAdoptantes.FirstOrDefaultAsync(x => x.AdoptanteId == id);

            var dtos = mapper.Map<List<AnimalAdoptanteDTO>>(entidad);

            return dtos;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] AnimalAdoptanteCreacionDTO animalAdoptanteCreacionDTO)
        {

            if (animalAdoptanteCreacionDTO.animalId == null)
            {
                return BadRequest("no se puede agregar un veterinario");
            }

            var existe = await context.Animales.Where(x => animalAdoptanteCreacionDTO.animalId.Contains(x.Id)).ToListAsync();

            //var existe2 = await context.Animales.FirstOrDefaultAsync(x => x.Id == animalesId);

            if (animalAdoptanteCreacionDTO.animalId.Count != existe.Count)
            {
                return BadRequest("no existe uno de los animales ingresados");
            }

            var adopcion = mapper.Map<AnimalAdoptante>(animalAdoptanteCreacionDTO);

            if (existe2 == true)
            {
                return BadRequest("el animal ya está adoptado");
            }

            context.Add(adopcion);
            await context.SaveChangesAsync();

            var dtos = mapper.Map<AnimalAdoptanteDTO>(adopcion);

            return CreatedAtRoute("obtenerAdopcion", new { id = adopcion.Id }, dtos);

            //return Ok();
        }

    }
}
