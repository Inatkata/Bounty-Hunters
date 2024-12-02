﻿using BountyHunters.Data;
using BountyHunters.Data.Models;
using BountyHunters.Web.ViewModels.BountyHunter;
using BountyHunters.Web.ViewModels.Criminal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BountyHunters.Web.Controllers
{
    public class BountyHunterController : Controller
    {
        private readonly BountyHuntersDbContext dbContext;

        public BountyHunterController(BountyHuntersDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: BountyHunter
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<BountyHunterInputModel> bountyHunters = this.dbContext
                .BountyHunters
                .Select(c => new BountyHunterInputModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Rank =c.Rank,
                    Bio = c.Bio,
                    CaptureCount = c.CaptureCount
                })
                .ToArray();

            return View(bountyHunters);
        }

        // GET: BountyHunter/Details/{id}
        [HttpGet]
        public IActionResult Details(string id)
        {
            if (!Guid.TryParse(id, out Guid guidId))
            {
                return RedirectToAction(nameof(Index));
            }

            var hunter = dbContext.BountyHunters
                .FirstOrDefault(h => h.Id == guidId);

            if (hunter == null)
            {
                return NotFound();
            }

            return View(hunter);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BountyHunter hunter)
        {
            if (!ModelState.IsValid)
            {
               return View(hunter); 
            }
           
            hunter.Id = Guid.NewGuid();
            hunter.CaptureCount = 0;
            dbContext.BountyHunters.Add(hunter);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult UpdateProfile(string id)
        {
            if (!Guid.TryParse(id, out Guid guidId))
            {
                return RedirectToAction(nameof(Index));
            }

            var hunter = dbContext.BountyHunters
                .FirstOrDefault(h => h.Id == guidId);

            if (hunter == null)
            {
                return NotFound();
            }

            return View(hunter);
        }

        // POST: BountyHunter/UpdateProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProfile(BountyHunter hunter)
        {
            if (!ModelState.IsValid)
            {
                return View(hunter);
            }

            var existingHunter = dbContext.BountyHunters
                .FirstOrDefault(h => h.Id == hunter.Id);

            if (existingHunter == null)
            {
                return NotFound();
            }

            existingHunter.Name = hunter.Name;
            existingHunter.Bio = hunter.Bio;
            dbContext.SaveChanges();

            return RedirectToAction(nameof(Details), new { id = hunter.Id });
        }

    }
}
