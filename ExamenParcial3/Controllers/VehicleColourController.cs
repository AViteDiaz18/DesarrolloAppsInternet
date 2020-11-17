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
    public class VehicleColourController : Controller
    {
        private readonly CarContext _context;

        public VehicleColourController(CarContext context)
        {
            _context = context;
        }

        // GET: VehicleColour
        public async Task<IActionResult> Index()
        {
            var _color = _context.VehicleColours
            .Include(c => c.VehicleDetails)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehicleManufacter)
            .AsNoTracking();
            return View(await _color.ToListAsync());
        }

        // GET: VehicleColour/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleColour = await _context.VehicleColours
                .FirstOrDefaultAsync(m => m.ColourID == id);
            if (vehicleColour == null)
            {
                return NotFound();
            }

            return View(vehicleColour);
        }

        // GET: VehicleColour/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleColour/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColourID,ColourName")] VehicleColour vehicleColour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleColour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleColour);
        }

        // GET: VehicleColour/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleColour = await _context.VehicleColours.FindAsync(id);
            if (vehicleColour == null)
            {
                return NotFound();
            }
            return View(vehicleColour);
        }

        // POST: VehicleColour/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColourID,ColourName")] VehicleColour vehicleColour)
        {
            if (id != vehicleColour.ColourID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleColour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleColourExists(vehicleColour.ColourID))
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
            return View(vehicleColour);
        }

        // GET: VehicleColour/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleColour = await _context.VehicleColours
                .FirstOrDefaultAsync(m => m.ColourID == id);
            if (vehicleColour == null)
            {
                return NotFound();
            }

            return View(vehicleColour);
        }

        // POST: VehicleColour/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleColour = await _context.VehicleColours.FindAsync(id);
            _context.VehicleColours.Remove(vehicleColour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleColourExists(int id)
        {
            return _context.VehicleColours.Any(e => e.ColourID == id);
        }
    }
}
