using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasinoPIA.DTOs;
using WebApiCasinoPIA.Entidades;

namespace WebApiCasinoPIA.Controladores
{
    [ApiController]
    [Route("rifas")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class RifasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RifasController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("leer")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Rifa>>> GetAll()
        {
            return await context.Rifas.ToListAsync();
        }

        [HttpGet("leer/{id:int}", Name = "obtenerRifa")]
        public async Task<ActionResult<RifaConParticipanteDTO>> GetById(int id)
        {
            // Include/ ThenInclude para incluir datos de las tablas relacionadas
            var rifa = await context.Rifas
                            .Include(rifaDB => rifaDB.ParticipanteRifa)
                            .ThenInclude(participanteRifaDB => participanteRifaDB.Participante)
                            .Include(premioDB => premioDB.Premio)
                            .FirstOrDefaultAsync(x => x.Id == id);

            if (rifa == null)
            {
                return NotFound("La rifa con el id establecido no fue encontrada");
            }

            rifa.ParticipanteRifa = rifa.ParticipanteRifa.OrderBy(x => x.Orden).ToList();

            return mapper.Map<RifaConParticipanteDTO>(rifa);
        }

        [HttpGet("ganador")]
        public async Task<ActionResult<RifaConParticipanteDTO>> GetWinnerById(int id)
        {
            // Include/ ThenInclude para incluir datos de las tablas relacionadas
            var rifa = await context.Rifas
                            .Include(rifaDB => rifaDB.ParticipanteRifa.Take(3))
                            .ThenInclude(participanteRifaDB => participanteRifaDB.Participante)
                            .Include(premioDB => premioDB.Premio)
                            .FirstOrDefaultAsync(x => x.Id == id);

            if (rifa == null)
            {
                return NotFound("La rifa con el id establecido no fue encontrada");
            }

            rifa.ParticipanteRifa = rifa.ParticipanteRifa.OrderBy(x => x.Orden).ToList();

            return mapper.Map<RifaConParticipanteDTO>(rifa);
        }


        [HttpPost("crear")]
        public async Task<ActionResult> Post(RifaCreacionDTO rifaCreacionDTO)
        {
            if (rifaCreacionDTO.ParticipantesIds == null)
            {
                return BadRequest("No se puede crear una rifa sin participantes");
            }

            var participantesIds = await context.Participantes
                .Where(participanteBD => rifaCreacionDTO.ParticipantesIds.Contains(participanteBD.Id)).
                Select(x => x.Id).ToListAsync();

            if (rifaCreacionDTO.ParticipantesIds.Count != participantesIds.Count)
            {
                return BadRequest("No existe uno de los participantes registrados");
            }

            var rifa = mapper.Map<Rifa>(rifaCreacionDTO);

            context.Add(rifa);
            await context.SaveChangesAsync();

            var rifaDTO = mapper.Map<RifaDTO>(rifa);

            return CreatedAtRoute("obtenerRifa", new { id = rifa.Id }, rifaDTO);
        }

        [HttpPut("actualizar/{id:int}")]
        public async Task<ActionResult> Put(RifaCreacionDTO rifaCreacionDTO, int id)
        {
            var rifaDB = await context.Rifas
                .Include(x => x.ParticipanteRifa)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (rifaDB == null)
            {
                return NotFound("La rifa con el id especificado no existe");
            }

            if (rifaDB.Id != id)
            {
                return BadRequest("El id de la rifa no coincide con el establecido en la url");
            }

            rifaDB = mapper.Map(rifaCreacionDTO, rifaDB);

            await context.SaveChangesAsync();
            return NoContent();
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

        [HttpPatch("patch/{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<RifaPatchDTO> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest("El documento no existe");
            }

            var rifaDB = await context.Rifas.FirstOrDefaultAsync(x => x.Id == id);
            if (rifaDB == null)
            {
                return NotFound("La rifa con el id especificado no existe");
            }

            var rifaDTO = mapper.Map<RifaPatchDTO>(rifaDB);
            patchDocument.ApplyTo(rifaDTO);
            var isValid = TryValidateModel(rifaDTO);
            if (!isValid)
            {
                return BadRequest(ModelState);
            }

            mapper.Map(rifaDTO, rifaDB);

            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}