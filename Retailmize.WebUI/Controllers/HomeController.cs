using Microsoft.AspNetCore.Mvc;

namespace Retailmize.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
