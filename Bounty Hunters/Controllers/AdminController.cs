using Microsoft.AspNetCore.Mvc;

namespace Bounty_Hunters.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
