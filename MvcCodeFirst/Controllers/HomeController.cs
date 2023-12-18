using Microsoft.AspNetCore.Mvc;

namespace MvcCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Anasayfa";
            return View();
        }
    }
}
