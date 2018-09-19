
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;

namespace FashionBoutik.DomainServices
{
    public interface ICachManager
    {
        Task<IEnumerable<UsersGroupModel>> GetAllUsersGroups();

        Task<IEnumerable<CurrencyModel>> GetAllCurrencies();

        Task<IEnumerable<CategoryModel>> GetAllCategories();

        Task<IEnumerable<BrandModel>> GetAllBrands();

        Task<IEnumerable<ProductModel>> GetAllProducts();

        Task<IEnumerable<ColorModel>> GetAllColors();

        Task<IEnumerable<SizeModel>> GetAllSizes();
    }
}