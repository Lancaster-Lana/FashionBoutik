using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;

namespace FashionBoutik.DomainServices
{
    public interface IProductManager
    {
        Task<ProductModel> GetProductById(int id);

        Task<IEnumerable<ProductModel>> GetAllProducts();

        /// <summary>
        /// Returns existing categories of the product (usually one) 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        //Task<IEnumerable<CategoryModel>> GetProductCategories(int productId);

        /// <summary>
        /// Create or update product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> SaveProduct(ProductModel model);

        Task<bool> DeleteProduct(int id);

        #region Additional collections

        Task<IEnumerable<BrandModel>> GetAllBrands();

        /// <summary>
        /// Returns existing brands for some product 
        /// </summary>
        /// <param name="id">brand id</param>
        /// <returns></returns>
        Task<IEnumerable<ProductModel>> GetBrandProducts(int brandId);
        Task<IEnumerable<CategoryModel>> GetAllCategories();
        Task<IEnumerable<ColorModel>> GetAllColors();

        Task<IEnumerable<SizeModel>> GetAllSizes();

        Task<IEnumerable<CurrencyModel>> GetAllCurrencies();
        
        #endregion
    }
}