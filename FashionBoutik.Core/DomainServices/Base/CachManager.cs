using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using FashionBoutik.Models;

namespace FashionBoutik.DomainServices
{
    public class CachManager : ICachManager
    {

        private static readonly TimeSpan Duration = TimeSpan.FromMinutes(5);

        private readonly IMemoryCache _memoryCache;

        private readonly IProductManager _backedManager;

        private readonly IUsersGroupManager _usersGroupManager;

        public CachManager(IMemoryCache memoryCache,
            IUsersGroupManager usersGroupManager,
            IProductManager backedManager)
        {
            _memoryCache = memoryCache;

            _usersGroupManager = usersGroupManager;

            _backedManager = backedManager;
        }

        public async Task<IEnumerable<UsersGroupModel>> GetAllUsersGroups()
        {
            return await _memoryCache.GetOrCreateAsync("AllUsersGroups", (entry) =>
            {
                entry.SlidingExpiration = Duration;
                return _usersGroupManager.GetAllUsersGroups();
            });
        }

        //public async Task<CategoryModel> GetCategoryById(Guid id)
        //{
        //    var categoryModels = await _memoryCache.GetOrCreateAsync("allflat", (entry) => {
        //        entry.SlidingExpiration = Duration;
        //        return _backedManager.AllCategories();
        //    });
        //    return categoryModels.FirstOrDefault(c => c.CategoryId == id);
        //}

        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            return await _memoryCache.GetOrCreateAsync("AllCategories", (entry) =>
            {
                entry.SlidingExpiration = Duration;
                return _backedManager.GetAllCategories(); //_backedManager.Categories(publishedOnly, hasProducts);
            });
        }

        /// <summary>
        /// List of categories to which product may belong
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        //public async Task<IEnumerable<CategoryModel>> GetProductCategories(int productId)
        //{
        //return (await GetAllCategories()).Where(c => c.Products.Contains(productId));
        //}

        public async Task<IEnumerable<CurrencyModel>> GetAllCurrencies()
        {
            return await _memoryCache.GetOrCreateAsync("AllCurrencies", (entry) =>
            {
                entry.SlidingExpiration = Duration;
                return _backedManager.GetAllCurrencies();
            });
        }

        public async Task<IEnumerable<BrandModel>> GetAllBrands()
        {
            return await _memoryCache.GetOrCreateAsync("AllBrands", (entry) =>
            {
                entry.SlidingExpiration = Duration;
                return _backedManager.GetAllBrands();
            });
        }

        public async Task<IEnumerable<ProductModel>> GetBrandProducts(int brandId)
        {
            return await _memoryCache.GetOrCreateAsync("BrandProducts", (entry) =>
            {
                entry.SlidingExpiration = Duration;
                return _backedManager.GetBrandProducts(brandId);
            });
        }

        public async Task<IEnumerable<ColorModel>> GetAllColors()
        {
            return await _memoryCache.GetOrCreateAsync("AllColors", (entry) =>
            {
                entry.SlidingExpiration = Duration;
                return _backedManager.GetAllColors();
            });
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            return await _memoryCache.GetOrCreateAsync("AllProducts", (entry) =>
            {
                entry.SlidingExpiration = Duration;
                return _backedManager.GetAllProducts();
            });
        }

        public async Task<IEnumerable<SizeModel>> GetAllSizes()
        {
            return await _memoryCache.GetOrCreateAsync("AllSizes", (entry) =>
            {
                entry.SlidingExpiration = Duration;
                return _backedManager.GetAllSizes();
            });
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            return await _memoryCache.GetOrCreateAsync("Product", (entry) =>
            {
                entry.SlidingExpiration = Duration;
                return _backedManager.GetProductById(id);
            });
        }

        //public Task<bool> SaveProduct(ProductModel model)
        //{
        //    return _backedManager.SaveProduct(model);
        //}

        //public async Task<bool> DeleteProduct(int id)
        //{
        //    return await _backedManager.DeleteProduct(id);
        //}
    }
}