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
using X.PagedList;

namespace KitchenEquipment.Controllers
{
    public class SinkController : Controller
    {
        private ISinkService _sinkService;
        private ICompanyService _companyService;
        private int pageSize = 8;

        public SinkController(ISinkService sinkService, ICompanyService companyService)
        {
            _sinkService = sinkService;
            _companyService = companyService;
        }

        public IActionResult Index(string type, int companyId, int? page)
        {
            string material = string.Empty;
            string sinkType = string.Empty;
            if (type != null)
            {
                var sink = type.Split("-");
                material = sink[0];
                sinkType = sink[1];
            }

            int pageNumber = (page ?? 1);

            ViewBag.Companies = GetListOfCompanies(GetAllCompanies);

            var sinks = GetSinksWithCompanyName(GetAllCompanies, material);

            if (sinkType != "All")
            {
                var sinkVM = sinks.Where(x => x.Type.ToString().Equals(sinkType, StringComparison.OrdinalIgnoreCase));
                if (companyId != 0)
                {
                    var sinkVMPaged = sinkVM.Where(x => x.CompanyId == companyId);
                    return PartialView("Index", sinkVMPaged.ToPagedList(pageNumber, pageSize));
                }
                return PartialView("Index", sinkVM.ToPagedList(pageNumber, pageSize));
            }

            if (companyId != 0)
            {
                var sinkVM = sinks.Where(x => x.CompanyId == companyId);
                return PartialView("Index", sinkVM.ToPagedList(pageNumber, pageSize));
            }

            return PartialView("Index", sinks.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public IActionResult Create(string url)
        {
            var companies = Mapper.Map<IEnumerable<CompanyViewModel>>(_companyService.GetAll());
            SelectList list = new SelectList(companies, "Id", "CompanyName");
            ViewBag.Companies = list;
            ViewBag.Url = url;
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SinkViewModel sink, IFormFile uploadImage)
        {
            if (ModelState.IsValid)
            {
                using (var reader = new MemoryStream())
                {
                    uploadImage.CopyTo(reader);
                    sink.Image = reader.GetBuffer();
                }
                await _sinkService.Create(Mapper.Map<SinkDto>(sink));
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Edit(int id, string url)
        {
            var companies = Mapper.Map<IEnumerable<CompanyViewModel>>(_companyService.GetAll());
            SelectList list = new SelectList(companies, "Id", "CompanyName");
            ViewBag.Companies = list;
            var sink = _sinkService.Get(x => x.Id == id);
            if (sink != null)
            {
                ViewBag.Url = url;
                return PartialView("_Edit", Mapper.Map<SinkDto, SinkViewModel>(_sinkService.Get(x => x.Id == id)));
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SinkViewModel sink, IFormFile uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    using (var reader = new MemoryStream())
                    {
                        uploadImage.CopyTo(reader);
                        sink.Image = reader.GetBuffer();
                    }
                }

                await _sinkService.UpdateAsync(Mapper.Map<SinkDto>(sink));
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Delete(int id, string url)
        {
            var sink = _sinkService.Get(x => x.Id == id);
            if (sink != null)
            {
                ViewBag.Url = url;
                return PartialView("_Delete", Mapper.Map<SinkDto, SinkViewModel>(_sinkService.Get(x => x.Id == id)));
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var sink = _sinkService.Get(x => x.Id == id);

            if (sink != null)
            {
                await _sinkService.DeleteAsync(id);
            }

            return RedirectToAction("Index");
        }

        private SelectList GetListOfCompanies(IEnumerable<CompanyViewModel> companies)
        {
            return new SelectList(companies, "Id", "CompanyName");
        }

        private IEnumerable<CompanyViewModel> GetAllCompanies => Mapper.Map<IEnumerable<CompanyViewModel>>(_companyService.GetAll());
        private IEnumerable<SinkViewModel> GetAllSinks => Mapper.Map<IEnumerable<SinkViewModel>>(_sinkService.GetAll());

        private IEnumerable<SinkViewModel> GetSinksWithCompanyName(IEnumerable<CompanyViewModel> companies, string material)
        {
            var sinks = GetAllSinks.Where(x => x.Material.ToString().Equals(material, StringComparison.OrdinalIgnoreCase));
            foreach (var key in sinks)
            {
                key.CompanyName = companies.First(i => i.Id == key.CompanyId).CompanyName;
                key.CompanyCountry = companies.First(i => i.Id == key.CompanyId).Country;
            }

            return sinks;
        }
    }
}