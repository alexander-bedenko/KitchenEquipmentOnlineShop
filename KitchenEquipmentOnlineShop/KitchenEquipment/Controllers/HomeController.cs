using Microsoft.AspNetCore.Mvc;

namespace KitchenEquipment.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return NotFound("Что-то пошло не так.");
        }
    }
}