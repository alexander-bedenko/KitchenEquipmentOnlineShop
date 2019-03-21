using Microsoft.AspNetCore.Mvc;

namespace KitchenEquipment.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}