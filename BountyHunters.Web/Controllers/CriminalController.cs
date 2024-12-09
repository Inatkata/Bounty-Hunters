using BountyHunters.Data;
using BountyHunters.Data.Models;
using BountyHunters.Web.ViewModels.Criminal;
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
        public async Task<IActionResult> Index()
        {
            IEnumerable<CriminalInputModel> criminals = await this.dbContext
                .Criminals
                .Select(c => new CriminalInputModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Bounty = c.Bounty,
                    CrimeType = c.CrimeType,
                    Status = c.Status

                })
                .OrderBy(c => c.Name)
                .ToArrayAsync();

            return View(criminals );
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return this.View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(AddCriminalInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            Criminal criminal = new Criminal
            {
                Name = model.Name,
                CrimeType = model.CrimeType,
                Bounty = model.Bounty,
                Status = model.Status,
                CaptureDate = model.CaptureDate
            };

            await this.dbContext.Criminals.AddAsync(criminal);
            await this.dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);
            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Criminal? criminal = await this.dbContext
                .Criminals
                .FirstOrDefaultAsync(c => c.Id == guidId);

            if (criminal == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(criminal);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Criminal model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            Criminal? criminal = await this.dbContext.Criminals.FirstOrDefaultAsync(c => c.Id == model.Id);

            if (criminal == null)
            {
                return RedirectToAction(nameof(Index));
            }

            criminal.Name = model.Name;
            criminal.CrimeType = model.CrimeType;
            criminal.Bounty = model.Bounty;
            criminal.Status = model.Status;
            criminal.CaptureDate = model.CaptureDate;

            await this.dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);
            if (!isIdValid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Criminal? criminal = await this.dbContext
                .Criminals
                .Include(c => c.Captures)
                .FirstOrDefaultAsync(c => c.Id == guidId);
            if (criminal == null)
            {
                return this.RedirectToAction(nameof(Index));
            }
            return View(criminal);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            bool isIdValid = Guid.TryParse(id, out Guid guidId);
            if (!isIdValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Criminal? criminal = await this.dbContext
                .Criminals
                .FirstOrDefaultAsync(c => c.Id == guidId);

            if (criminal == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(criminal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Criminal? criminal = await this.dbContext.Criminals.FirstOrDefaultAsync(c => c.Id == id);

            if (criminal == null)
            {
                return RedirectToAction(nameof(Index));
            }

            this.dbContext.Criminals.Remove(criminal);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
