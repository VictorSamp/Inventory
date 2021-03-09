using Inventory.Data;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly InventoryContext _context;

        public IActionResult Index()
        {
            return View();
        }
    }
}
