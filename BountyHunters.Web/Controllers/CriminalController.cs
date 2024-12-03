﻿using BountyHunters.Data;
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
            IEnumerable<AddCriminalInputModel> criminals = await this.dbContext
                .Criminals
                .Select(c => new AddCriminalInputModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Bounty = c.Bounty,
                    CrimeType = c.CrimeType,
                    Status = c.Status

                })
                .ToArrayAsync();

            return View(criminals);
        }
        [HttpGet]
        async Task<IActionResult> Create()
        {

            return this.View();
        }
        [HttpPost]

        public async Task<IActionResult> Create(AddCriminalInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Criminal criminal = new Criminal()
            {
                Name = model.Name,
                CrimeType = model.CrimeType,
                Bounty = model.Bounty,
                Status = model.Status,
                CaptureDate = model.CaptureDate

            };
            await this.dbContext.Criminals.AddAsync(criminal);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

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
                .Include(c => c.Captures)
                .FirstOrDefault(c => c.Id == guidId);
            if (criminal == null)
            {
                return this.RedirectToAction(nameof(Index));
            }
            return View(criminal);
        }
    }
}
