using AutoMapper;
using KitchenEquipment.Models;
using KitchenEquipmentOnlineShop.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace KitchenEquipment.Controllers
{
    public class HomeController : Controller
    {
        private IExhaustHoodService _exhaustHoodService;
        private ICompanyService _companyService;

        public HomeController(IExhaustHoodService exhaustHoodService, ICompanyService companyService)
        {
            _exhaustHoodService = exhaustHoodService;
            _companyService = companyService;
        }

        public IActionResult Index(int? page)
        {
            //GetExhausts(page);

            return View();
        }

        public IActionResult Error()
        {
            return NotFound("Что-то пошло не так.");
        }

        public IActionResult Exhausts(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            var companies = Mapper.Map<IEnumerable<CompanyViewModel>>(_companyService.GetAll());
            SelectList list = new SelectList(companies, "Id", "CompanyName");
            ViewBag.Companies = list;
            var exhausts = Mapper.Map<IEnumerable<ExhaustHoodViewModel>>(_exhaustHoodService.GetAll());

            foreach (var key in exhausts)
            {
                key.CompanyName = companies.First(i => i.Id == key.CompanyId).CompanyName;
            }

            return PartialView("_Exhausts", exhausts.ToPagedList(pageNumber, pageSize));
        }

        //private IPagedList<ExhaustHoodViewModel> GetExhausts(int? page)
        //{
        //    int pageSize = 3;
        //    int pageNumber = (page ?? 1);

        //    var companies = Mapper.Map<IEnumerable<CompanyViewModel>>(_companyService.GetAll());
        //    SelectList list = new SelectList(companies, "Id", "CompanyName");
        //    ViewBag.Companies = list;
        //    var exhausts = Mapper.Map<IEnumerable<ExhaustHoodViewModel>>(_exhaustHoodService.GetAll());

        //    foreach (var key in exhausts)
        //    {
        //        key.CompanyName = companies.First(i => i.Id == key.CompanyId).CompanyName;
        //    }

        //    return exhausts.ToPagedList(pageNumber, pageSize);
        //}
    }
}