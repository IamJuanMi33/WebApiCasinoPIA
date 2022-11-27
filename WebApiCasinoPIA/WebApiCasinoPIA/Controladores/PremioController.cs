using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasinoPIA.DTOs;
using WebApiCasinoPIA.Entidades;

namespace WebApiCasinoPIA.Controladores
{
    [ApiController]
    [Route("rifa/{rifaId:int}/premios")]
    public class PremioController:ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PremioController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/listado")]
        public async Task<ActionResult<List<PremioDTO>>> Get(int rifaId)
        {
            var existeRifa = await context.Rifas.AnyAsync(rifaDB => rifaDB.Id == rifaId);

            if (!existeRifa)
            {
                return NotFound();
            }

            var premios = await context.Premios.Where(premiosDB => premiosDB.RifaId == rifaId).ToListAsync();

            return mapper.Map<List<PremioDTO>>(premios);
        }

       

        [HttpGet("{id:int}", Name = "obtenerPremio")]
        public async Task<ActionResult<PremioDTO>> GetById(int id)
        {
            var premio = await context.Premios.FirstOrDefaultAsync(premioDB => premioDB.Id == id);

            if(premio == null)
            {
                return NotFound();
            }

            return mapper.Map<PremioDTO>(premio);
        }

       [HttpPost]
       public async Task<ActionResult> Post(int rifaId,PremioCreacionDTO premioCreacionDTO)
        {
            var existeRifa = await context.Rifas.AnyAsync(rifaDB => rifaDB.Id == rifaId);

            if (!existeRifa)
            {
                return NotFound();
            }

            var premio = mapper.Map<Premio>(premioCreacionDTO);
            premio.RifaId = rifaId;
            context.Add(premio);
            await context.SaveChangesAsync();   

            var premioDTO = mapper.Map<PremioDTO>(premio);

            return CreatedAtRoute("obtenerPremio", new { id = premio.Id, rifaId = rifaId }, premioDTO);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int rifaId, int id, PremioCreacionDTO premioCreacionDTO)
        {
            var existeRifa = await context.Rifas.AnyAsync(rifaDB => rifaDB.Id == rifaId);

            if (!existeRifa)
            {
                return NotFound();
            }

            var existePremio = await context.Premios.AnyAsync(premioDB => premioDB.Id == id);

            if (!existePremio)
            {
                return NotFound();
            }

            var premio = mapper.Map<Premio>(premioCreacionDTO);
            premio.Id = id;
            premio.RifaId = rifaId;

            context.Update(premio);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
