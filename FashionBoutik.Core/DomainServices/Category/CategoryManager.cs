using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.EntityFramework.Repository;
using FashionBoutik.Models;
using FashionBoutik.Core.Mappers;
using FashionBoutik.Entities;

namespace FashionBoutik.DomainServices
{
    /// <summary>
    /// Domain service to manage categories logic
    /// - view categories hierarchy, search filtration, etc.
    /// - create, edit, remove category(TODO:  in future)
    /// </summary>
    public class CategoryManager : DomainService, ICategoryManager
    {
        #region ctor

        private readonly ICategoryRepository _categoryRepository;
        private readonly IImagePathManager _imagePathManager;

        public CategoryManager(
            ICategoryRepository categoryRepository, 
            IImagePathManager imagePathManager = null)
        {
            _categoryRepository = categoryRepository;
            _imagePathManager = imagePathManager;//service to get images for categories
        }

        //public Task<IEnumerable<CategoryModel>> Categories(bool publishedOnly = true, bool hasProducts = true)
        //{
        //    throw new System.NotImplementedException();
        //}

        public async Task<IList<CategoryModel>> GetAllCategories()
        {
            var list = (await _categoryRepository.GetAll())?.MapTo<CategoryModel>();
            return list.ToList();
        }
        public async Task<CategoryModel> GetCategoryById(int id)
        {
            var entity = await _categoryRepository.GetById(id);

            return entity?.MapTo<CategoryModel>();
        }

        public async Task<bool> DeleteCategory(int id)
        {
            return await _categoryRepository.Delete(id);
        }


        public async Task<bool> SaveCategory(CategoryModel model)
        {
            var entity = model?.MapTo<Category>();
            if (model.Id < 1)
                await _categoryRepository.Insert(entity);
            else
                await _categoryRepository.Update(entity);

            return true;
        }

        #endregion
    }
}