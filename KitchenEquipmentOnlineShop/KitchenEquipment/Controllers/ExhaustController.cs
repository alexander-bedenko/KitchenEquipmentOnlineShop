using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KitchenEquipment.Models;
using KitchenEquipmentOnlineShop.BusinessLogic.Dtos;
using KitchenEquipmentOnlineShop.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KitchenEquipment.Controllers
{
    public class ExhaustController : Controller
    {
        private IExhaustHoodService _exhaustHoodService;
        private ICompanyService _companyService;

        public ExhaustController(IExhaustHoodService exhaustHoodService, ICompanyService companyService)
        {
            _exhaustHoodService = exhaustHoodService;
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            var companies = Mapper.Map<IEnumerable<CompanyViewModel>>(_companyService.GetAll());
            SelectList list = new SelectList(companies, "Id", "CompanyName");
            ViewBag.Companies = list;
            var exhausts = Mapper.Map<IEnumerable<ExhaustHoodViewModel>>(_exhaustHoodService.GetAll());
            foreach (var key in exhausts)
            {
                key.CompanyName = companies.First(i => i.Id == key.CompanyId).CompanyName;
            }
            return PartialView("Index", exhausts);
        }

        [Authorize]
        public IActionResult Create()
        {
            var companies = Mapper.Map<IEnumerable<CompanyViewModel>>(_companyService.GetAll());
            SelectList list = new SelectList(companies, "Id", "CompanyName");
            ViewBag.Companies = list;
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExhaustHoodViewModel exhaust, IFormFile uploadImage)
        {
            if (ModelState.IsValid)
            {
                using (var reader = new MemoryStream())
                {
                    uploadImage.CopyTo(reader);
                    exhaust.Image = reader.GetBuffer();
                }
                await _exhaustHoodService.Create(Mapper.Map<ExhaustHoodDto>(exhaust));
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var exhaust = _exhaustHoodService.Get(x => x.Id == id);
            if (exhaust != null)
            {
                return PartialView("_Delete", Mapper.Map<ExhaustHoodDto, ExhaustHoodViewModel>(_exhaustHoodService.Get(x => x.Id == id)));
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var exhaust = _exhaustHoodService.Get(x => x.Id == id);

            if (exhaust != null)
            {
                await _exhaustHoodService.DeleteAsync(id);
            }

            return RedirectToAction("Index");
        }
    }
}