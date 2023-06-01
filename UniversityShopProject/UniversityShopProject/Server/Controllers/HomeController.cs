using Microsoft.AspNetCore.Mvc;

namespace UniversityShopProject.Server.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
