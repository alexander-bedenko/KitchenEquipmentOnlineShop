using KitchenEquipmentOnlineShop.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KitchenEquipment.Controllers
{
    public class ExhaustController : Controller
    {
        private IExhaustHoodService _exhaustHoodService;

        public ExhaustController(IExhaustHoodService exhaustHoodService)
        {
            _exhaustHoodService = exhaustHoodService;
        }

        public IActionResult Index()
        {
            return PartialView("_Index");
        }
    }
}