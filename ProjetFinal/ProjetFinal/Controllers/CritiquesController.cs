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
    public class CritiquesController : Controller
    {
        private readonly DevLibraryDBContext _context;

        public CritiquesController(DevLibraryDBContext context)
        {
            _context = context;
        }

        // GET: Critiques
        public async Task<IActionResult> Index()
        {
            var devLibraryDBContext = _context.Critiques.Include(c => c.IdBibliothequeNavigation);
            return View(await devLibraryDBContext.ToListAsync());
        }

        // GET: Critiques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Critiques == null)
            {
                return NotFound();
            }

            var critique = await _context.Critiques
                .Include(c => c.IdBibliothequeNavigation)
                .FirstOrDefaultAsync(m => m.IdCritique == id);
            if (critique == null)
            {
                return NotFound();
            }

            return View(critique);
        }

        // GET: Critiques/Create
        public IActionResult Create()
        {
            ViewData["IdBibliotheque"] = new SelectList(_context.Bibliotheques, "IdBibliotheque", "IdBibliotheque");
            return View();
        }

        // POST: Critiques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCritique,Date,Message,Rating,NomUtilisateur,ReplyCritique,IdBibliotheque")] Critique critique)
        {
            if (ModelState.IsValid)
            {
                _context.Add(critique);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBibliotheque"] = new SelectList(_context.Bibliotheques, "IdBibliotheque", "IdBibliotheque", critique.IdBibliotheque);
            return View(critique);
        }

        // GET: Critiques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Critiques == null)
            {
                return NotFound();
            }

            var critique = await _context.Critiques.FindAsync(id);
            if (critique == null)
            {
                return NotFound();
            }
            ViewData["IdBibliotheque"] = new SelectList(_context.Bibliotheques, "IdBibliotheque", "IdBibliotheque", critique.IdBibliotheque);
            return View(critique);
        }

        // POST: Critiques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCritique,Date,Message,Rating,NomUtilisateur,ReplyCritique,IdBibliotheque")] Critique critique)
        {
            if (id != critique.IdCritique)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(critique);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CritiqueExists(critique.IdCritique))
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
            ViewData["IdBibliotheque"] = new SelectList(_context.Bibliotheques, "IdBibliotheque", "IdBibliotheque", critique.IdBibliotheque);
            return View(critique);
        }

        // GET: Critiques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Critiques == null)
            {
                return NotFound();
            }

            var critique = await _context.Critiques
                .Include(c => c.IdBibliothequeNavigation)
                .FirstOrDefaultAsync(m => m.IdCritique == id);
            if (critique == null)
            {
                return NotFound();
            }

            return View(critique);
        }

        // POST: Critiques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Critiques == null)
            {
                return Problem("Entity set 'DevLibraryDBContext.Critiques'  is null.");
            }
            var critique = await _context.Critiques.FindAsync(id);
            if (critique != null)
            {
                _context.Critiques.Remove(critique);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CritiqueExists(int id)
        {
          return (_context.Critiques?.Any(e => e.IdCritique == id)).GetValueOrDefault();
        }
    }
}
