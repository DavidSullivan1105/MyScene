using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyScene.Contracts;
using MyScene.Models;
using MyScene.Services;
using System.Security.Claims;

namespace MyScene.WebMVC.Controllers
{
    [Authorize]
    public class MySceneController : Controller
    {
        private readonly IMySceneService _mySceneService;

        public MySceneController(IMySceneService mySceneService)
        {
            _mySceneService = mySceneService;
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
        public IActionResult Create(MySceneCreate model)
        {
            if (!SetUserIdInService()) return Unauthorized();
           
            if (ModelState.IsValid)
            {

            return View(model);
            }
            else
            {
                if (_mySceneService.CreateMyScene(model))
                {
                    TempData["SaveResult"] = "MyScene was created successfully";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "MyScene could not be created");
            }
            return View(model);
        }

        public IActionResult Details(Guid userId)
        {
            if (!SetUserIdInService()) return Unauthorized();
            var model = _mySceneService.GetMySceneById(userId);

            return View(model);

        }

        public IActionResult Edit(Guid id)
        {
            var detail = _mySceneService.GetMySceneById(id);
            var model =
                new MySceneEdit
                {
                    UserId = detail.UserId,
                    Artists = detail.Artists,
                    Bands = detail.Bands,
                    Venues = detail.Venues,
                };
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

            _mySceneService.SetUserId(Guid.Parse(userId));
            return true;
        }
    }
}
