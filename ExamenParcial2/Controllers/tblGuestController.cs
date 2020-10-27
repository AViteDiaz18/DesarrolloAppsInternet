using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenParcial2.Data;
using ExamenParcial2.Models;

namespace ExamenParcial2.Controllers
{
    public class tblGuestController : Controller
    {
        private readonly HotelContext _context;

        public tblGuestController(HotelContext context)
        {
            _context = context;
        }

        // GET: tblGuest
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBLGuests.ToListAsync());
        }

        // GET: tblGuest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuests = await _context.TBLGuests
                .FirstOrDefaultAsync(m => m.IngGuestID == id);
            if (tblGuests == null)
            {
                return NotFound();
            }

            return View(tblGuests);
        }

        // GET: tblGuest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblGuest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngGuestID,txtGuestTitle,txtGuestForenames,txtGuestSurnames,dteGuestDOB,txtGuestAddressStreet,txtGuestAddressTown,txtGuestAddressCountry,txtGuestAddressPostalCode,txtGuestContactPhone")] tblGuests tblGuests)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblGuests);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblGuests);
        }

        // GET: tblGuest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuests = await _context.TBLGuests.FindAsync(id);
            if (tblGuests == null)
            {
                return NotFound();
            }
            return View(tblGuests);
        }

        // POST: tblGuest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngGuestID,txtGuestTitle,txtGuestForenames,txtGuestSurnames,dteGuestDOB,txtGuestAddressStreet,txtGuestAddressTown,txtGuestAddressCountry,txtGuestAddressPostalCode,txtGuestContactPhone")] tblGuests tblGuests)
        {
            if (id != tblGuests.IngGuestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblGuests);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblGuestsExists(tblGuests.IngGuestID))
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
            return View(tblGuests);
        }

        // GET: tblGuest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblGuests = await _context.TBLGuests
                .FirstOrDefaultAsync(m => m.IngGuestID == id);
            if (tblGuests == null)
            {
                return NotFound();
            }

            return View(tblGuests);
        }

        // POST: tblGuest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblGuests = await _context.TBLGuests.FindAsync(id);
            _context.TBLGuests.Remove(tblGuests);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblGuestsExists(int id)
        {
            return _context.TBLGuests.Any(e => e.IngGuestID == id);
        }
    }
}
