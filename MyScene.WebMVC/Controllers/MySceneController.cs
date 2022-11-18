using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyScenes.Contracts;
using MyScenes.Models;
using MyScenes.Services;
using System.Security.Claims;

namespace MyScenes.WebMVC.Controllers
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
                    return RedirectToAction(nameof(Index));
            }
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
