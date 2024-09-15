using Microsoft.AspNetCore.Mvc;
using Retailmize.Application.Interfaces;
using System.Threading.Tasks;

namespace Retailmize.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAll();
            return View(products);
        }
    }
}
