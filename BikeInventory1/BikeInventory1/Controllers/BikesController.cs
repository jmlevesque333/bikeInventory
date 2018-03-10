using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeInventory1.Models;

namespace BikeInventory1.Controllers
{
    public class BikesController : Controller
    {
        private readonly BikeInventory1Context _context;

        public BikesController(BikeInventory1Context context)
        {
            _context = context;
        }

        // GET: Bikes
        public async Task<IActionResult> Index(string bikeType, string searchString, string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["RatingSortParm"] = sortOrder == "Rating" ? "rating_desc" : "Rating";
            ViewData["QuantitySortParm"] = sortOrder == "Quantity" ? "quantity_desc" : "Quantity";
            ViewData["TypeSortParm"] = sortOrder == "Type" ? "type_desc" : "Type";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["CurrentFilter"] = searchString;

            IQueryable<string> bikeQuery = from b in _context.Bike
                                            orderby b.BikeType
                                            select b.BikeType;

            var bikes = from b in _context.Bike
                        select b;

            switch (sortOrder)
            {
                case "name_desc":
                    bikes = bikes.OrderByDescending(s => s.Name);
                    break;
                case "Rating":
                    bikes = bikes.OrderBy(s => s.Rating);
                    break;
                case "rating_desc":
                    bikes = bikes.OrderByDescending(s => s.Rating);
                    break;
                case "Quantity":
                    bikes = bikes.OrderBy(s => s.Qty);
                    break;
                case "quantity_desc":
                    bikes = bikes.OrderByDescending(s => s.Qty);
                    break;
                case "Type":
                    bikes = bikes.OrderBy(s => s.BikeType);
                    break;
                case "type_desc":
                    bikes = bikes.OrderByDescending(s => s.BikeType);
                    break;
                case "Price":
                    bikes = bikes.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    bikes = bikes.OrderByDescending(s => s.Price);
                    break;
                default:
                    bikes = bikes.OrderBy(s => s.Name);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                bikes = bikes.Where(s => s.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(bikeType))
            {
                bikes = bikes.Where(x => x.BikeType == bikeType);
            }

            var bikeTypeVM = new BikeTypeViewModel();
            bikeTypeVM.types = new SelectList(await bikeQuery.Distinct().ToListAsync());
            bikeTypeVM.bikes = await bikes.ToListAsync();

            return View(bikeTypeVM);
        }

        // GET: Bikes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // GET: Bikes/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Bikes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Rating,Qty,BikeType,Price")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }

        // GET: Bikes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike.SingleOrDefaultAsync(m => m.ID == id);
            if (bike == null)
            {
                return NotFound();
            }
            return View(bike);
        }

        // POST: Bikes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Rating,Qty,BikeType,Price")] Bike bike)
        {
            if (id != bike.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikeExists(bike.ID))
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
            return View(bike);
        }

        // GET: Bikes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike
                .SingleOrDefaultAsync(m => m.ID == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // POST: Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bike = await _context.Bike.SingleOrDefaultAsync(m => m.ID == id);
            _context.Bike.Remove(bike);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BikeExists(int id)
        {
            return _context.Bike.Any(e => e.ID == id);
        }
    }
}
