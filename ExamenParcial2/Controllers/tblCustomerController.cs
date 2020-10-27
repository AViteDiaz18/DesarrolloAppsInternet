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
    public class tblCustomerController : Controller
    {
        private readonly HotelContext _context;

        public tblCustomerController(HotelContext context)
        {
            _context = context;
        }

        // GET: tblCustomer
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBLCostumers.ToListAsync());
        }

        // GET: tblCustomer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCustomers = await _context.TBLCostumers
                .FirstOrDefaultAsync(m => m.IngCustomerID == id);
            if (tblCustomers == null)
            {
                return NotFound();
            }

            return View(tblCustomers);
        }

        // GET: tblCustomer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblCustomer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngCustomerID,txtCustomerTitle,txtCustomerForenames,txtCustomerSurnames,dteCustomerDOB,txtCustomerAddressStreet,txtCustomerAddressTown,txtCustomerAddressCountry,txtCustomerAddressPostalCode,txtCustomerHomePhone,txtCustomerWorkPhone,txtCustomerMobilePhone,hypCustomerEmail")] tblCustomers tblCustomers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCustomers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCustomers);
        }

        // GET: tblCustomer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCustomers = await _context.TBLCostumers.FindAsync(id);
            if (tblCustomers == null)
            {
                return NotFound();
            }
            return View(tblCustomers);
        }

        // POST: tblCustomer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngCustomerID,txtCustomerTitle,txtCustomerForenames,txtCustomerSurnames,dteCustomerDOB,txtCustomerAddressStreet,txtCustomerAddressTown,txtCustomerAddressCountry,txtCustomerAddressPostalCode,txtCustomerHomePhone,txtCustomerWorkPhone,txtCustomerMobilePhone,hypCustomerEmail")] tblCustomers tblCustomers)
        {
            if (id != tblCustomers.IngCustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCustomers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCustomersExists(tblCustomers.IngCustomerID))
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
            return View(tblCustomers);
        }

        // GET: tblCustomer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCustomers = await _context.TBLCostumers
                .FirstOrDefaultAsync(m => m.IngCustomerID == id);
            if (tblCustomers == null)
            {
                return NotFound();
            }

            return View(tblCustomers);
        }

        // POST: tblCustomer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCustomers = await _context.TBLCostumers.FindAsync(id);
            _context.TBLCostumers.Remove(tblCustomers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblCustomersExists(int id)
        {
            return _context.TBLCostumers.Any(e => e.IngCustomerID == id);
        }
    }
}
