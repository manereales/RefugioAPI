using AppRefugio.DTOs;
using AppRefugio.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppRefugio.Controllers
{
    [ApiController]
    [Route("api/veterinarios")]
    public class VeterinarioController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public VeterinarioController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<VeterinarioDTO>>> Get()
        {
            var entidades = await context.Veterinarios.ToListAsync();

            return mapper.Map<List<VeterinarioDTO>>(entidades);
        }



        [HttpGet("{id}", Name = "obtenerVeterinario")]
        public async Task<ActionResult<VeterinariosDTOconAnimales>> Get(int id)
        {
            var entidades = await context.Veterinarios
                .Include(x => x.VeterinarioAnimales)
                .ThenInclude(x => x.Animales)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entidades is null)
            {
                return NotFound();
            }

            return mapper.Map<VeterinariosDTOconAnimales>(entidades);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromForm] VeterinarioCreacionDTO veterinarioCreacionDTO)
        {
            if (veterinarioCreacionDTO.AnimalesIds == null)
            {
                return BadRequest("no se puede agregar un veterinario");
            }

            var existe = await context.Animales.Where(x => veterinarioCreacionDTO.AnimalesIds.Contains(x.Id)).ToListAsync();

            if (veterinarioCreacionDTO.AnimalesIds.Count != existe.Count)
            {
                return BadRequest("no existe uno de los animales ingresados");
            }

            var veterinarios = mapper.Map<Veterinarios>(veterinarioCreacionDTO);

            context.Add(veterinarios);
            await context.SaveChangesAsync();

            var dtos = mapper.Map<VeterinarioDTO>(veterinarios);

            return CreatedAtRoute("obtenerVeterinario", new { id = veterinarios.Id }, dtos);

        }

        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, VeterinarioCreacionDTO veterinarioCreacionDTO)
        {
            var veterinario = await context.Veterinarios.FirstOrDefaultAsync(x => x.Id == id);

            if (veterinario == null)
            {
                return NotFound();
            }

            veterinario = mapper.Map(veterinarioCreacionDTO, veterinario);

            await context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Veterinarios.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Veterinarios() { Id = id });

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
