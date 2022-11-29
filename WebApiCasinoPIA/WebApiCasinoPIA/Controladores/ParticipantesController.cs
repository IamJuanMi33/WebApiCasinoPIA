using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasinoPIA.DTOs;
using WebApiCasinoPIA.Entidades;

namespace WebApiCasinoPIA.Controladores
{
    [ApiController]
    [Route("participantes")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]
    public class ParticipantesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<ParticipantesController> logger;
        private readonly IMapper mapper;

        public ParticipantesController(ApplicationDbContext context, ILogger<ParticipantesController> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        //Obtener listado 
        [HttpGet("leer")]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetParticipanteDTO>>> Get()
        {
            // Logger
            logger.LogWarning("Se obtiene el listado de participantes");
            var participantes = await context.Participantes.ToListAsync();

            return mapper.Map<List<GetParticipanteDTO>>(participantes);
        }

        [HttpPost("crear")]
        public async Task<ActionResult> Post(Participante participante)
        {
            var exist = await context.Participantes.AnyAsync(x => x.Nombre == participante.Nombre);

            // Validación desde el controlador
            if (exist)
            {
                return BadRequest("Ya existe un participante con el mismo nombre, favor de introducir otro nombre válido");
            }

            context.Add(participante);
            await context.SaveChangesAsync();

            return Ok("El participante con fue creado correctamente");
        }

        [HttpPut("actualizar/{id:int}")]
        public async Task<ActionResult> Put(ParticipanteDTO participanteCreacionDTO, int id)
        {
            var existeParticipante = await context.Participantes.AnyAsync(x => x.Id == id);
            if (!existeParticipante)
            {
                return BadRequest("El id del participante no coincide con el establecido en la url");
            }

            var participante = mapper.Map<Participante>(participanteCreacionDTO);
            participante.Id = id;

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
