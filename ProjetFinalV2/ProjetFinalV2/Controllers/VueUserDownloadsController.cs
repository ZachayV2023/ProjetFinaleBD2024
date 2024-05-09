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
    public class VueUserDownloadsController : Controller
    {
        private readonly DevLibraryDbContext _context;

        public VueUserDownloadsController(DevLibraryDbContext context)
        {
            _context = context;
        }

        // GET: VueUserDownloads
        public async Task<IActionResult> Index(DateOnly? startDate, DateOnly? endDate, string libraryNameFilter)
        {
            var query = _context.VueUserDownloads.AsQueryable();

            if (!string.IsNullOrEmpty(libraryNameFilter))
            {
                query = query.Where(x => x.LibraryName.Contains(libraryNameFilter));
            }
            if (startDate.HasValue)
            {
                query = query.Where(x => x.DownloadDate >= startDate);
            }
            if (endDate.HasValue)
            {
                query = query.Where(x => x.DownloadDate <= endDate);
            }

            var model = new FilteredDownloadsViewModel
            {
                LibraryNameFilter = libraryNameFilter,
                StartDate = startDate,
                EndDate = endDate,
                Downloads = await query.ToListAsync()
            };

            return View(model);
        }

        // GET: VueUserDownloads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueUserDownload = await _context.VueUserDownloads
                .FirstOrDefaultAsync(m => m.IdUtilisateur == id);
            if (vueUserDownload == null)
            {
                return NotFound();
            }

            return View(vueUserDownload);
        }

        // GET: VueUserDownloads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VueUserDownloads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUtilisateur,LibraryName,DownloadDate")] VueUserDownload vueUserDownload)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vueUserDownload);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vueUserDownload);
        }

        // GET: VueUserDownloads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueUserDownload = await _context.VueUserDownloads.FindAsync(id);
            if (vueUserDownload == null)
            {
                return NotFound();
            }
            return View(vueUserDownload);
        }

        // POST: VueUserDownloads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUtilisateur,LibraryName,DownloadDate")] VueUserDownload vueUserDownload)
        {
            if (id != vueUserDownload.IdUtilisateur)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vueUserDownload);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VueUserDownloadExists(vueUserDownload.IdUtilisateur))
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
            return View(vueUserDownload);
        }

        // GET: VueUserDownloads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vueUserDownload = await _context.VueUserDownloads
                .FirstOrDefaultAsync(m => m.IdUtilisateur == id);
            if (vueUserDownload == null)
            {
                return NotFound();
            }

            return View(vueUserDownload);
        }

        // POST: VueUserDownloads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vueUserDownload = await _context.VueUserDownloads.FindAsync(id);
            if (vueUserDownload != null)
            {
                _context.VueUserDownloads.Remove(vueUserDownload);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VueUserDownloadExists(int id)
        {
            return _context.VueUserDownloads.Any(e => e.IdUtilisateur == id);
        }
    }
}
