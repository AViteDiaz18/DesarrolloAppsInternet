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
    public class VehicleFeatureController : Controller
    {
        private readonly CarContext _context;

        public VehicleFeatureController(CarContext context)
        {
            _context = context;
        }

        // GET: VehicleFeature
        public async Task<IActionResult> Index()
        {
            var _manufacters = _context.VehicleFeatures
            .Include(i => i.LinkFeatureToVehicles)
                .ThenInclude(i => i.VehicleDetail)
                .ThenInclude(i => i.VehicleModel)
                .ThenInclude(i => i.VehicleManufacter)
            .AsNoTracking();
            return View(await _manufacters.ToListAsync());
        }

        // GET: VehicleFeature/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleFeature = await _context.VehicleFeatures
                .FirstOrDefaultAsync(m => m.FeatureID == id);
            if (vehicleFeature == null)
            {
                return NotFound();
            }

            return View(vehicleFeature);
        }

        // GET: VehicleFeature/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleFeature/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeatureID,FeatureDescription")] VehicleFeature vehicleFeature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleFeature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleFeature);
        }

        // GET: VehicleFeature/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleFeature = await _context.VehicleFeatures.FindAsync(id);
            if (vehicleFeature == null)
            {
                return NotFound();
            }
            return View(vehicleFeature);
        }

        // POST: VehicleFeature/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeatureID,FeatureDescription")] VehicleFeature vehicleFeature)
        {
            if (id != vehicleFeature.FeatureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleFeature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleFeatureExists(vehicleFeature.FeatureID))
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
            return View(vehicleFeature);
        }

        // GET: VehicleFeature/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleFeature = await _context.VehicleFeatures
                .FirstOrDefaultAsync(m => m.FeatureID == id);
            if (vehicleFeature == null)
            {
                return NotFound();
            }

            return View(vehicleFeature);
        }

        // POST: VehicleFeature/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleFeature = await _context.VehicleFeatures.FindAsync(id);
            _context.VehicleFeatures.Remove(vehicleFeature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleFeatureExists(int id)
        {
            return _context.VehicleFeatures.Any(e => e.FeatureID == id);
        }
    }
}
