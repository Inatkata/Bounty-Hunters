using BountyHunters.Web.ViewModels.Achievement;
using Microsoft.AspNetCore.Mvc;
using global::BountyHunters.Data.Models;
using global::BountyHunters.Data;
using Microsoft.EntityFrameworkCore;

namespace BountyHunters.Web.Controllers
{
    namespace BountyHunters.Web.Controllers
    {
        public class AchievementsController : Controller
        {
            private readonly BountyHuntersDbContext dbContext;

            public AchievementController(BountyHuntersDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            [HttpGet]
            public async Task<IActionResult> Index()
            {
                AchievementViewModel[] achievements = await this.dbContext.Achievements
                    .Include(a => a.BountyHunterName)
                    .Select(a => new AchievementViewModel
                    {
                        Id = a.Id.ToString(),
                        Name = a.Name,
                        Description = a.Description,
                        DateAchieved = a.DateAchieved,
                        BountyHunterId = a.BountyHunterId.ToString(),
                        BountyHunterName = a.BountyHunterName
                    })
                    .OrderBy(a => a.Name)
                    .ToArrayAsync();

                return View(achievements);
            }


            [HttpGet]
            public async Task<IActionResult> Create()
            {
                ViewBag.BountyHunters = await dbContext.BountyHunters
                    .Select(h => new { h.Id, h.Name })
                    .ToListAsync();

                return this.View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(AchievementViewModel model)
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.BountyHunters = await dbContext.BountyHunters
                        .Select(h => new { h.Id, h.Name })
                        .ToListAsync();
                    return View(model);
                }

                var achievement = new Achievement
                {
                    Name = model.Name,
                    Description = model.Description,
                    DateAchieved = model.DateAchieved,
                    BountyHunterId = Guid.Parse(model.BountyHunterId)
                };

                await dbContext.Achievements.AddAsync(achievement);
                await dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            [HttpGet]
            public async Task<IActionResult> Details(string id)
            {
                bool isIdValid = Guid.TryParse(id, out Guid guidId);
                if (!isIdValid)
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
            public async Task<IActionResult> Delete(string id)
            {
                bool isIdValid = Guid.TryParse(id, out Guid guidId);
                if (!isIdValid)
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

                return View(achievement);
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

}
