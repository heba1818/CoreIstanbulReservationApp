using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreIstanbulReservationApp.Data;
using CoreIstanbulReservationApp.Models;

namespace CoreIstanbulReservationApp.Controllers
{
    public class InstrumentsController : Controller
    {
        private readonly CoreIstanbulReservationAppContext _context;

        public InstrumentsController(CoreIstanbulReservationAppContext context)
        {
            _context = context;
        }

        // GET: Instruments
        public async Task<IActionResult> Index()
        {
              return _context.Inecternace != null ? 
                          View(await _context.Inecternace.ToListAsync()) :
                          Problem("Entity set 'CoreIstanbulReservationAppContext.Inecternace'  is null.");
        }

        // GET: Instruments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inecternace == null)
            {
                return NotFound();
            }

            var instruments = await _context.Inecternace
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instruments == null)
            {
                return NotFound();
            }

            return View(instruments);
        }

        // GET: Instruments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instruments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Instruments instruments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instruments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instruments);
        }

        // GET: Instruments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inecternace == null)
            {
                return NotFound();
            }

            var instruments = await _context.Inecternace.FindAsync(id);
            if (instruments == null)
            {
                return NotFound();
            }
            return View(instruments);
        }

        // POST: Instruments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Instruments instruments)
        {
            if (id != instruments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instruments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrumentsExists(instruments.Id))
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
            return View(instruments);
        }

        // GET: Instruments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inecternace == null)
            {
                return NotFound();
            }

            var instruments = await _context.Inecternace
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instruments == null)
            {
                return NotFound();
            }

            return View(instruments);
        }

        // POST: Instruments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inecternace == null)
            {
                return Problem("Entity set 'CoreIstanbulReservationAppContext.Inecternace'  is null.");
            }
            var instruments = await _context.Inecternace.FindAsync(id);
            if (instruments != null)
            {
                _context.Inecternace.Remove(instruments);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrumentsExists(int id)
        {
          return (_context.Inecternace?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
