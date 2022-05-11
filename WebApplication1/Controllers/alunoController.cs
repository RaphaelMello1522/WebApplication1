using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class alunoController : Controller
    {

        private ProductService productService;

        public alunoController(ProductService _productService)
        {
            productService = _productService;
        }

        [Route("")]
        private IActionResult Index()
        {
            ViewBag.alunos = productService.FindAll();
            return View();
        }
    }
}
