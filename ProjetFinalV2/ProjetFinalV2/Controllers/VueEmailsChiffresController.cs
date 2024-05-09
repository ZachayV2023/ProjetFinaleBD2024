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
    public class VueEmailsChiffresController : Controller
    {
        private readonly DevLibraryDbContext _context;

        public VueEmailsChiffresController(DevLibraryDbContext context)
        {
            _context = context;
        }

        // GET: VueEmailsChiffres
        public async Task<IActionResult> Index()
        {
            return View(await _context.VueEmailsChiffres.ToListAsync());
        }

        // GET: VueEmailsChiffres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueEmailsChiffre = await _context.VueEmailsChiffres
                .FirstOrDefaultAsync(m => m.IdUtilisateur == id);
            if (vueEmailsChiffre == null)
            {
                return NotFound();
            }

            return View(vueEmailsChiffre);
        }

        // GET: VueEmailsChiffres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VueEmailsChiffres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUtilisateur,EmailEncrypted")] VueEmailsChiffre vueEmailsChiffre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vueEmailsChiffre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vueEmailsChiffre);
        }

        // GET: VueEmailsChiffres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueEmailsChiffre = await _context.VueEmailsChiffres.FindAsync(id);
            if (vueEmailsChiffre == null)
            {
                return NotFound();
            }
            return View(vueEmailsChiffre);
        }

        // POST: VueEmailsChiffres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUtilisateur,EmailEncrypted")] VueEmailsChiffre vueEmailsChiffre)
        {
            if (id != vueEmailsChiffre.IdUtilisateur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vueEmailsChiffre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VueEmailsChiffreExists(vueEmailsChiffre.IdUtilisateur))
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
            return View(vueEmailsChiffre);
        }

        // GET: VueEmailsChiffres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueEmailsChiffre = await _context.VueEmailsChiffres
                .FirstOrDefaultAsync(m => m.IdUtilisateur == id);
            if (vueEmailsChiffre == null)
            {
                return NotFound();
            }

            return View(vueEmailsChiffre);
        }

        // POST: VueEmailsChiffres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vueEmailsChiffre = await _context.VueEmailsChiffres.FindAsync(id);
            if (vueEmailsChiffre != null)
            {
                _context.VueEmailsChiffres.Remove(vueEmailsChiffre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VueEmailsChiffreExists(int id)
        {
            return _context.VueEmailsChiffres.Any(e => e.IdUtilisateur == id);
        }
    }
}
