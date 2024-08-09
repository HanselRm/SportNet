using Microsoft.AspNetCore.Mvc;
using SportNet.Core.Application.Interfaces;
using SportNet.Core.Application.Interfaces.Services;
using SportNet.Core.Application.ViewModels.Event;
using SportNet.MiddledWares;
using SportNet.Models;
using System.Diagnostics;

namespace SportNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventServices _eventServices;
        private readonly ValidateUser _validateUser;

        public HomeController(IEventServices eventServices, ValidateUser validateUser)
        {
            _eventServices = eventServices;
            _validateUser = validateUser;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUser.hasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            ViewBag.Post = await _eventServices.GetAllViewModels();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(SaveEventViewModel model)
        {
            if (!_validateUser.hasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            ViewBag.Post = await _eventServices.GetAllViewModels();
            if (!ModelState.IsValid)
            {

                return View("Index", model);
            }
            
            DateTime date = DateTime.Now;
           
            await _eventServices.Add(model);

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> DeletePost(int Id)
        {
            if (!_validateUser.hasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            await _eventServices.Delete(Id);

            return RedirectToRoute(new { controller = "Home", action = "Index" });

        }

        public async Task<IActionResult> EditPost(SaveEventViewModel model)
        {
            if (!_validateUser.hasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }
            ViewBag.Post = await _eventServices.GetAllViewModels();
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }


            SaveEventViewModel model2 = await _eventServices.GetByIdSaveViewModel((int)model.Id);

            await _eventServices.Update(model, (int)model.Id);

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}