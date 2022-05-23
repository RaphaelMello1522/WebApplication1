using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Area_do_Candidato;

namespace WebApplication1.Controllers
{
    [Route("areadocandidato")]
    public class AreaDoCandidatoController : Controller
    {
        private CandidatoService candidatoService;

        public AreaDoCandidatoController(CandidatoService _candidatoService)
        {
            candidatoService = _candidatoService;
        }

        public IActionResult Index()
        {
            ViewBag.Candidatos = candidatoService.FindAll();
            return View();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("Add", new AreaDoCandidato());
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(AreaDoCandidato candidato)
        {
            candidatoService.Create(candidato);
            return RedirectToAction("index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            candidatoService.Delete(id);
            return RedirectToAction("index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View("Edit", candidatoService.Find(id));
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, AreaDoCandidato candidato)
        {
            candidatoService.Update(candidato);
            return RedirectToAction("index");
        }
    }
}
