using AppRefugio.DTOs;
using AppRefugio.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AppRefugio.Controllers
{
    [ApiController]
    [Route("api/adoptantes")]
    public class AdoptanteController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AdoptanteController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdoptanteDTO>>> Get()
        {
            var adoptante = await context.Adoptantes.ToListAsync();
            var dtos = mapper.Map<List<AdoptanteDTO>>(adoptante);

            return dtos;

        }


        //test devops

        [HttpGet("{id}", Name = "obtenerAdoptante")]
        public async Task<ActionResult<AdoptanteDTO>> Get(int id)
        {
            //var adoptantes = await context.Adoptantes.Include(x => x.Animales).FirstOrDefaultAsync(x => x.Id == id);
            var adoptantes = await context.Adoptantes.FirstOrDefaultAsync(x => x.Id == id);
            //if (adoptantes == null)
            //{
            //    return NotFound("no encontrado");
            //}

            var dtos = mapper.Map<AdoptanteDTO>(adoptantes);

            return dtos;
        }

        [HttpPost]
        public async Task<ActionResult> Post(/*int animalesId, */[FromForm] AdoptanteCreacionDTO adoptanteCreacionDTO)
        {
 
            //var existe = await context.Animales.FirstOrDefaultAsync(x => x.Id == animalesId);

            //if (existe == null)
            //{
            //    return NotFound();
            //}

            var adoptante = mapper.Map<Adoptante>(adoptanteCreacionDTO);
            //adoptante.AnimalesId = animalesId;

            if (adoptante == null)
            {
                return BadRequest();
            }

            

            //if (existe.Adoptado == true)
            //{
            //    return BadRequest("el animal ya está adoptado");
            //}

            context.Add(adoptante);
            //existe.Adoptado = true;
            await context.SaveChangesAsync();

            var mapeo = mapper.Map<AdoptanteDTO>(adoptante);

            return CreatedAtRoute("obtenerAdoptante", new { id = adoptante.Id }, mapeo);
        }
    }
}
