using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inventory.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly InventoryContext _context;

        public ManufacturersController(InventoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Manufacturers.OrderBy(
                m => m.Name));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var manufacturer = _context.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                NotFound();
            }
            return View(manufacturer);
        }

        [HttpGet]
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var manufacturer = _context.Manufacturers.Where(m => m.ManufacturerId == id)
                .Include("Products.Category").First();
            if (manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }

        [HttpGet]
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var manufacturer = _context.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return View(manufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Manufacturer manufacturer)
        {
            _context.Manufacturers.Add(manufacturer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(manufacturer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(manufacturer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(long id)
        {
            var manufacturer = _context.Manufacturers.Find(id);
            _context.Manufacturers.Remove(manufacturer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
