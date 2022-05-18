using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.Services.Pc;
using WebApplication1.Services.User;

namespace WebApplication1.Controllers
{
    [Route("usuarios")]
    public class UsuarioController : Controller
    {
        private UsuarioService usuarioService;
        private DatabaseContext _db;

        public UsuarioController(UsuarioService _usuarioService , DatabaseContext db)
        {
            usuarioService = _usuarioService;
            db = _db;
        }

        public IActionResult Index()
        {
            ViewBag.Usuarios = usuarioService.FindAll();
            return View();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("Add", new Usuario());
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Usuario usuario)
        {
            usuarioService.Create(usuario);
            return RedirectToAction("index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            usuarioService.Delete(id);
            return RedirectToAction("index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View("Edit", usuarioService.Find(id));
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Usuario usuario)
        {
            usuarioService.Update(usuario);
            return RedirectToAction("index");
        }
    }
}
