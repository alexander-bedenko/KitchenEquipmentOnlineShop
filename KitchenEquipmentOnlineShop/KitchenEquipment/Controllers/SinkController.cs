using System.Collections.Generic;
using System.IO;
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
    public class SinkController : Controller
    {
        private ISinkService _sinkService;
        private ICompanyService _companyService;

        public SinkController(ISinkService sinkService, ICompanyService companyService)
        {
            _sinkService = sinkService;
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            return View();
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
        public IActionResult Edit(int id)
        {
            var companies = Mapper.Map<IEnumerable<CompanyViewModel>>(_companyService.GetAll());
            SelectList list = new SelectList(companies, "Id", "CompanyName");
            ViewBag.Companies = list;
            var sink = _sinkService.Get(x => x.Id == id);
            if (sink != null)
            {
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
        public IActionResult Delete(int id)
        {
            var sink = _sinkService.Get(x => x.Id == id);
            if (sink != null)
            {
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
    }
}