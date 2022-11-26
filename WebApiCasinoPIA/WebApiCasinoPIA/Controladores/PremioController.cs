using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasinoPIA.Entidades;

namespace WebApiCasinoPIA.Controladores
{
    [ApiController]
    [Route("rifa/{rifaId:int}/premios")]
    public class PremioController:ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PremioController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("/listado")]
        public async Task<ActionResult<List<Premio>>> GetAll()
        {
            return await context.Premios.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Premio>> GetById(int id)
        {
            return await context.Premios.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<Premio>> Get(string nombre)
        {
            var premio = await context.Premios.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));

            if(premio == null)
            {
                return NotFound();
            }

            return premio;
        }

       [HttpPost]
       public async Task<ActionResult> Post(Premio premio)
        {
            var existeRifa = await context.Rifas.AnyAsync(x => x.Id == premio.RifaId);
           
            if (!existeRifa)
            {
                return BadRequest($"No existe rifa con el id: {premio.RifaId}");

            }

            context.Add(premio);

            await context.SaveChangesAsync();
            return Ok();

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Premio premio, int id)
        {
            var existe = await context.Premios.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound();
            }

            if(premio.Id != id)
            {
                return BadRequest("El id no corresponde con el establecido");
            }

            context.Update(premio);
            await context.SaveChangesAsync();
            return Ok();
            
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Premios.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound("El recurso no fue encuentro");
            }

            context.Remove(new Premio { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
