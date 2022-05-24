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
        private DatabaseContext databaseContext;
        private UsuarioService usuarioService;


        public ComputadoresController(ComputerService _computerService, DatabaseContext _db, UsuarioService _usuarioService)
        {
            computerService = _computerService;
            databaseContext = _db;
            usuarioService = _usuarioService;
            ViewBag.Usuario = usuarioService.FindAll();
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
            ViewBag.Usuario = usuarioService.FindAll();
            ViewBag.Username = new SelectList(databaseContext.Usuarios, "NomeUsuario", "NomeUsuario");
            ViewBag.UsernameSetor = new SelectList(databaseContext.Usuarios, "SetorUsuario", "SetorUsuario");

            return View("Add", new Computadores());
        }



        [HttpPost]
        [Route("add")]
        public IActionResult Add(Computadores computadores, string UsuarioId)
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
