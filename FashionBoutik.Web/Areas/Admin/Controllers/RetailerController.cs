using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FashionBoutik.Models;
using FashionBoutik.DomainServices;

namespace FashionBoutik.Controllers
{
    [Area("Admin")]
    public class RetailerController : Controller
    {
        #region Ctor

        private readonly IRetailerManager _retailerManager;

        public RetailerController(IRetailerManager retailerManager)
        {
            _retailerManager = retailerManager;
        }

        //private readonly IRetailerAppService _retailerAppService;
        //public RetailerController(IRetailerAppService retailerAppService)
        //{
        //    _retaileryAppService = retailerAppService;
        //}

        #endregion

        #region UI View actions


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var viewModel = await _retailerManager.GetAllRetailers(); //?.MapTo<BrandViewModel>()
            //ViewBag.AllPartners = (await _productGroupingProvider.GetAllPartners()).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            //Prepare a new brand
            var model = new RetailerModel();
            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RetailerModel model)
        {
            if (ModelState.IsValid)
            {
                var isSaved = await _retailerManager.SaveRetailer(model);
                if (isSaved)
                {
                    return RedirectToAction("List");
                }
            }
            return View(model); //TODO: view with validation errors
        }

        [HttpGet]
        //[Route("{id}/edit")]//[Route("~/api/category/{id}/edit")] - to rewrite path
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await _retailerManager.GetRetailerById(id);
            return PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RetailerModel model)
        {
            if (ModelState.IsValid)
            {
                var isSaved = await _retailerManager.SaveRetailer(model);
                if (isSaved)
                {
                    return RedirectToAction("List");
                }
            }
            return View(model); //TODO: view with validation errors
        }

        #endregion
    }
}