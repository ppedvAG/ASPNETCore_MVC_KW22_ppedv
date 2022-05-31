using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieStoreGeneratedApp.Data;
using MovieStoreGeneratedApp.Models;

namespace MovieStoreGeneratedApp.Controllers
{
    public class RegisseurController : Controller
    {
        private readonly MovieStoreGeneratedDbContext _context;

        public RegisseurController(MovieStoreGeneratedDbContext context)
        {
            _context = context;
        }

        // GET: Regisseur
        public async Task<IActionResult> Index()
        {
              return _context.Regisseurs != null ? 
                          View(await _context.Regisseurs.ToListAsync()) :
                          Problem("Entity set 'MovieStoreGeneratedDbContext.Regisseurs'  is null.");
        }

        // GET: Regisseur/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Regisseurs == null)
            {
                return NotFound();
            }

            var regisseur = await _context.Regisseurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regisseur == null)
            {
                return NotFound();
            }

            return View(regisseur);
        }

        // GET: Regisseur/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regisseur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Regisseur regisseur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regisseur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regisseur);
        }

        // GET: Regisseur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Regisseurs == null)
            {
                return NotFound();
            }

            var regisseur = await _context.Regisseurs.FindAsync(id);
            if (regisseur == null)
            {
                return NotFound();
            }
            return View(regisseur);
        }

        // POST: Regisseur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Regisseur regisseur)
        {
            if (id != regisseur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regisseur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisseurExists(regisseur.Id))
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
            return View(regisseur);
        }

        // GET: Regisseur/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Regisseurs == null)
            {
                return NotFound();
            }

            var regisseur = await _context.Regisseurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regisseur == null)
            {
                return NotFound();
            }

            return View(regisseur);
        }

        // POST: Regisseur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Regisseurs == null)
            {
                return Problem("Entity set 'MovieStoreGeneratedDbContext.Regisseurs'  is null.");
            }
            var regisseur = await _context.Regisseurs.FindAsync(id);
            if (regisseur != null)
            {
                _context.Regisseurs.Remove(regisseur);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisseurExists(int id)
        {
          return (_context.Regisseurs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
