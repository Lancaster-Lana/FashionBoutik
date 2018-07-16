using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FashionBoutik.Models;
using FashionBoutik.DomainServices;

namespace FashionBoutik.Controllers
{
    public class BaseController : Controller
    {

        private readonly IProductManager _productManager;

        public BaseController(IProductManager productManager = null)
        {
            _productManager = productManager;

            if (_productManager != null)
            {
                //TODO: init default collections
                BaseViewModel.AllCategories = _productManager.GetAllCategories().Result;
                BaseViewModel.AllBrands = _productManager.GetAllBrands().Result;
                BaseViewModel.AllColors = _productManager.GetAllColors().Result;
                BaseViewModel.AllSizes = _productManager.GetAllSizes().Result;
                BaseViewModel.AllCurrencies = _productManager.GetAllCurrencies().Result;
            }
        }

        //#region Common Collections

        //public static IEnumerable<CategoryModel> AllCategories { get; set; }

        //public static IEnumerable<BrandModel> AllBrands { get; set; }

        //public static IEnumerable<ColorModel> AllColors { get; set; }

        //public static IEnumerable<SizeModel> AllSizes { get; set; }

        //#endregion

        protected void AddError(IList<string> errors)
        {
            AddError (string.Join(", ", errors));
        }

        protected void AddError(string errorMsg)
        {
            ModelState.AddModelError(string.Empty, errorMsg);
        }
    }
}