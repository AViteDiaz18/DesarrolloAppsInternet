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
    public class tblPaymentController : Controller
    {
        private readonly HotelContext _context;

        public tblPaymentController(HotelContext context)
        {
            _context = context;
        }

        // GET: tblPayment
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBLPayments.ToListAsync());
        }

        // GET: tblPayment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPayments = await _context.TBLPayments
                .FirstOrDefaultAsync(m => m.IngPaymentID == id);
            if (tblPayments == null)
            {
                return NotFound();
            }

            return View(tblPayments);
        }

        // GET: tblPayment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblPayment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngPaymentID,IngBookingID,IngCustomerID,IngPaymentMethodID,curPaymentAmount,memPaymentAmountComments")] tblPayments tblPayments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPayments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblPayments);
        }

        // GET: tblPayment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPayments = await _context.TBLPayments.FindAsync(id);
            if (tblPayments == null)
            {
                return NotFound();
            }
            return View(tblPayments);
        }

        // POST: tblPayment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngPaymentID,IngBookingID,IngCustomerID,IngPaymentMethodID,curPaymentAmount,memPaymentAmountComments")] tblPayments tblPayments)
        {
            if (id != tblPayments.IngPaymentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPayments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblPaymentsExists(tblPayments.IngPaymentID))
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
            return View(tblPayments);
        }

        // GET: tblPayment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPayments = await _context.TBLPayments
                .FirstOrDefaultAsync(m => m.IngPaymentID == id);
            if (tblPayments == null)
            {
                return NotFound();
            }

            return View(tblPayments);
        }

        // POST: tblPayment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPayments = await _context.TBLPayments.FindAsync(id);
            _context.TBLPayments.Remove(tblPayments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblPaymentsExists(int id)
        {
            return _context.TBLPayments.Any(e => e.IngPaymentID == id);
        }
    }
}
