using BountyHunters.Web.ViewModels.Achievement;
using BountyHunters.Data;
using BountyHunters.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BountyHunters.Web.Controllers
{
    public class AchievementController : Controller
    {
        private readonly BountyHuntersDbContext dbContext;

        public AchievementController(BountyHuntersDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<AchievementViewModel> achievements = await dbContext.Achievements
                .Include(a => a.BountyHunter)
                .Select(a => new AchievementViewModel
                {
                    Id = a.Id.ToString(),
                    Name = a.Name,
                    Description = a.Description,
                    DateAchieved = a.DateAchieved,
                    BountyHunterId = a.BountyHunterId.ToString(),
                    BountyHunterName = a.BountyHunter.Name
                })
                .OrderBy(a => a.Name)
                .ToArrayAsync();

            return View(achievements);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.BountyHunters = await dbContext.BountyHunters
                .Select(h => new SelectListItem
                {
                    Value = h.Id.ToString(),
                    Text = h.Name
                })
                .ToListAsync();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(AddAchievementInputModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BountyHunters = new SelectList(await dbContext.BountyHunters.ToListAsync(), "Id", "Name");
                return View();
            }

            Achievement achievement = new Achievement()
            {
                Name = model.Name,
                Description = model.Description,
                DateAchieved = model.DateAchieved,
                BountyHunterId = model.BountyHunterId
            };

            await dbContext.Achievements.AddAsync(achievement);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (!Guid.TryParse(id, out Guid guidId))
            {
                return RedirectToAction(nameof(Index));
            }

            var achievement = await dbContext.Achievements
                .Include(a => a.BountyHunter)
                .FirstOrDefaultAsync(a => a.Id == guidId);

            if (achievement == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new AchievementViewModel
            {
                Id = achievement.Id.ToString(),
                Name = achievement.Name,
                Description = achievement.Description,
                DateAchieved = achievement.DateAchieved,
                BountyHunterId = achievement.BountyHunterId.ToString(),
                BountyHunterName = achievement.BountyHunter.Name
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (!Guid.TryParse(id, out Guid guidId))
            {
                return RedirectToAction(nameof(Index));
            }

            var achievement = await dbContext.Achievements
                .Include(a => a.BountyHunter)
                .FirstOrDefaultAsync(a => a.Id == guidId);

            if (achievement == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new AddAchievementInputModel
            {
                Name = achievement.Name,
                Description = achievement.Description,
                DateAchieved = achievement.DateAchieved,
                BountyHunterId = achievement.BountyHunterId
            };

            ViewBag.BountyHunters = new SelectList(await dbContext.BountyHunters.ToListAsync(), "Id", "Name", achievement.BountyHunterId);

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, AddAchievementInputModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BountyHunters = new SelectList(await dbContext.BountyHunters.ToListAsync(), "Id", "Name", model.BountyHunterId);
                return View(model);
            }

            var achievement = await dbContext.Achievements.FirstOrDefaultAsync(a => a.Id == id);

            if (achievement == null)
            {
                return RedirectToAction(nameof(Index));
            }

            achievement.Name = model.Name;
            achievement.Description = model.Description;
            achievement.DateAchieved = model.DateAchieved;
            achievement.BountyHunterId = model.BountyHunterId;

            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid guidId))
            {
                return RedirectToAction(nameof(Index));
            }

            Achievement? achievement = await this.dbContext
                .Achievements
                .Include(a => a.BountyHunter)
                .FirstOrDefaultAsync(a => a.Id == guidId);

            if (achievement == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var viewModel = new AchievementViewModel
            {
                Id = achievement.Id.ToString(),
                Name = achievement.Name,
                Description = achievement.Description,
                BountyHunterName = achievement.BountyHunter.Name
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var achievement = await dbContext.Achievements.FirstOrDefaultAsync(a => a.Id == id);

            if (achievement == null)
            {
                return RedirectToAction(nameof(Index));
            }

            dbContext.Achievements.Remove(achievement);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
