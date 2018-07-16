using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FashionBoutik.DomainServices;
using FashionBoutik.Models;
using FashionBoutik.Web.Areas.Admin.Controllers;
using FashionBoutik.Core.Mappers;

namespace FashionBoutik.Controllers
{
    [Area("Admin")]
    public class BrandController : BaseController
    {
        private readonly IBrandManager _brandManager;
        private readonly IProductManager _productManager;

        public BrandController(IBrandManager brandManager,
            IProductManager productManager)
        {
            _brandManager = brandManager;
            _productManager = productManager;
        }

        #region UI View actions

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var viewModel = await _brandManager.GetAllBrands();

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Add()
        {
            //Prepare a new brand
            var model = new BrandModel();
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BrandModel model)
        {
            if (ModelState.IsValid)
            {
                var isSaved = await _brandManager.SaveBrand(model);
                if (isSaved)
                {
                    return RedirectToAction("List");
                }
            }
            return View(model); //TODO: view with validation errors
        }

        //get /Admin/brand/edit/5  
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("id");
            }

            var viewModel = await _brandManager.GetBrandById(id);
            return PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BrandModel model)
        {
            if (ModelState.IsValid)
            {
                var isSaved = await _brandManager.SaveBrand(model);
                if (isSaved)
                {
                    return RedirectToAction("List");
                }
            }
            return PartialView(model); //TODO: view with validation errors
        }

        [HttpGet]
        public async Task<IActionResult> BrandProductCategories(int brandId)
        {
            var viewModel = await _brandManager.GetBrandProductCategories(brandId); //TODO:
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                var category =  _brandManager.GetBrandById(id);
                var model = category.Result;
                return PartialView("ConfirmDelete", model);
            }

            AddError("Cannot delete empty brand");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(BrandModel model)
        {
            if (model != null)
            {
                var result = await _brandManager.DeleteBrand(model.Id);
                if (result)
                {
                    return RedirectToAction("List");
                }
            }
            AddError("Cannot delete empty brand.");
            return View();
        }

        #endregion
    }
}