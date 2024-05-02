using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetFinal.Data;
using ProjetFinal.Models;

namespace ProjetFinal.Controllers
{
    public class FonctionsController : Controller
    {
        private readonly DevLibraryDBContext _context;

        public FonctionsController(DevLibraryDBContext context)
        {
            _context = context;
        }

        // GET: Fonctions
        public async Task<IActionResult> Index()
        {
            var devLibraryDBContext = _context.Fonctions.Include(f => f.IdBibliothequeNavigation);
            return View(await devLibraryDBContext.ToListAsync());
        }

        // GET: Fonctions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fonctions == null)
            {
                return NotFound();
            }

            var fonction = await _context.Fonctions
                .Include(f => f.IdBibliothequeNavigation)
                .FirstOrDefaultAsync(m => m.IdFonction == id);
            if (fonction == null)
            {
                return NotFound();
            }

            return View(fonction);
        }

        // GET: Fonctions/Create
        public IActionResult Create()
        {
            ViewData["IdBibliotheque"] = new SelectList(_context.Bibliotheques, "IdBibliotheque", "IdBibliotheque");
            return View();
        }

        // POST: Fonctions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFonction,Nom,Description,NombreLignesDeCode,DernierUpdate,IdBibliotheque")] Fonction fonction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fonction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBibliotheque"] = new SelectList(_context.Bibliotheques, "IdBibliotheque", "IdBibliotheque", fonction.IdBibliotheque);
            return View(fonction);
        }

        // GET: Fonctions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fonctions == null)
            {
                return NotFound();
            }

            var fonction = await _context.Fonctions.FindAsync(id);
            if (fonction == null)
            {
                return NotFound();
            }
            ViewData["IdBibliotheque"] = new SelectList(_context.Bibliotheques, "IdBibliotheque", "IdBibliotheque", fonction.IdBibliotheque);
            return View(fonction);
        }

        // POST: Fonctions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFonction,Nom,Description,NombreLignesDeCode,DernierUpdate,IdBibliotheque")] Fonction fonction)
        {
            if (id != fonction.IdFonction)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fonction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FonctionExists(fonction.IdFonction))
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
            ViewData["IdBibliotheque"] = new SelectList(_context.Bibliotheques, "IdBibliotheque", "IdBibliotheque", fonction.IdBibliotheque);
            return View(fonction);
        }

        // GET: Fonctions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fonctions == null)
            {
                return NotFound();
            }

            var fonction = await _context.Fonctions
                .Include(f => f.IdBibliothequeNavigation)
                .FirstOrDefaultAsync(m => m.IdFonction == id);
            if (fonction == null)
            {
                return NotFound();
            }

            return View(fonction);
        }

        // POST: Fonctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fonctions == null)
            {
                return Problem("Entity set 'DevLibraryDBContext.Fonctions'  is null.");
            }
            var fonction = await _context.Fonctions.FindAsync(id);
            if (fonction != null)
            {
                _context.Fonctions.Remove(fonction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FonctionExists(int id)
        {
          return (_context.Fonctions?.Any(e => e.IdFonction == id)).GetValueOrDefault();
        }
    }
}
