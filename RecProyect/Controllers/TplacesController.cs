using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecProyect.Data;
using RecProyect.Models;

namespace RecProyect.Controllers
{
    public class TplacesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TplacesController(ApplicationDbContext db)
        {
            _db = db;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(_db.Places.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
        //Get : Place/Create
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Place place)
        {
            if (ModelState.IsValid)
            {
                _db.Add(place);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(place);
        }

        //POST: Place/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePlace(int id)
        {
            var place = await _db.Places.SingleOrDefaultAsync(m => m.Id == id);
            _db.Places.Remove(place);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //Delete : Place/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var place = await _db.Places.SingleOrDefaultAsync( m => m.Id == id);
            if (place == null)
            {
                return NotFound();
            }
            return View(place);
        }

        //POST: Place/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Place place)
        {
            if (id != place.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(place);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(place);
        }
        //Edit : Place/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var place = await _db.Places.SingleOrDefaultAsync(m => m.Id == id);
            if (place == null)
            {
                return NotFound();
            }
            return View(place);
        }
    }
}