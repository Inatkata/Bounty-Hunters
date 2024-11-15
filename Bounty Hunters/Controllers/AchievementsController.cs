using Microsoft.AspNetCore.Mvc;

namespace Bounty_Hunters.Controllers
{
    public class AchievementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AchievementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int hunterId)
        {
            // Display achievements for a specific hunter
            var achievements = _context.Achievements
                .Where(a => a.HunterId == hunterId)
                .ToList();

            return View(achievements);
        }

        public IActionResult Leaderboard()
        {
            // Display top-ranking hunters based on captures
            var leaderboard = _context.BountyHunters
                .OrderByDescending(h => h.CaptureCount)
                .Take(10)
                .ToList();

            return View(leaderboard);
        }
    }

}
