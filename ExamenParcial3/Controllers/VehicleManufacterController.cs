using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenParcial3.Data;
using ExamenParcial3.Models;

namespace ExamenParcial3.Controllers
{
    public class VehicleManufacterController : Controller
    {
        private readonly CarContext _context;

        public VehicleManufacterController(CarContext context)
        {
            _context = context;
        }

        // GET: VehicleManufacter
        public async Task<IActionResult> Index(string searchString)
        {
            var manufacter = from ma in _context.VehicleManufacters select ma;
            if(!string.IsNullOrEmpty(searchString)) {
                manufacter = manufacter.Where(ma => ma.ManufacterName.Contains(searchString));
            }

            return View(await manufacter.ToListAsync());
        }

        // GET: VehicleManufacter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleManufacter = await _context.VehicleManufacters
                .FirstOrDefaultAsync(m => m.ManufacterID == id);
            if (vehicleManufacter == null)
            {
                return NotFound();
            }

            return View(vehicleManufacter);
        }

        // GET: VehicleManufacter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleManufacter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManufacterID,ManufacterName")] VehicleManufacter vehicleManufacter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleManufacter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleManufacter);
        }

        // GET: VehicleManufacter/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleManufacter = await _context.VehicleManufacters.FindAsync(id);
            if (vehicleManufacter == null)
            {
                return NotFound();
            }
            return View(vehicleManufacter);
        }

        // POST: VehicleManufacter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManufacterID,ManufacterName")] VehicleManufacter vehicleManufacter)
        {
            if (id != vehicleManufacter.ManufacterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleManufacter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleManufacterExists(vehicleManufacter.ManufacterID))
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
            return View(vehicleManufacter);
        }

        // GET: VehicleManufacter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleManufacter = await _context.VehicleManufacters
                .FirstOrDefaultAsync(m => m.ManufacterID == id);
            if (vehicleManufacter == null)
            {
                return NotFound();
            }

            return View(vehicleManufacter);
        }

        // POST: VehicleManufacter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleManufacter = await _context.VehicleManufacters.FindAsync(id);
            _context.VehicleManufacters.Remove(vehicleManufacter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleManufacterExists(int id)
        {
            return _context.VehicleManufacters.Any(e => e.ManufacterID == id);
        }
    }
}
