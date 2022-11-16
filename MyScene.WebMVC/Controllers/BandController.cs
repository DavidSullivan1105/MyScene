using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyScene.Contracts;
using MyScene.Models;
using System.Security.Claims;

namespace MyScene.WebMVC.Controllers
{
    [Authorize]
    public class BandController : Controller
    {
        private readonly IBandService _bandService;
        public BandController(IBandService bandService)
        {
            _bandService = bandService;
        }

        public IActionResult Index()
        {
            if (!SetUserIdInService()) return Unauthorized();
            var bands = _bandService.GetBands();

            return View(bands);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BandCreate model)
        {
            if (!SetUserIdInService()) return Unauthorized();

            if(ModelState.IsValid)
            {
            return View(model);

            }
            if(_bandService.CreateBand(model))
            {
                TempData["SaveResult"] = "Band was created successfully.";
            return RedirectToAction(nameof(Index));

            }
            return View(model);


        }
        public IActionResult Details(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var model = _bandService.GetBandById(id);

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var detail = _bandService.GetBandById(id);
            var model =
                new BandEdit
                {
                    BandId = detail.BandId,
                    BandName = detail.BandName,
                    BandGenre = detail.Genre

                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BandEdit model)
        {
            if (!SetUserIdInService()) return Unauthorized();

            if(!ModelState.IsValid) return  View(model);
            if(model.BandId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            if(_bandService.UpdateBand(model))
            {
                TempData["SaveResult"] = "Band was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Band could not be updated");
            return View(model);

        }

        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            var model = _bandService.GetBandById(id);
            return View(model);

        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (!SetUserIdInService()) return Unauthorized();

            _bandService.DeleteBand(id);

            TempData["SaveResult"] = "Band was deleted";
            return RedirectToAction("Index");
        }
        public





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

            _bandService.SetUserId(Guid.Parse(userId));
            return true;
        }
    }
}
