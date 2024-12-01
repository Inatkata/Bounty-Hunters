using BountyHunters.Data;
using BountyHunters.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BountyHunters.Web.Controllers
{
    public class CriminalController : Controller
    {
        private readonly BountyHuntersDbContext dbContext;

        public CriminalController(BountyHuntersDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Criminal> allCriminals = this.dbContext
                .Criminals
                .ToList();

            return View(allCriminals);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return this.View();
        }
        [HttpPost]
       
        public async Task<IActionResult> Create([Bind("Name,CrimeType,Bounty,Status,CaptureDate")] Criminal criminal)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(criminal);
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(criminal);
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Criminal? criminal = this.dbContext
                .Criminals
                .FirstOrDefault(c => c.Id == guidId);
            if (criminal == null)
            {
                return this.RedirectToAction(nameof(Index));
            }
            return View(criminal);
        }
    }
}
