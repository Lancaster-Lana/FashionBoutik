using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FashionBoutik.DomainServices;
using FashionBoutik.Models;

namespace FashionBoutik.Controllers
{
    [Area("Admin")]
    public class CategoryController : BaseController
    {
        #region Ctor

        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        #endregion

        #region UI View actions

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var viewModel = await _categoryManager.GetAllCategories();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CategoryModel();
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryManager.SaveCategory(model);
                if (result)
                {
                    return RedirectToAction("List");
                }
                //else  AddErrors();
            }
            return View(model); //view with validation errors
        }

        [HttpGet]
        //[Route("{id}/edit")]//[Route("~/api/category/{id}/edit")] - to rewrite path
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await _categoryManager.GetCategoryById(id);
            return PartialView(viewModel);
        }

        /// <summary>
        /// Save details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryManager.SaveCategory(model);
                if (result)
                {
                    return RedirectToAction("List");
                }
                //else  AddErrors();
            }
            return View(model); //view with validation errors
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var model = await _categoryManager.GetCategoryById(id);
                return PartialView("ConfirmDelete", model);
            }

            AddError("Cannot delete empty category");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(CategoryModel model)
        {
            if (model != null)
            {
                var result = await _categoryManager.DeleteCategory(model.Id);
                if (result)
                {
                    return RedirectToAction("List");
                }
            }
            AddError("Cannot delete empty category.");
            return View();
        }

        // get api/category/7/subcategories

        //[Route("~/api/category/{categororyId}/subcategories")]
        //public async Task<IActionResult> SubCategories(int categororyId)
        //{
        //    var viewModel = await _categoryProvider.GetCategoryHierarchy(categororyId); //?.MapTo<IList<CategoryViewModel>>()
        //    return View(viewModel);
        //}

        #endregion
    }
}