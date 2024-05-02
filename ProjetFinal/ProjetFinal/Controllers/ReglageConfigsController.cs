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
    public class ReglageConfigsController : Controller
    {
        private readonly DevLibraryDBContext _context;

        public ReglageConfigsController(DevLibraryDBContext context)
        {
            _context = context;
        }

        // GET: ReglageConfigs
        public async Task<IActionResult> Index()
        {
              return _context.ReglageConfigs != null ? 
                          View(await _context.ReglageConfigs.ToListAsync()) :
                          Problem("Entity set 'DevLibraryDBContext.ReglageConfigs'  is null.");
        }

        // GET: ReglageConfigs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReglageConfigs == null)
            {
                return NotFound();
            }

            var reglageConfig = await _context.ReglageConfigs
                .FirstOrDefaultAsync(m => m.IdConfig == id);
            if (reglageConfig == null)
            {
                return NotFound();
            }

            return View(reglageConfig);
        }

        // GET: ReglageConfigs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReglageConfigs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConfig,Theme,NomMembre,LangPref,NotificationAct")] ReglageConfig reglageConfig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reglageConfig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reglageConfig);
        }

        // GET: ReglageConfigs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReglageConfigs == null)
            {
                return NotFound();
            }

            var reglageConfig = await _context.ReglageConfigs.FindAsync(id);
            if (reglageConfig == null)
            {
                return NotFound();
            }
            return View(reglageConfig);
        }

        // POST: ReglageConfigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConfig,Theme,NomMembre,LangPref,NotificationAct")] ReglageConfig reglageConfig)
        {
            if (id != reglageConfig.IdConfig)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reglageConfig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReglageConfigExists(reglageConfig.IdConfig))
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
            return View(reglageConfig);
        }

        // GET: ReglageConfigs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReglageConfigs == null)
            {
                return NotFound();
            }

            var reglageConfig = await _context.ReglageConfigs
                .FirstOrDefaultAsync(m => m.IdConfig == id);
            if (reglageConfig == null)
            {
                return NotFound();
            }

            return View(reglageConfig);
        }

        // POST: ReglageConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReglageConfigs == null)
            {
                return Problem("Entity set 'DevLibraryDBContext.ReglageConfigs'  is null.");
            }
            var reglageConfig = await _context.ReglageConfigs.FindAsync(id);
            if (reglageConfig != null)
            {
                _context.ReglageConfigs.Remove(reglageConfig);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReglageConfigExists(int id)
        {
          return (_context.ReglageConfigs?.Any(e => e.IdConfig == id)).GetValueOrDefault();
        }
    }
}
