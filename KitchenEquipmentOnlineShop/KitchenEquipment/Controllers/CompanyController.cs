using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using KitchenEquipment.Models;
using KitchenEquipmentOnlineShop.BusinessLogic.Dtos;
using KitchenEquipmentOnlineShop.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace KitchenEquipment.Controllers
{
    public class CompanyController : Controller
    {
        private ICompanyService _companyService;
        private int pageSize = 8;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            var companies = Mapper.Map<IEnumerable<CompanyViewModel>>(_companyService.GetAll());
            return PartialView("Index", companies.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public IActionResult Create(string url)
        {
            ViewBag.Url = url;
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                await _companyService.Create(Mapper.Map<CompanyDto>(company));
            }

            return RedirectToAction("Index");
        }
    }
}