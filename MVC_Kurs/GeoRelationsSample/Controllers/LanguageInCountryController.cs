using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoRelationsSample.Data;
using GeoRelationsSample.Models;

namespace GeoRelationsSample.Controllers
{
    public class LanguageInCountryController : Controller
    {
        private readonly GeoRelationsDbContext _context;

        public LanguageInCountryController(GeoRelationsDbContext context)
        {
            _context = context;
        }

        // GET: LanguageInCountry
        public async Task<IActionResult> Index()
        {
            var geoRelationsDbContext = _context.LanguageInCountries.Include(l => l.CountryRef).Include(l => l.LanguageRef);
            return View(await geoRelationsDbContext.ToListAsync());
        }

        // GET: LanguageInCountry/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LanguageInCountries == null)
            {
                return NotFound();
            }

            var languageInCountry = await _context.LanguageInCountries
                .Include(l => l.CountryRef)
                .Include(l => l.LanguageRef)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languageInCountry == null)
            {
                return NotFound();
            }

            return View(languageInCountry);
        }

        // GET: LanguageInCountry/Create
        public IActionResult Create()
        {
            ViewData["CountryList"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["LanguageList"] = new SelectList(_context.Languages, "Id", "Name");
            return View();
        }

        // POST: LanguageInCountry/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Percent,CountryId,LanguageId")] LanguageInCountry languageInCountry)
        {
            //Ist Zustand in DB
            List<LanguageInCountry> languaguesInCountry = _context.LanguageInCountries.Include(c=>c.CountryRef).Where(l => l.CountryId == languageInCountry.CountryId).ToList();

            int percentSum = languaguesInCountry.Sum(p => p.Percent);

            if ((percentSum + languageInCountry.Percent) > 100)
            {
                Country currentCountry = _context.Countries.Find(languageInCountry.CountryId);
                ModelState.AddModelError("Percent", $"Aktuelle Prozentsumme in {currentCountry.Name} -> {percentSum}. Verfügbare Prozentsummer {100-percentSum}");
            }

            if (ModelState.IsValid)
            {
                _context.Add(languageInCountry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryList"] = new SelectList(_context.Countries, "Id", "Name", languageInCountry.CountryId);
            ViewData["LanguageList"] = new SelectList(_context.Languages, "Id", "Name", languageInCountry.LanguageId);


            languageInCountry.Percent = (100 - percentSum);
            return View(languageInCountry);
        }

        // GET: LanguageInCountry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LanguageInCountries == null)
            {
                return NotFound();
            }

            var languageInCountry = await _context.LanguageInCountries.FindAsync(id);
            if (languageInCountry == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", languageInCountry.CountryId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Id", languageInCountry.LanguageId);
            return View(languageInCountry);
        }

        // POST: LanguageInCountry/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Percent,CountryId,LanguageId")] LanguageInCountry languageInCountry)
        {
            if (id != languageInCountry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(languageInCountry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LanguageInCountryExists(languageInCountry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", languageInCountry.CountryId);
            ViewData["LanguageId"] = new SelectList(_context.Languages, "Id", "Id", languageInCountry.LanguageId);
            return View(languageInCountry);
        }

        // GET: LanguageInCountry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LanguageInCountries == null)
            {
                return NotFound();
            }

            var languageInCountry = await _context.LanguageInCountries
                .Include(l => l.CountryRef)
                .Include(l => l.LanguageRef)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (languageInCountry == null)
            {
                return NotFound();
            }

            return View(languageInCountry);
        }

        // POST: LanguageInCountry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LanguageInCountries == null)
            {
                return Problem("Entity set 'GeoRelationsDbContext.LanguageInCountries'  is null.");
            }
            var languageInCountry = await _context.LanguageInCountries.FindAsync(id);
            if (languageInCountry != null)
            {
                _context.LanguageInCountries.Remove(languageInCountry);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LanguageInCountryExists(int id)
        {
          return _context.LanguageInCountries.Any(e => e.Id == id);
        }
    }
}
