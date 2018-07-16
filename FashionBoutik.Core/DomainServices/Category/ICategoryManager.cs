
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;

namespace FashionBoutik.DomainServices
{
    public interface ICategoryManager
    {

        //Task<CategoryModel> GetCategoryHierarchy();

        Task<CategoryModel> GetCategoryById(int id);

        Task<IList<CategoryModel>> GetAllCategories();

        //Task<IEnumerable<CategoryModel>> Categories(bool publishedOnly = true, bool hasProducts = true);

        /// <summary>
        /// Create or update category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> SaveCategory(CategoryModel model);

        Task<bool> DeleteCategory(int id);
    }
}