using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCasinoPIA.DTOs;
using WebApiCasinoPIA.Entidades;

namespace WebApiCasinoPIA.Controladores
{
    [ApiController]
    [Route("boletos")]
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
        [HttpGet("leer")]
        public async Task<ActionResult<List<GetBoletoDTO>>> Get([FromHeader] int rifaId, string rifaNombre)
        {
            var boletos = await context.Rifas.AnyAsync(x => x.Id == rifaId);

            return mapper.Map<List<GetBoletoDTO>>(boletos);
        }

        //// GET: BoletosController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: BoletosController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: BoletosController/Create
        //[HttpPost]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: BoletosController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: BoletosController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: BoletosController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: BoletosController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
