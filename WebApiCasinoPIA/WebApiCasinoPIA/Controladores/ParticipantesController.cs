using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasinoPIA.Entidades;

namespace WebApiCasinoPIA.Controladores
{
    [ApiController]
    [Route("participantes")]
    public class ParticipantesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ParticipantesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("leer")]
        public async Task<ActionResult<List<Participante>>> Get()
        {
            return await context.Participantes.ToListAsync();
        }

        [HttpPost("crear")]
        public async Task<ActionResult> Post(Participante participante)
        {
            var exist = await context.Participantes.AnyAsync(x => x.Nombre == participante.Nombre);
            
            // Validación desde el controlador
            if (exist)
            {
                return BadRequest("Ya existe un participante con el mismo nombre, favor de introducir otro nombre válido")
            }

            context.Add(participante);
            await context.SaveChangesAsync();
            
            return Ok("El participante con fue creado correctamente");
        }

        [HttpPut("actualizar/{id:int}")]
        public async Task<ActionResult> Put(Participante participante, int id)
        {
            if (participante.Id != id)
            {
                return BadRequest("El id del participante no coincide con el establecido en la url");
            }

            context.Update(participante);
            await context.SaveChangesAsync();

            return Ok("El participante fue modificado correctamente");
        }

        [HttpDelete("borrar/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Participantes.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("El participante con el id establecido no fue encontrado");
            }

            context.Remove(new Participante()
            {
                Id = id
            });

            await context.SaveChangesAsync();

            return Ok("El participante fue eliminado correctamente");
        }
    }
}
