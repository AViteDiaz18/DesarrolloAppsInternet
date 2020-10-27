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
    public class tblRoomController : Controller
    {
        private readonly HotelContext _context;

        public tblRoomController(HotelContext context)
        {
            _context = context;
        }

        // GET: tblRoom
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBLRooms.ToListAsync());
        }

        // GET: tblRoom/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRooms = await _context.TBLRooms
                .FirstOrDefaultAsync(m => m.IngRoomID == id);
            if (tblRooms == null)
            {
                return NotFound();
            }

            return View(tblRooms);
        }

        // GET: tblRoom/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblRoom/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngRoomID,IngRoomTypeID,IngRoomBandID,IngRoomPriceID,strFloor,memAdditionalNotes")] tblRooms tblRooms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblRooms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblRooms);
        }

        // GET: tblRoom/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRooms = await _context.TBLRooms.FindAsync(id);
            if (tblRooms == null)
            {
                return NotFound();
            }
            return View(tblRooms);
        }

        // POST: tblRoom/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IngRoomID,IngRoomTypeID,IngRoomBandID,IngRoomPriceID,strFloor,memAdditionalNotes")] tblRooms tblRooms)
        {
            if (id != tblRooms.IngRoomID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblRooms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblRoomsExists(tblRooms.IngRoomID))
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
            return View(tblRooms);
        }

        // GET: tblRoom/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRooms = await _context.TBLRooms
                .FirstOrDefaultAsync(m => m.IngRoomID == id);
            if (tblRooms == null)
            {
                return NotFound();
            }

            return View(tblRooms);
        }

        // POST: tblRoom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblRooms = await _context.TBLRooms.FindAsync(id);
            _context.TBLRooms.Remove(tblRooms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblRoomsExists(int id)
        {
            return _context.TBLRooms.Any(e => e.IngRoomID == id);
        }
    }
}
