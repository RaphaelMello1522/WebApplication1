using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {

        private ProductService productService;

        public ProductController(ProductService _productService)
        {
            productService = _productService;
        }

        public IActionResult Index()
        {
            ViewBag.Products = productService.FindAll();
            return View();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("Add", new Product());
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Product product)
        {
            productService.Create(product);
            return RedirectToAction("index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            productService.Delete(id);
            return RedirectToAction("index");
        }
        [HttpGet]
        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View("Edit", productService.Find(id));
        }

        [HttpPost]
        [Route("edit/{id}")]
        public IActionResult Edit(int id, Product product)
        {
            productService.Update(product);
            return RedirectToAction("index");
        }
    }
}
