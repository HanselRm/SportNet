using Microsoft.AspNetCore.Mvc;

namespace SportNet.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
