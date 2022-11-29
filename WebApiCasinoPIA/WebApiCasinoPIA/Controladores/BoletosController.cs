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
    [Route("boletos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "EsAdmin")]

    public class BoletosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<BoletosController> logger;
        private readonly IMapper mapper;

        public BoletosController(ApplicationDbContext context, ILogger<BoletosController> logger, IMapper mapper)
        {
            this.context = context;
            this.logger = logger;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("leer", Name = "obtenerBoleto")]
        public async Task<ActionResult<List<BoletoDTO>>> Get([FromHeader] int rifaId, string rifaNombre)
        {
            var boletos = await context.Boletos.Where(boletosDB => boletosDB.RifaId == rifaId).ToListAsync();
            
            return mapper.Map<List<BoletoDTO>>(boletos);
        }

        [HttpPost("asignar")]
        [AllowAnonymous]
        public async Task<ActionResult> Post(int rifaId, BoletoCreacionDTO boletoCreacionDTO)
        {
            var existeRifa = await context.Rifas.AnyAsync(rifaDB => rifaDB.Id == rifaId);

            if (!existeRifa)
            {
                return NotFound();
            }

            var boleto = mapper.Map<Boleto>(boletoCreacionDTO);
            boleto.RifaId = rifaId;
            context.Add(boleto);
            await context.SaveChangesAsync();

            var boletoDTO = mapper.Map<BoletoDTO>(boleto);

            return CreatedAtRoute("obtenerBoleto", new { id = boleto.Id }, boletoDTO);

        }
    }
}
