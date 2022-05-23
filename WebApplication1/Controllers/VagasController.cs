using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Recrutamento;

namespace WebApplication1.Controllers
{
    [Route("vagas")]
    public class VagasController : Controller
    {
        private VagaService vagaService;

        public VagasController(VagaService _vagaService)
        {
            vagaService = _vagaService;
        }

        public IActionResult Index()
        {
            ViewBag.Vagas = vagaService.FindAll();
            return View();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("Add", new Vaga());
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Vaga vaga)
        {
            vagaService.Create(vaga);
            return RedirectToAction("index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            vagaService.Delete(id);
            return RedirectToAction("index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View("Edit", vagaService.Find(id));
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Vaga vaga)
        {
            vagaService.Update(vaga);
            return RedirectToAction("index");
        }
    }
}
