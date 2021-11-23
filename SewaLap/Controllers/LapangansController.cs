using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SewaLap.Models;

namespace SewaLap.Controllers
{
    public class LapangansController : Controller
    {
        private readonly SewaLapanganContext _context;

        public LapangansController(SewaLapanganContext context)
        {
            _context = context;
        }

        // GET: Lapangans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lapangans.ToListAsync());
        }

        // GET: Lapangans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lapangan = await _context.Lapangans
                .FirstOrDefaultAsync(m => m.IdLapangan == id);
            if (lapangan == null)
            {
                return NotFound();
            }

            return View(lapangan);
        }

        // GET: Lapangans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lapangans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLapangan,NamaLapangan")] Lapangan lapangan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lapangan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lapangan);
        }

        // GET: Lapangans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lapangan = await _context.Lapangans.FindAsync(id);
            if (lapangan == null)
            {
                return NotFound();
            }
            return View(lapangan);
        }

        // POST: Lapangans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLapangan,NamaLapangan")] Lapangan lapangan)
        {
            if (id != lapangan.IdLapangan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lapangan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LapanganExists(lapangan.IdLapangan))
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
            return View(lapangan);
        }

        // GET: Lapangans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lapangan = await _context.Lapangans
                .FirstOrDefaultAsync(m => m.IdLapangan == id);
            if (lapangan == null)
            {
                return NotFound();
            }

            return View(lapangan);
        }

        // POST: Lapangans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lapangan = await _context.Lapangans.FindAsync(id);
            _context.Lapangans.Remove(lapangan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LapanganExists(int id)
        {
            return _context.Lapangans.Any(e => e.IdLapangan == id);
        }
    }
}
