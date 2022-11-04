using Microsoft.AspNetCore.Mvc;

namespace MyScene.WebMVC.Controllers
{
    public class MySceneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
