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
    public class VehicleDetailController : Controller
    {
        private readonly CarContext _context;

        public VehicleDetailController(CarContext context)
        {
            _context = context;
        }

        // GET: VehicleDetail
        public async Task<IActionResult> Index(string searchString)
        {
            var _car = _context.VehicleDetails
            .Include(a => a.VehicleModel)
                .ThenInclude(a => a.VehicleManufacter)
            .AsNoTracking();
            var carContext = _car.Include(b => b.VehicleColour)
            .Include(c=>c.VehicleFuelType);
            var details = from c in carContext select c;
            if(!string.IsNullOrEmpty(searchString)) {
                details = details.Where(c=>c.VehicleModel.ModelName.Contains(searchString) || c.VehicleModel.VehicleManufacter.ManufacterName.Contains(searchString));
            }

            return View(await details.ToListAsync());
        }

        // GET: VehicleDetail/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var _car = _context.VehicleDetails
            .Include(a => a.VehicleModel)
                .ThenInclude(a => a.VehicleManufacter)
            .AsNoTracking();
            var vehicleDetail = await _car
                .Include(a => a.VehicleModel)
                .Include(b => b.VehicleColour)
                .Include(c=>c.VehicleFuelType)
                .FirstOrDefaultAsync(m => m.CarRegistration == id);
            if (vehicleDetail == null)
            {
                return NotFound();
            }

            return View(vehicleDetail);
        }

        // GET: VehicleDetail/Create
        public IActionResult Create()
        {
            PopulateFieldsDropDownList();
            PopulateFieldsDropDownList2();
            PopulateFieldsDropDownList3();
            return View();
        }

        // POST: VehicleDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarRegistration,ModelID,ManufactureYear,ColourID,FuelTypeID,CurrentMilage,VehiclePrice")] VehicleDetail vehicleDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateFieldsDropDownList();
            PopulateFieldsDropDownList2();
            PopulateFieldsDropDownList3();
            return View(vehicleDetail);
        }

        // GET: VehicleDetail/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleDetail = await _context.VehicleDetails.FindAsync(id);
            if (vehicleDetail == null)
            {
                return NotFound();
            }
            PopulateFieldsDropDownList();
            PopulateFieldsDropDownList2();
            PopulateFieldsDropDownList3();
            return View(vehicleDetail);
        }

        // POST: VehicleDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CarRegistration,ModelID,ManufactureYear,ColourID,FuelTypeID,CurrentMilage,VehiclePrice")] VehicleDetail vehicleDetail)
        {
            if (id != vehicleDetail.CarRegistration)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleDetailExists(vehicleDetail.CarRegistration))
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
            PopulateFieldsDropDownList();
            PopulateFieldsDropDownList2();
            PopulateFieldsDropDownList3();
            return View(vehicleDetail);
        }
        private void PopulateFieldsDropDownList(object selectedField=null){
            var fieldquery = from f in _context.VehicleModels 
                orderby f.ModelName
                select f;
            ViewBag.ModelID = new SelectList(fieldquery.AsNoTracking(),"ModelID","ModelName",selectedField);
        }
        private void PopulateFieldsDropDownList2(object selectedField=null){
            var fieldquery = from f in _context.VehicleColours 
                orderby f.ColourName
                select f;
            ViewBag.ColourID = new SelectList(fieldquery.AsNoTracking(),"ColourID","ColourName",selectedField);
        }
        private void PopulateFieldsDropDownList3(object selectedField=null){
            var fieldquery = from f in _context.VehicleFuelTypes 
                orderby f.FuelTypeName
                select f;
            ViewBag.FuelTypeID = new SelectList(fieldquery.AsNoTracking(),"FuelTypeID","FuelTypeName",selectedField);
        }

        // GET: VehicleDetail/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var _car = _context.VehicleDetails
            .Include(a => a.VehicleModel)
                .ThenInclude(a => a.VehicleManufacter)
            .AsNoTracking();
            var vehicleDetail = await _car
                .Include(a => a.VehicleModel)
                .Include(b => b.VehicleColour)
                .Include(c=>c.VehicleFuelType)
                .FirstOrDefaultAsync(m => m.CarRegistration == id);
            if (vehicleDetail == null)
            {
                return NotFound();
            }

            return View(vehicleDetail);
        }

        // POST: VehicleDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var vehicleDetail = await _context.VehicleDetails.FindAsync(id);
            _context.VehicleDetails.Remove(vehicleDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleDetailExists(string id)
        {
            return _context.VehicleDetails.Any(e => e.CarRegistration == id);
        }
    }
}
