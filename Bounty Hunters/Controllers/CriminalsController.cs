using Microsoft.AspNetCore.Mvc;

namespace Bounty_Hunters.Controllers
{
    public class CriminalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CriminalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Display a list of all criminals
            var criminals = _context.Criminals.ToList();
            return View(criminals);
        }

        public IActionResult Details(int id)
        {
            // Display details of a specific criminal
            var criminal = _context.Criminals.FirstOrDefault(c => c.Id == id);
            if (criminal == null) return NotFound();
            return View(criminal);
        }

        [HttpPost]
        public IActionResult Capture(int id)
        {
            // Mark a criminal as "Captured"
            var criminal = _context.Criminals.FirstOrDefault(c => c.Id == id);
            if (criminal == null) return NotFound();

            criminal.Status = "Captured";
            criminal.CaptureDate = DateTime.Now;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
