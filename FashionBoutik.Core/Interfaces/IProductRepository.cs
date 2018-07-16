using FashionBoutik.Entities;

namespace FashionBoutik.EntityFramework.Repository
{
    public interface IProductRepository : IRepository<Product, int>
    {
        //Task<IEnumerable<CategoryProductCountEntity>> GetCategoriesProductCount();

        //Task<ProductEntity> GetByName(string productName);
        //Task<ProductEntity> GetByNameAndColor(string name);

        #region Supplementary methods (todo: better exclude from this repository, but add to Manager\DomainService)

         /*
        /// <summary>
        ///Load product all categories 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Category>> GetCategories();

        //Task<CategoryEntity> GetCategoryById(Guid id);

        /// <summary>
        ///Load products all brands 
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BrandEntity>> GetBrands();
        /// <summary>
        /// Load product all colors
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ColorPallet>> GetColors();
        /// <summary>
        /// Load product retailers
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Retailer>> GetRetailers();
        */
        #endregion

    }
}