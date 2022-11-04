using Microsoft.AspNetCore.Mvc;

namespace MyScene.WebMVC.Controllers
{
    public class BandController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
