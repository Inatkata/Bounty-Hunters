using Microsoft.AspNetCore.Mvc;

namespace Bounty_Hunters.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
