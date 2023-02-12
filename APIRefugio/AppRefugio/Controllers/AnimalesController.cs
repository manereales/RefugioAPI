using AppRefugio.DTOs;
using AppRefugio.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppRefugio.Controllers
{
    [ApiController]
    [Route("api/animales")]
    public class AnimalesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AnimalesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<AnimalesDTO>>> Get()
        {
            var animales = await context.Animales.ToListAsync();

            var dtos = mapper.Map<List<AnimalesDTO>>(animales);

            return dtos;
        }

        [HttpGet("{id}", Name = "obtenerAnimales")]
        public async Task<ActionResult<AnimalesDTO>> Get(int id)
        {
            var entidades = await context.Animales.FirstOrDefaultAsync(x => x.Id == id);

            if (entidades == null)
            {
                return NotFound();
            }

            var dtos = mapper.Map<AnimalesDTO>(entidades);

            return dtos;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm]AnimalesCreacionDTO animalesCreacionDTO)
        {
            var animales = mapper.Map<Animales>(animalesCreacionDTO);

            context.Add(animales);
            await context.SaveChangesAsync();

            var dtos = mapper.Map<AnimalesDTO>(animales);

            return CreatedAtRoute("obtenerAnimales", new { Id = animales.Id }, dtos);

        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm]AnimalesCreacionDTO animalesCreacionDTO)
        {
            var entidades = await context.Animales.FirstOrDefaultAsync(x => x.Id == id);

            if (entidades == null)
            {
                return BadRequest();
            }

            var mapeo = mapper.Map<Animales>(entidades);
            entidades.Id = id;

            context.Update(mapeo);
            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entidades = await context.Animales.AnyAsync(x => x.Id == id);

            if (!entidades)
            {
                return NotFound();
            }

            context.Remove(new Animales { Id = id });

            await context.SaveChangesAsync();

            return NoContent();

        }
    }
}
