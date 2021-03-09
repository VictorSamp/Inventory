using Inventory.Data;
using Inventory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Inventory.Controllers
{
    public class ProductsController : Controller
    {
        private readonly InventoryContext _context;

        public ProductsController(InventoryContext context)
        {
            _context = context;
        }

        // GET: Index
        public ActionResult Index()
        {
            var products = _context.Products.Include(c => c.Category)
                .Include(m => m.Manufacturer).OrderBy(p => p.Name);
            return View(products);
        }

        // GET: Details
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var product = _context.Products.Where(p => p.ProductId == id)
                .Include(c => c.Category)
                .Include(m => m.Manufacturer)
                .First();
            if (product == null)
            {
                NotFound();
            }
            return View(product);
        }

        // GET: Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories.OrderBy(c => c.Name), "CategoryId", "Name");
            ViewBag.ManufacturerId = new SelectList(_context.Manufacturers.OrderBy(m => m.Name), "ManufacturerId", "Name");
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.CategoryId = new SelectList(_context.Categories.OrderBy(c => c.Name), "CategoryId", "Name", product.CategoryId);
            ViewBag.ManufacturerId = new SelectList(_context.Manufacturers.OrderBy(m => m.Name), "ManufacturerId", "Name", product.ManufacturerId);
            return View(product);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Delete
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var product = _context.Products.Where(p => p.ProductId == id)
                .Include(c => c.Category)
                .Include(m => m.Manufacturer)
                .First();
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
