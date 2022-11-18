using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyScenes.Contracts;
using MyScenes.Models;
using System.Security.Claims;

namespace MyScenes.WebMVC.Controllers
{
    [Authorize]
    public class VenueController : Controller
    {
        private readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

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
                {
                    ViewBag.SaveResult = "Venue created successfully";
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Venue could not be created");
                    
            }
            return View(model);
        }

        public IActionResult Details(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var model = _venueService.GetVenueById(id);

            return View(model);

        }

        public IActionResult Edit(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var detail = _venueService.GetVenueById(id);
            var model =
                new VenueEdit
                {
                    VenueId = detail.VenueId,
                    VenueName = detail.VenueName,
                    VenueAddress = detail.VenueAddress,
                    VenuePhone = detail.VenuePhone,
                    Is21AndOver = detail.Is21AndOver,

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, VenueEdit model)
        {
            if (!SetUserIdInService()) return Unauthorized();

            if(!ModelState.IsValid) return View(model);

            if(model.VenueId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if(_venueService.UpdateVenue(model))
            {
                TempData["SaveResult"] = "Venue was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Venue could not be updated");
            return View(model);
        }
        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var model = _venueService.GetVenueById(id);

            return View(model);

        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteVenue(int id)
        {
            _venueService.DeleteVenue(id);
            TempData["SaveResult"] = "Venue was deleted";
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
            if (userId == null) return false;

            _venueService.SetUserId(Guid.Parse(userId));
            return true;
        }
    }
}
