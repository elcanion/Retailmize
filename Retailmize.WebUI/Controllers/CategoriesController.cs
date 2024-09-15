using Microsoft.AspNetCore.Mvc;
using Retailmize.Application.Interfaces;
using Retailmize.Application.Services;
using System.Threading.Tasks;

namespace Retailmize.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAll();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
