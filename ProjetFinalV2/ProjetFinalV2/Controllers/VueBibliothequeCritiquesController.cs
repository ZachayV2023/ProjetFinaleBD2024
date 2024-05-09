using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetFinalV2.Data;
using ProjetFinalV2.Models;

namespace ProjetFinalV2.Controllers
{
    public class VueBibliothequeCritiquesController : Controller
    {
        private readonly DevLibraryDbContext _context;

        public VueBibliothequeCritiquesController(DevLibraryDbContext context)
        {
            _context = context;
        }

        // GET: VueBibliothequeCritiques
        public async Task<IActionResult> Index()
        {
            return View(await _context.VueBibliothequeCritiques.ToListAsync());
        }

        // GET: VueBibliothequeCritiques/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueBibliothequeCritique = await _context.VueBibliothequeCritiques
                .FirstOrDefaultAsync(m => m.Nom == id);
            if (vueBibliothequeCritique == null)
            {
                return NotFound();
            }

            return View(vueBibliothequeCritique);
        }

        // GET: VueBibliothequeCritiques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VueBibliothequeCritiques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VueBibliothequeCritiqueId,Nom,Categorie,NombreCritiques,MoyenneNotation,NombreMisesAjour,DerniereVersion,MoyenneLignesCodeFonctions,NombreFonctions")] VueBibliothequeCritique vueBibliothequeCritique)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vueBibliothequeCritique);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vueBibliothequeCritique);
        }

        // GET: VueBibliothequeCritiques/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueBibliothequeCritique = await _context.VueBibliothequeCritiques.FindAsync(id);
            if (vueBibliothequeCritique == null)
            {
                return NotFound();
            }
            return View(vueBibliothequeCritique);
        }

        // POST: VueBibliothequeCritiques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VueBibliothequeCritiqueId,Nom,Categorie,NombreCritiques,MoyenneNotation,NombreMisesAjour,DerniereVersion,MoyenneLignesCodeFonctions,NombreFonctions")] VueBibliothequeCritique vueBibliothequeCritique)
        {
            if (id != vueBibliothequeCritique.Nom)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vueBibliothequeCritique);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VueBibliothequeCritiqueExists(vueBibliothequeCritique.Nom))
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
            return View(vueBibliothequeCritique);
        }

        // GET: VueBibliothequeCritiques/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueBibliothequeCritique = await _context.VueBibliothequeCritiques
                .FirstOrDefaultAsync(m => m.Nom == id);
            if (vueBibliothequeCritique == null)
            {
                return NotFound();
            }

            return View(vueBibliothequeCritique);
        }

        // POST: VueBibliothequeCritiques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vueBibliothequeCritique = await _context.VueBibliothequeCritiques.FindAsync(id);
            if (vueBibliothequeCritique != null)
            {
                _context.VueBibliothequeCritiques.Remove(vueBibliothequeCritique);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VueBibliothequeCritiqueExists(string id)
        {
            return _context.VueBibliothequeCritiques.Any(e => e.Nom == id);
        }
    }
}
