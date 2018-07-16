using FashionBoutik.Entities;
using System.Collections.Generic;

namespace FashionBoutik.Models
{
    public class BaseViewModel
    {
        #region Common static collections

        public static IEnumerable<CategoryModel> AllCategories { get; set; }

        public static IEnumerable<ColorModel> AllColors { get; set; }

        public static IEnumerable<BrandModel> AllBrands { get; set; }

        public static IEnumerable<SizeModel> AllSizes { get; set; }

        public static IEnumerable<CurrencyModel> AllCurrencies { get; set; }
       
        #endregion
    }
}