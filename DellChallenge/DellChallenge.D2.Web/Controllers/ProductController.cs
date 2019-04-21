using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DellChallenge.D2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(NewProductModel newProduct)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            _productService.Add(newProduct);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var model = _productService.Delete(id);

            //if (model == null)
            //{
            //    return NotFound();
            //}

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(string id)
        {
            var model = _productService.Get(id);

            if(model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ProductModel updateProduct)
        {

            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            _productService.Update(updateProduct);

            return RedirectToAction("Index");
        }
    }
}