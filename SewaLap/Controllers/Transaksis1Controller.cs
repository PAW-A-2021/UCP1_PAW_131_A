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
    public class Transaksis1Controller : Controller
    {
        private readonly SewaLapanganContext _context;

        public Transaksis1Controller(SewaLapanganContext context)
        {
            _context = context;
        }

        // GET: Transaksis1
        public async Task<IActionResult> Index()
        {
            var sewaLapanganContext = _context.Transaksis.Include(t => t.IdAdminNavigation).Include(t => t.IdCustomerNavigation).Include(t => t.IdLapanganNavigation);
            return View(await sewaLapanganContext.ToListAsync());
        }

        // GET: Transaksis1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis
                .Include(t => t.IdAdminNavigation)
                .Include(t => t.IdCustomerNavigation)
                .Include(t => t.IdLapanganNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // GET: Transaksis1/Create
        public IActionResult Create()
        {
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "IdAdmin");
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer");
            ViewData["IdLapangan"] = new SelectList(_context.Lapangans, "IdLapangan", "IdLapangan");
            return View();
        }

        // POST: Transaksis1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTransaksi,IdAdmin,IdLapangan,IdCustomer,TotalTransaksi")] Transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaksi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "IdAdmin", transaksi.IdAdmin);
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", transaksi.IdCustomer);
            ViewData["IdLapangan"] = new SelectList(_context.Lapangans, "IdLapangan", "IdLapangan", transaksi.IdLapangan);
            return View(transaksi);
        }

        // GET: Transaksis1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis.FindAsync(id);
            if (transaksi == null)
            {
                return NotFound();
            }
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "IdAdmin", transaksi.IdAdmin);
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", transaksi.IdCustomer);
            ViewData["IdLapangan"] = new SelectList(_context.Lapangans, "IdLapangan", "IdLapangan", transaksi.IdLapangan);
            return View(transaksi);
        }

        // POST: Transaksis1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTransaksi,IdAdmin,IdLapangan,IdCustomer,TotalTransaksi")] Transaksi transaksi)
        {
            if (id != transaksi.IdTransaksi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaksi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaksiExists(transaksi.IdTransaksi))
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
            ViewData["IdAdmin"] = new SelectList(_context.Admins, "IdAdmin", "IdAdmin", transaksi.IdAdmin);
            ViewData["IdCustomer"] = new SelectList(_context.Customers, "IdCustomer", "IdCustomer", transaksi.IdCustomer);
            ViewData["IdLapangan"] = new SelectList(_context.Lapangans, "IdLapangan", "IdLapangan", transaksi.IdLapangan);
            return View(transaksi);
        }

        // GET: Transaksis1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaksi = await _context.Transaksis
                .Include(t => t.IdAdminNavigation)
                .Include(t => t.IdCustomerNavigation)
                .Include(t => t.IdLapanganNavigation)
                .FirstOrDefaultAsync(m => m.IdTransaksi == id);
            if (transaksi == null)
            {
                return NotFound();
            }

            return View(transaksi);
        }

        // POST: Transaksis1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaksi = await _context.Transaksis.FindAsync(id);
            _context.Transaksis.Remove(transaksi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaksiExists(int id)
        {
            return _context.Transaksis.Any(e => e.IdTransaksi == id);
        }
    }
}
