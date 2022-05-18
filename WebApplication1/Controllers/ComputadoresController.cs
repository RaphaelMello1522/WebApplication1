using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Services.Pc;
using WebApplication1.Services.User;

namespace WebApplication1.Controllers
{
    [Route("computadores")]
    public class ComputadoresController : Controller
    {

        private ComputerService computerService;

        public ComputadoresController(ComputerService _computerService)
        {
            computerService = _computerService;
        }

        public IActionResult Index()
        {

            ViewBag.Computadores = computerService.FindAll();
            return View();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("Add", new Computadores());
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Computadores computadores)
        {
            computerService.Create(computadores);
            return RedirectToAction("index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            computerService.Delete(id);
            return RedirectToAction("index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View("Edit", computerService.Find(id));
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Computadores computadores)
        {
            computerService.Update(computadores);
            return RedirectToAction("index");
        }
    }
}
