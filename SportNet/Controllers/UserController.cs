using Microsoft.AspNetCore.Mvc;
using SportNet.Core.Application.Interfaces.Services;
using SportNet.Core.Application.ViewModels.Users;
using SportNet.MiddledWares;
using SportNet.Core.Application.Helpers;


namespace SportNet.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly ValidateUser _validateUser;
        public UserController(IUserServices userServices, ValidateUser validateUser)
        {
            _userServices = userServices;
            _validateUser = validateUser;
        }

        public IActionResult Index()
        {
            if (_validateUser.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (_validateUser.hasUser())
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            SaveUserViewModel userVm = await _userServices.Login(model);

            if (userVm != null)
            {
                if (userVm.Status == false)
                {
                    ModelState.AddModelError("UserValidation", "Debe activar su usuario desde el correo de activación");
                }
                else
                {
                    HttpContext.Session.Set<SaveUserViewModel>("User", userVm);
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }

            }
            else
            {
                ModelState.AddModelError("UserValidation", "Datos incorrectos");
            }

            return View();
        }
    }
}
