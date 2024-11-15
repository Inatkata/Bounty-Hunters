using Bounty_Hunters.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bounty_Hunters.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Return the homepage, showing top criminals and hunters
            return View();
        }

        public IActionResult About()
        {
            // Returns an "About" page describing the application
            return View();
        }

        public IActionResult Contact()
        {
            // Returns a "Contact Us" page
            return View();
        }
    }

}
