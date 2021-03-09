using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
