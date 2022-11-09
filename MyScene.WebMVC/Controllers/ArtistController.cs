using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyScene.Models;
using MyScene.Services;

namespace MyScene.WebMVC.Controllers
{
    [Authorize]
    public class ArtistController : Controller
    {
        public IActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService(userId);
            var model = service.GetArtist();

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
                return View(model);
            }
            var service = CreateArtistService();

            if (service.CreateArtist(model))
            {
                TempData["SaveResult"] = "Artist created successfully";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Artist could not be created");
            
            return View(model);
        }

        private ArtistService CreateArtistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService(userId);
            return service;
        }
    }
}
