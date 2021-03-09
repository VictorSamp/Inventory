using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Edit(long id)
        {
            return View(_context.Manufacturers.Where(
                m => m.ManufacturerId == id).First());
        }

        [HttpGet]
        public IActionResult Details(long id)
        {
            return View(_context.Manufacturers.Where(
                m => m.ManufacturerId == id).First());
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            return View(_context.Manufacturers.Where(
                m => m.ManufacturerId == id).First());
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
            _context.Manufacturers.Remove(_context.Manufacturers.Where(
               c => c.ManufacturerId == manufacturer.ManufacturerId).First());
            _context.Manufacturers.Add(manufacturer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Manufacturer manufacturer)
        {
            _context.Manufacturers.Remove(_context.Manufacturers.Where(
                c => c.ManufacturerId == manufacturer.ManufacturerId).First());
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
