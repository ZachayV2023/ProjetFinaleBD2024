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
    public class VueEmailsDechiffresController : Controller
    {
        private readonly DevLibraryDbContext _context;

        public VueEmailsDechiffresController(DevLibraryDbContext context)
        {
            _context = context;
        }

        // GET: VueEmailsDechiffres
        public async Task<IActionResult> Index()
        {
            return View(await _context.VueEmailsDechiffres.ToListAsync());
        }

        // GET: VueEmailsDechiffres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueEmailsDechiffre = await _context.VueEmailsDechiffres
                .FirstOrDefaultAsync(m => m.IdUtilisateur == id);
            if (vueEmailsDechiffre == null)
            {
                return NotFound();
            }

            return View(vueEmailsDechiffre);
        }

        // GET: VueEmailsDechiffres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VueEmailsDechiffres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUtilisateur,EmailDecrypted")] VueEmailsDechiffre vueEmailsDechiffre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vueEmailsDechiffre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vueEmailsDechiffre);
        }

        // GET: VueEmailsDechiffres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueEmailsDechiffre = await _context.VueEmailsDechiffres.FindAsync(id);
            if (vueEmailsDechiffre == null)
            {
                return NotFound();
            }
            return View(vueEmailsDechiffre);
        }

        // POST: VueEmailsDechiffres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUtilisateur,EmailDecrypted")] VueEmailsDechiffre vueEmailsDechiffre)
        {
            if (id != vueEmailsDechiffre.IdUtilisateur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vueEmailsDechiffre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VueEmailsDechiffreExists(vueEmailsDechiffre.IdUtilisateur))
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
            return View(vueEmailsDechiffre);
        }

        // GET: VueEmailsDechiffres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueEmailsDechiffre = await _context.VueEmailsDechiffres
                .FirstOrDefaultAsync(m => m.IdUtilisateur == id);
            if (vueEmailsDechiffre == null)
            {
                return NotFound();
            }

            return View(vueEmailsDechiffre);
        }

        // POST: VueEmailsDechiffres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vueEmailsDechiffre = await _context.VueEmailsDechiffres.FindAsync(id);
            if (vueEmailsDechiffre != null)
            {
                _context.VueEmailsDechiffres.Remove(vueEmailsDechiffre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VueEmailsDechiffreExists(int id)
        {
            return _context.VueEmailsDechiffres.Any(e => e.IdUtilisateur == id);
        }
    }
}
