
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;

namespace FashionBoutik.DomainServices
{
    public interface IBrandManager
    {
        Task<BrandModel> GetBrandById(int id);

        Task<IEnumerable<BrandModel>> GetAllBrands();

        /// <summary>
        /// TODO: Get\find brand products : details about color, size, price, shop location, etc.
        /// </summary>
        /// <param name="id">brand id</param>
        /// <returns></returns>
        Task<IList<ProductModel>> GetBrandProducts(int brandId);
 
        Task<IEnumerable<CategoryModel>> GetBrandProductCategories(int brandId);

        /// <summary>
        /// Create or update brand
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> SaveBrand(BrandModel model);

        Task<bool> DeleteBrand(int id);
    }
}