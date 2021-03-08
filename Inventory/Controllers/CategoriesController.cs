using Inventory.Data;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly InventoryContext _context;

        public CategoriesController(InventoryContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Categories);
        }
    }
}
