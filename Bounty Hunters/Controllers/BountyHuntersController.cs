using Microsoft.AspNetCore.Mvc;

namespace Bounty_Hunters.Controllers
{
    public class BountyHuntersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BountyHuntersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // List all bounty hunters
            var hunters = _context.BountyHunters.ToList();
            return View(hunters);
        }

        public IActionResult Details(int id)
        {
            // Display a specific hunter's profile
            var hunter = _context.BountyHunters.FirstOrDefault(h => h.Id == id);
            if (hunter == null) return NotFound();
            return View(hunter);
        }

        [HttpPost]
        public IActionResult UpdateProfile(BountyHunter hunter)
        {
            // Update the hunter's profile
            var existingHunter = _context.BountyHunters.FirstOrDefault(h => h.Id == hunter.Id);
            if (existingHunter == null) return NotFound();

            existingHunter.Name = hunter.Name;
            existingHunter.Bio = hunter.Bio;
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = hunter.Id });
        }
    }

}
