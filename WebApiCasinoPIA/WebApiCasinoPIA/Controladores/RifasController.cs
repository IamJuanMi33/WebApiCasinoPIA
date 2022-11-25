using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasinoPIA.Entidades;

namespace WebApiCasinoPIA.Controladores
{
    [ApiController]
    [Route("rifas")]
    public class RifasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public RifasController(ApplicationDbContext context)
        {
            this.context = context;
        }   

        [HttpGet("leer")]
        public async Task<ActionResult<List<Rifa>>> GetAll()
        {
            return await context.Rifas.ToListAsync();
        }

        [HttpGet("leer/{id:int}")]
        public async Task<ActionResult<Rifa>> GetById(int id)
        {
            return await context.Rifas.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost("crear")]
        public async Task<ActionResult> Post(Rifa rifa)
        {
            var exist = await context.Rifas.AnyAsync(x => x.Nombre == rifa.Nombre);
            if (exist)
            {
                return BadRequest("ya existe una rifa con el mismo nombre, favor de introducir otro nombre válido");
            }

            context.Add(rifa);
            await context.SaveChangesAsync();

            return Ok("la rifa fue creada correctamente");
        }

        [HttpPut("actualizar/{id:int}")]
        public async Task<ActionResult> Put(Rifa rifa, int id)
        {
            var exist = await context.Rifas.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("La rifa con el id especificado no existe");
            }

            if (rifa.Id != id)
            {
                return BadRequest("El id de la rifa no coincide con el establecido en la url");
            }

            context.Update(rifa);
            await context.SaveChangesAsync();

            return Ok("La rifa fue modificada correctamente");
        }

        [HttpDelete("borrar/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Rifas.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("La rifa con el id especificado no existe");
            }

            context.Remove(new Rifa 
            { 
                Id = id 
            });

            await context.SaveChangesAsync();

            return Ok("La rifa fue eliminada correctamente");
        }
    }
}