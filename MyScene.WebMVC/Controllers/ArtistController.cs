using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyScene.Models;

namespace MyScene.WebMVC.Controllers
{
    [Authorize]
    public class ArtistController : Controller
    {
        public IActionResult Index()
        {
            var model = new ArtistListItem[0];
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArtistCreate model)
        {
            if (!ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}
