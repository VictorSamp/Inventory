using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Edit(long id)
        {
            return View(_context.Categories.Where(
                m => m.CategoryId == id).First());
        }

        [HttpGet]
        public IActionResult Details(long id)
        {
            return View(_context.Categories.Where(
                c => c.CategoryId == id).First());
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            return View(_context.Categories.Where(
                c => c.CategoryId == id).First());
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
            _context.Categories.Remove(_context.Categories.Where(
                c => c.CategoryId == category.CategoryId).First());
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            _context.Categories.Remove(_context.Categories.Where(
                c => c.CategoryId == category.CategoryId).First());
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
