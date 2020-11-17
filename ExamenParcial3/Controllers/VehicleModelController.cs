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
    public class VehicleModelController : Controller
    {
        private readonly CarContext _context;

        public VehicleModelController(CarContext context)
        {
            _context = context;
        }

        // GET: VehicleModel
        public async Task<IActionResult> Index(string searchString)
        {
            var carContext = _context.VehicleModels.Include(a => a.VehicleManufacter); 
            var models = from c in carContext select c;
            if(!string.IsNullOrEmpty(searchString)) {
                models = models.Where(c=>c.ModelName.Contains(searchString) || c.VehicleManufacter.ManufacterName.Contains(searchString));
            }

            return View(await models.ToListAsync());
        }

        // GET: VehicleModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.VehicleModels
                .Include(c => c.VehicleManufacter)
                .FirstOrDefaultAsync(m => m.ModelID == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // GET: VehicleModel/Create
        public IActionResult Create()
        {
            PopulateFieldsDropDownList();
            return View();
        }

        // POST: VehicleModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModelID,ModelName,ManufacterID")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ManufacterID"] = new SelectList(_context.VehicleManufacters, "ManufacterID", "ManufacterID", vehicleModel.ManufacterID);
            PopulateFieldsDropDownList();
            return View(vehicleModel);
        }

        // GET: VehicleModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
        
            var vehicleModel = await _context.VehicleModels.FindAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }
            //ViewData["ManufacterID"] = new SelectList(_context.VehicleManufacters, "ManufacterID", "ManufacterID", vehicleModel.ManufacterID);
            PopulateFieldsDropDownList(id);
            return View(vehicleModel);
        }

        // POST: VehicleModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ModelID,ModelName,ManufacterID")] VehicleModel vehicleModel)
        {
            if (id != vehicleModel.ModelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleModelExists(vehicleModel.ModelID))
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
            //ViewData["ManufacterID"] = new SelectList(_context.VehicleManufacters, "ManufacterID", "ManufacterID", vehicleModel.ManufacterID);
            PopulateFieldsDropDownList(id);
            return View(vehicleModel);
        }

        private void PopulateFieldsDropDownList(object selectedField=null){
            var fieldquery = from f in _context.VehicleManufacters 
                orderby f.ManufacterName
                select f;
            ViewBag.ManufacterID = new SelectList(fieldquery.AsNoTracking(),"ManufacterID","ManufacterName",selectedField);
        }

        // GET: VehicleModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.VehicleModels
                .Include(c => c.VehicleManufacter)
                .FirstOrDefaultAsync(m => m.ModelID == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // POST: VehicleModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleModel = await _context.VehicleModels.FindAsync(id);
            _context.VehicleModels.Remove(vehicleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleModelExists(int id)
        {
            return _context.VehicleModels.Any(e => e.ModelID == id);
        }
    }
}
