using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inventory.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly InventoryContext _context;

        public CategoriesController(InventoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_context.Categories.OrderBy(
                c => c.Name));
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
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                NotFound();
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var category = _context.Categories.Where(m => m.CategoryId == id)
                .Include("Products.Category").First();
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(long id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
