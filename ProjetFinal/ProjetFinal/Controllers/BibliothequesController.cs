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
    public class BibliothequesController : Controller
    {
        private readonly DevLibraryDBContext _context;

        public BibliothequesController(DevLibraryDBContext context)
        {
            _context = context;
        }

        // GET: Bibliotheques
        public async Task<IActionResult> Index()
        {
              return _context.Bibliotheques != null ? 
                          View(await _context.Bibliotheques.ToListAsync()) :
                          Problem("Entity set 'DevLibraryDBContext.Bibliotheques'  is null.");
        }

        // GET: Bibliotheques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bibliotheques == null)
            {
                return NotFound();
            }

            var bibliotheque = await _context.Bibliotheques
                .FirstOrDefaultAsync(m => m.IdBibliotheque == id);
            if (bibliotheque == null)
            {
                return NotFound();
            }

            return View(bibliotheque);
        }

        // GET: Bibliotheques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bibliotheques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBibliotheque,Nom,Description,DateCreation,Categorie,TotalTelechargements")] Bibliotheque bibliotheque)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bibliotheque);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bibliotheque);
        }

        // GET: Bibliotheques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bibliotheques == null)
            {
                return NotFound();
            }

            var bibliotheque = await _context.Bibliotheques.FindAsync(id);
            if (bibliotheque == null)
            {
                return NotFound();
            }
            return View(bibliotheque);
        }

        // POST: Bibliotheques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBibliotheque,Nom,Description,DateCreation,Categorie,TotalTelechargements")] Bibliotheque bibliotheque)
        {
            if (id != bibliotheque.IdBibliotheque)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bibliotheque);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BibliothequeExists(bibliotheque.IdBibliotheque))
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
            return View(bibliotheque);
        }

        // GET: Bibliotheques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bibliotheques == null)
            {
                return NotFound();
            }

            var bibliotheque = await _context.Bibliotheques
                .FirstOrDefaultAsync(m => m.IdBibliotheque == id);
            if (bibliotheque == null)
            {
                return NotFound();
            }

            return View(bibliotheque);
        }

        // POST: Bibliotheques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bibliotheques == null)
            {
                return Problem("Entity set 'DevLibraryDBContext.Bibliotheques'  is null.");
            }
            var bibliotheque = await _context.Bibliotheques.FindAsync(id);
            if (bibliotheque != null)
            {
                _context.Bibliotheques.Remove(bibliotheque);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BibliothequeExists(int id)
        {
          return (_context.Bibliotheques?.Any(e => e.IdBibliotheque == id)).GetValueOrDefault();
        }
    }
}
