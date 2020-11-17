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
    public class LinkFeatureToVehicleController : Controller
    {
        private readonly CarContext _context;

        public LinkFeatureToVehicleController(CarContext context)
        {
            _context = context;
        }

        // GET: LinkFeatureToVehicle
        public async Task<IActionResult> Index(string searchString)
        {
            var _cars = _context.LinkFeatureToVehicles
            .Include(c => c.VehicleDetail)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehicleManufacter)
            .AsNoTracking();
            var _features = _cars.Include(l => l.VehicleFeature);
            var _search = from c in _features select c;
            if(!string.IsNullOrEmpty(searchString)) {
                _search = _search.Where(c=>c.VehicleDetail.VehicleModel.ModelName.Contains(searchString) || c.VehicleDetail.VehicleModel.VehicleManufacter.ManufacterName.Contains(searchString));
            }
            return View(await _search.ToListAsync());
        }

        // GET: LinkFeatureToVehicle/Details/5
        public async Task<IActionResult> Details(string id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }
            var _cars = _context.LinkFeatureToVehicles
            .Include(c => c.VehicleDetail)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehicleManufacter)
            .AsNoTracking();
            var linkFeatureToVehicle = await _cars
                .Include(d => d.VehicleDetail)
                .Include(f => f.VehicleFeature)
                .FirstOrDefaultAsync(m => m.CarRegistration == id && m.FeatureID == id2);
            if (linkFeatureToVehicle == null)
            {
                return NotFound();
            }

            return View(linkFeatureToVehicle);
        }

        // GET: LinkFeatureToVehicle/Create
        public IActionResult Create()
        {
            PopulateFieldsDropDownList();
            PopulateFieldsDropDownList2();
            return View();
        }

        // POST: LinkFeatureToVehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarRegistration,FeatureID")] LinkFeatureToVehicle linkFeatureToVehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linkFeatureToVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateFieldsDropDownList();
            PopulateFieldsDropDownList2();
            return View(linkFeatureToVehicle);
        }

        // GET: LinkFeatureToVehicle/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var linkFeatureToVehicle = await _context.LinkFeatureToVehicles.FindAsync(id);
            if (linkFeatureToVehicle == null)
            {
                return NotFound();
            }
            PopulateFieldsDropDownList();
            PopulateFieldsDropDownList2();
            return View(linkFeatureToVehicle);
        }

        // POST: LinkFeatureToVehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CarRegistration,FeatureID")] LinkFeatureToVehicle linkFeatureToVehicle)
        {
            if (id != linkFeatureToVehicle.CarRegistration)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linkFeatureToVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinkFeatureToVehicleExists(linkFeatureToVehicle.CarRegistration))
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
            return View(linkFeatureToVehicle);
        }

        private void PopulateFieldsDropDownList(object selectedField=null){
            var fieldquery = from f in _context.VehicleDetails 
                orderby f.CarRegistration
                select f;
            ViewBag.CarRegistration = new SelectList(fieldquery.AsNoTracking(),"CarRegistration","CarRegistration",selectedField);
        }
        private void PopulateFieldsDropDownList2(object selectedField=null){
            var fieldquery = from f in _context.VehicleFeatures 
                orderby f.FeatureDescription
                select f;
            ViewBag.FeatureID = new SelectList(fieldquery.AsNoTracking(),"FeatureID","FeatureDescription",selectedField);
        }

        // GET: LinkFeatureToVehicle/Delete/5
        public async Task<IActionResult> Delete(string id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }
            var _cars = _context.LinkFeatureToVehicles
            .Include(c => c.VehicleDetail)
                .ThenInclude(c => c.VehicleModel)
                .ThenInclude(c => c.VehicleManufacter)
            .AsNoTracking();
            var linkFeatureToVehicle = await _cars
                .Include(d => d.VehicleDetail)
                .Include(f => f.VehicleFeature)
                .FirstOrDefaultAsync(m => m.CarRegistration == id && m.FeatureID == id2);
            if (linkFeatureToVehicle == null)
            {
                return NotFound();
            }

            return View(linkFeatureToVehicle);
        }

        // POST: LinkFeatureToVehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var linkFeatureToVehicle = await _context.LinkFeatureToVehicles.FindAsync(id);
            _context.LinkFeatureToVehicles.Remove(linkFeatureToVehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinkFeatureToVehicleExists(string id)
        {
            return _context.LinkFeatureToVehicles.Any(e => e.CarRegistration == id);
        }
    }
}
