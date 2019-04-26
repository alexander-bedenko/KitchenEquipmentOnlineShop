using System;
using System.Collections.Generic;
using System.Linq;
using KitchenEquipment.Enums;
using KitchenEquipment.Extension;
using KitchenEquipment.Models;
using Microsoft.AspNetCore.Mvc;

namespace KitchenEquipment.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var menu = new AdminMenuViewModel
            {
                ExhaustType = GetDisplayNames(typeof(ExhaustHoodType)),
                SinkType = Enum.GetNames(typeof(SinkType)).ToList(),
                SinkForm = Enum.GetNames(typeof(SinkForm)).ToList(),
                SinkMaterial = Enum.GetNames(typeof(SinkMaterial)).ToList()
            };

            return View(menu);
        }

        private List<string> GetDisplayNames(Type enu)
        {
            var list = new List<string>();
            foreach (var key in Enum.GetValues(enu))
            {
                list.Add(((Enum)key).GetDisplayName());
            }

            return list;
        }
    }
}