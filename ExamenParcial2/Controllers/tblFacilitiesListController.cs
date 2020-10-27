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
    public class tblFacilitiesListController : Controller
    {
        private readonly HotelContext _context;

        public tblFacilitiesListController(HotelContext context)
        {
            _context = context;
        }

        // GET: tblFacilitiesList
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBLFacilitiesList.ToListAsync());
        }

        // GET: tblFacilitiesList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblFacilitiesList = await _context.TBLFacilitiesList
                .FirstOrDefaultAsync(m => m.IngFacilityID == id);
            if (tblFacilitiesList == null)
            {
                return NotFound();
            }

            return View(tblFacilitiesList);
        }

        // GET: tblFacilitiesList/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblFacilitiesList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngFacilityID,strFacilityDesc")] tblFacilitiesList tblFacilitiesList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblFacilitiesList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblFacilitiesList);
        }

        // GET: tblFacilitiesList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblFacilitiesList = await _context.TBLFacilitiesList.FindAsync(id);
            if (tblFacilitiesList == null)
            {
                return NotFound();
            }
            return View(tblFacilitiesList);
        }

        // POST: tblFacilitiesList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngFacilityID,strFacilityDesc")] tblFacilitiesList tblFacilitiesList)
        {
            if (id != tblFacilitiesList.IngFacilityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblFacilitiesList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblFacilitiesListExists(tblFacilitiesList.IngFacilityID))
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
            return View(tblFacilitiesList);
        }

        // GET: tblFacilitiesList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblFacilitiesList = await _context.TBLFacilitiesList
                .FirstOrDefaultAsync(m => m.IngFacilityID == id);
            if (tblFacilitiesList == null)
            {
                return NotFound();
            }

            return View(tblFacilitiesList);
        }

        // POST: tblFacilitiesList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblFacilitiesList = await _context.TBLFacilitiesList.FindAsync(id);
            _context.TBLFacilitiesList.Remove(tblFacilitiesList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblFacilitiesListExists(int id)
        {
            return _context.TBLFacilitiesList.Any(e => e.IngFacilityID == id);
        }
    }
}
