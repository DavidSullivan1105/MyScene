using Microsoft.AspNetCore.Mvc;
using MyScene.Contracts;
using MyScene.Models;
using System.Security.Claims;

namespace MyScene.WebMVC.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenueService _venueService;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VenueCreate model)
        {
            if (!SetUserIdInService()) return Unauthorized();

            if(!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                if(_venueService.CreateVenue(model))
                    return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Details(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var model = _venueService.GetVenueById(id);

            return View(model);

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
            if (userId == null) return false;

            _venueService.SetUserId(Guid.Parse(userId));
            return true;
        }
    }
}
