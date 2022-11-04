using Microsoft.AspNetCore.Mvc;

namespace MyScene.WebMVC.Controllers
{
    public class VenueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
