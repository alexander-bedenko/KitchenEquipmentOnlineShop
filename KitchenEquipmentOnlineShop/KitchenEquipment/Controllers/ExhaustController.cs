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
using X.PagedList;

namespace KitchenEquipment.Controllers
{
    public class ExhaustController : Controller
    {
        private IExhaustHoodService _exhaustHoodService;
        private ICompanyService _companyService;
        private int pageSize = 8;

        public ExhaustController(IExhaustHoodService exhaustHoodService, ICompanyService companyService)
        {
            _exhaustHoodService = exhaustHoodService;
            _companyService = companyService;
        }

        public IActionResult Index(string exhaustType, int companyId, int? page)
        {
            int pageNumber = (page ?? 1);

            ViewBag.Companies = GetListOfCompanies(GetAllCompanies);

            var exhausts = GetExhaustsWithCompanyName(GetAllCompanies);

            if (exhaustType != "All")
            {
                var exhaustVM = exhausts.Where(x => x.Type.ToString().Equals(exhaustType));
                if (companyId != 0)
                {
                    var exhaustsVMPaged = exhaustVM.Where(x => x.CompanyId == companyId);
                    return PartialView("Index", exhaustsVMPaged.ToPagedList(pageNumber, pageSize));
                }
                return PartialView("Index", exhaustVM.ToPagedList(pageNumber, pageSize));
            }

            if (companyId != 0)
            {
                var exhaustVM = exhausts.Where(x => x.CompanyId == companyId);
                return PartialView("Index", exhaustVM.ToPagedList(pageNumber, pageSize));
            }

            return PartialView("Index", exhausts.ToPagedList(pageNumber, pageSize));
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
        public IActionResult Edit(int id)
        {
            var companies = Mapper.Map<IEnumerable<CompanyViewModel>>(_companyService.GetAll());
            SelectList list = new SelectList(companies, "Id", "CompanyName");
            ViewBag.Companies = list;
            var exhaust = _exhaustHoodService.Get(x => x.Id == id);
            if (exhaust != null)
            {
                return PartialView("_Edit", Mapper.Map<ExhaustHoodDto, ExhaustHoodViewModel>(_exhaustHoodService.Get(x => x.Id == id)));
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ExhaustHoodViewModel exhaust, IFormFile uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    using (var reader = new MemoryStream())
                    {
                        uploadImage.CopyTo(reader);
                        exhaust.Image = reader.GetBuffer();
                    }
                }

                await _exhaustHoodService.UpdateAsync(Mapper.Map<ExhaustHoodDto>(exhaust));
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

        private SelectList GetListOfCompanies(IEnumerable<CompanyViewModel> companies)
        {
            return new SelectList(companies, "Id", "CompanyName");
        }

        private IEnumerable<CompanyViewModel> GetAllCompanies => Mapper.Map<IEnumerable<CompanyViewModel>>(_companyService.GetAll());
        private IEnumerable<ExhaustHoodViewModel> GetAllExhausts => Mapper.Map<IEnumerable<ExhaustHoodViewModel>>(_exhaustHoodService.GetAll());

        private IEnumerable<ExhaustHoodViewModel> GetExhaustsWithCompanyName(IEnumerable<CompanyViewModel> companies)
        {
            var exhausts = GetAllExhausts;
            foreach (var key in exhausts)
            {
                key.CompanyName = companies.First(i => i.Id == key.CompanyId).CompanyName;
                key.CompanyCountry = companies.First(i => i.Id == key.CompanyId).Country;
            }

            return exhausts;
        }

        private IActionResult GetExhaustsByType(IEnumerable<ExhaustHoodViewModel> exhausts, string exhaustType, int pageNumber)
        {
            var exhaustVM = exhausts.Where(x => x.Type.ToString().Equals(exhaustType));
            return PartialView("Index", exhaustVM.ToPagedList(pageNumber, pageSize));
        }

        private IActionResult GetExhaustsByCompanyId(IEnumerable<ExhaustHoodViewModel> exhausts, int? companyId, int pageNumber)
        {
            var exhaustVM = exhausts.Where(x => x.CompanyId == companyId);
            return PartialView("Index", exhaustVM.ToPagedList(pageNumber, pageSize));
        }
    }
}