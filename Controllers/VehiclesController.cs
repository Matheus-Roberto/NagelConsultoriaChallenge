#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NagelConsultoriaChallenge.Data;
using NagelConsultoriaChallenge.Models;

namespace NagelConsultoriaChallenge.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["PlateSortParm"] = sortOrder == "plate" ? "plate_desc": "plate";
            ViewData["BrandSortParm"] = sortOrder == "brand" ? "brand_desc" : "brand";
            ViewData["ColorSortParm"] = sortOrder == "color" ? "color_desc" : "color";
            ViewData["FactoryYearSortParm"] = sortOrder == "year" ? "year_desc" : "year";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["ActiveSortParm"] = sortOrder == "Active" ? "active_desc" : "Active";
            var vehicles = from v in _context.Vehicles
                           select v;

            switch (sortOrder)
            {
                case "plate":
                    vehicles = vehicles.OrderBy(s => s.Plate);
                    break;
                case "plate_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Plate);
                    break;
                case "brand":
                    vehicles = vehicles.OrderBy(s => s.Brand);
                    break;
                case "brand_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Brand);
                    break;
                case "color":
                    vehicles = vehicles.OrderBy(s => s.Color);
                    break;
                case "color_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Color);
                    break;
                case "year":
                    vehicles = vehicles.OrderBy(s => s.FactoryYear);
                    break;
                case "year_desc":
                    vehicles = vehicles.OrderByDescending(s => s.FactoryYear);
                    break;
                case "Date":
                    vehicles = vehicles.OrderBy(s => s.RegistrationData);
                    break;
                case "date_desc":
                    vehicles = vehicles.OrderByDescending(s => s.RegistrationData);
                    break;
                case "Active":
                    vehicles = vehicles.OrderBy(s => s.Active);
                    break;
                case "active_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Active);
                    break;
                default:
                    vehicles = vehicles.OrderBy(s => s.Id);
                    break;
            }

            return View(await vehicles.AsNoTracking().ToListAsync());
        }

        // GET: Vehicles by Plate
        public async Task<IActionResult> IndexPlate()
        {
            return View(await _context.Vehicles.ToListAsync());
        }

        // GET: Vehicles by Brand
        public async Task<IActionResult> IndexBrand()
        {
            return View(await _context.Vehicles.ToListAsync());
        }

        // GET: Vehicles by Color
        public async Task<IActionResult> IndexColor()
        {
            return View(await _context.Vehicles.ToListAsync());
        }

        // GET: Vehicles by FactoryYear
        public async Task<IActionResult> IndexFactoryYear()
        {
            return View(await _context.Vehicles.ToListAsync());
        }

        // GET: Vehicles by RegistrationData
        public async Task<IActionResult> IndexRegistrationData()
        {
            return View(await _context.Vehicles.ToListAsync());
        }

        // GET: Vehicles by Active
        public async Task<IActionResult> IndexActive()
        {
            return View(await _context.Vehicles.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Plate,Brand,Color,FactoryYear,RegistrationData,Active")] Vehicles vehicles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicles);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles.FindAsync(id);
            if (vehicles == null)
            {
                return NotFound();
            }
            return View(vehicles);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Plate,Brand,Color,FactoryYear,RegistrationData,Active")] Vehicles vehicles)
        {
            if (id != vehicles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehiclesExists(vehicles.Id))
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
            return View(vehicles);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicles = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicles == null)
            {
                return NotFound();
            }

            return View(vehicles);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicles = await _context.Vehicles.FindAsync(id);
            _context.Vehicles.Remove(vehicles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehiclesExists(int id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
