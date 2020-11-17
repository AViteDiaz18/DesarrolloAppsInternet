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
    public class VehicleFuelTypeController : Controller
    {
        private readonly CarContext _context;

        public VehicleFuelTypeController(CarContext context)
        {
            _context = context;
        }

        // GET: VehicleFuelType
        public async Task<IActionResult> Index()
        {
             var _models = _context.VehicleFuelTypes
            .Include(i => i.VehicleDetails)
                .ThenInclude(i => i.VehicleModel)
                .ThenInclude(i => i.VehicleManufacter)
            .AsNoTracking();

            return View(await _models.ToListAsync());
        }

        // GET: VehicleFuelType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _models = _context.VehicleFuelTypes
            .Include(i => i.VehicleDetails)
                .ThenInclude(i => i.VehicleModel)
                .ThenInclude(i => i.VehicleManufacter)
            .AsNoTracking();

            var vehicleFuelType = await _models
                .FirstOrDefaultAsync(m => m.FuelTypeID == id);
            if (vehicleFuelType == null)
            {
                return NotFound();
            }

            return View(vehicleFuelType);
        }

        // GET: VehicleFuelType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleFuelType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuelTypeID,FuelTypeName")] VehicleFuelType vehicleFuelType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleFuelType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleFuelType);
        }

        // GET: VehicleFuelType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleFuelType = await _context.VehicleFuelTypes.FindAsync(id);
            if (vehicleFuelType == null)
            {
                return NotFound();
            }
            return View(vehicleFuelType);
        }

        // POST: VehicleFuelType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuelTypeID,FuelTypeName")] VehicleFuelType vehicleFuelType)
        {
            if (id != vehicleFuelType.FuelTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleFuelType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleFuelTypeExists(vehicleFuelType.FuelTypeID))
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
            return View(vehicleFuelType);
        }

        // GET: VehicleFuelType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var _models = _context.VehicleFuelTypes
            .Include(i => i.VehicleDetails)
                .ThenInclude(i => i.VehicleModel)
                .ThenInclude(i => i.VehicleManufacter)
            .AsNoTracking();

            var vehicleFuelType = await _models
                .FirstOrDefaultAsync(m => m.FuelTypeID == id);
            if (vehicleFuelType == null)
            {
                return NotFound();
            }

            return View(vehicleFuelType);
        }

        // POST: VehicleFuelType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleFuelType = await _context.VehicleFuelTypes.FindAsync(id);
            _context.VehicleFuelTypes.Remove(vehicleFuelType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleFuelTypeExists(int id)
        {
            return _context.VehicleFuelTypes.Any(e => e.FuelTypeID == id);
        }
    }
}
