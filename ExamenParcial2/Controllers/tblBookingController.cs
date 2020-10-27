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
    public class tblBookingController : Controller
    {
        private readonly HotelContext _context;

        public tblBookingController(HotelContext context)
        {
            _context = context;
        }

        // GET: tblBooking
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBLBookings.ToListAsync());
        }

        // GET: tblBooking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBookings = await _context.TBLBookings
                .FirstOrDefaultAsync(m => m.IngBookingID == id);
            if (tblBookings == null)
            {
                return NotFound();
            }

            return View(tblBookings);
        }

        // GET: tblBooking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblBooking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngBookingID,IngCustomerID,dteDateBookingMade,tmeTimeBookingMade,dteBookedStartDate,dteBookedEndDate,dteTotalPaymentDueDate,curTotalPaymentDueAmount,dterTotalPaymentMadeOn,memBookingComments")] tblBookings tblBookings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblBookings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblBookings);
        }

        // GET: tblBooking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBookings = await _context.TBLBookings.FindAsync(id);
            if (tblBookings == null)
            {
                return NotFound();
            }
            return View(tblBookings);
        }

        // POST: tblBooking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngBookingID,IngCustomerID,dteDateBookingMade,tmeTimeBookingMade,dteBookedStartDate,dteBookedEndDate,dteTotalPaymentDueDate,curTotalPaymentDueAmount,dterTotalPaymentMadeOn,memBookingComments")] tblBookings tblBookings)
        {
            if (id != tblBookings.IngBookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblBookings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblBookingsExists(tblBookings.IngBookingID))
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
            return View(tblBookings);
        }

        // GET: tblBooking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBookings = await _context.TBLBookings
                .FirstOrDefaultAsync(m => m.IngBookingID == id);
            if (tblBookings == null)
            {
                return NotFound();
            }

            return View(tblBookings);
        }

        // POST: tblBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblBookings = await _context.TBLBookings.FindAsync(id);
            _context.TBLBookings.Remove(tblBookings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblBookingsExists(int id)
        {
            return _context.TBLBookings.Any(e => e.IngBookingID == id);
        }
    }
}
