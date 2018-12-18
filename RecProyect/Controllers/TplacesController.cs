using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}