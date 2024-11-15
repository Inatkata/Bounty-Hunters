using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bounty_Hunters.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            // Show admin dashboard with summary data
            return View();
        }

        public IActionResult AddCriminal()
        {
            // Show form to add a new criminal
            return View();
        }

        [HttpPost]
        public IActionResult AddCriminal(Criminal criminal)
        {
            // Save the new criminal to the database
            _context.Criminals.Add(criminal);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        public IActionResult ManageHunters()
        {
            // Show a list of all bounty hunters for management
            var hunters = _context.BountyHunters.ToList();
            return View(hunters);
        }
    }

}
