using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyScenes.Models;
using MyScenes.Services;
using System.Security.Claims;

namespace MyScenes.WebMVC.Controllers
{
    [Authorize]
    public class ArtistController : Controller
    {
        private readonly IArtistService _artistService;
        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        public IActionResult Index()
        {
            if (!SetUserIdInService()) return Unauthorized();
            var artists = _artistService.GetArtist();

            return View(artists);
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
            if (!SetUserIdInService()) return Unauthorized();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
           else
            {
                if (_artistService.CreateArtist(model))
                    return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Details(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var model = _artistService.GetArtistById(id);
            return View(model);
            
        }

        public IActionResult Edit(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var detail = _artistService.GetArtistById(id);
            var model =
                new ArtistEdit
                {
                    ArtistId = detail.ArtistId,
                    ArtistName = detail.ArtistName,
                    ArtistEmail = detail.ArtistEmail,
                };
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ArtistEdit model)
        {
            if (!SetUserIdInService()) return Unauthorized();

            if(ModelState.IsValid) return View(model);

            if(model.ArtistId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            
            if (_artistService.UpdateArtist(model))
            {
                TempData["SaveResult"] = "Artist was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Artist could not be updated.");
            return View(model);

        }

        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();
            var model = _artistService.GetArtistById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteArtist(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            _artistService.GetArtistById(id);
            TempData["SaveResult"] = "Artist was deleted.";

            return RedirectToAction("Index");
        }

        private string GetUserId()
        {
            string userIdClaim = User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value;
            if (userIdClaim == null) return null;
            return userIdClaim;
        }

        private bool SetUserIdInService()
        {
            var userId = GetUserId();
            if(userId == null) return false;

            _artistService.SetUserId(Guid.Parse(userId));
            return true;
        }
    }
}
