using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Models;
using FashionBoutik.Core.Mappers;
using FashionBoutik.EntityFramework.Repository;
using FashionBoutik.Entities;

namespace FashionBoutik.DomainServices
{
    /// <summary>
    ///  A service to manage brands busines logic 
    /// - search, filtering, etc.
    /// - add, edit, remove brand
    /// </summary>
    public class BrandManager : DomainService, IBrandManager
    {
        #region ctor

        private readonly IBrandRepository _brandRepository;
        private readonly IProductRepository _productRepository;
        private readonly IImagePathManager _imagePathManager;

        public BrandManager(IBrandRepository brandRepository, IProductRepository productRepository, IImagePathManager imagePathManager = null)
        {
            _brandRepository = brandRepository;
            _productRepository = productRepository;

            //manager to get images for brands
            _imagePathManager = imagePathManager;
        }

        #endregion

        #region implementation IBrandManager

        public async Task<IEnumerable<BrandModel>> GetAllBrands()
        {
            var entitiesList = await _brandRepository.GetAll();
            var model = entitiesList.MapTo<BrandModel>(); //used automapper (not old BrandModelMapper.Map(list)

            //todo: set\map images full path per Brand
            if (_imagePathManager != null)
                Parallel.ForEach(model, (brand) =>
                  brand.Image = brand.Image ?? _imagePathManager.GetImageUrl(brand.Id, brand.Image));

            return model;
        }

        public async Task<BrandModel> GetBrandById(int id)
        {
            var entity = await _brandRepository.GetById(id);
            var model = entity.MapTo<BrandModel>();

            //todo: set\map images full path per Brand
            if (model.Image != null && _imagePathManager != null)
                model.Image = _imagePathManager.GetImageUrl(model.Id, model.Image);

            return model;
        }
        public async Task<IList<ProductModel>> GetBrandProducts(int brandId)
        {
            var products = (await _productRepository.GetAll()).Where(p => p.BrandId == brandId);

            return products?.MapTo<ProductModel>().ToList();
        }

        public Task<IEnumerable<CategoryModel>> GetBrandProductCategories(int brandId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> SaveBrand(BrandModel model)
        {
            var entity = model.MapTo<Brand>();
            if (model.Id < 1)
                 await _brandRepository.Insert(entity);
            else
                await _brandRepository.Update(entity);

            return true;
        }

        public async Task<bool> DeleteBrand(int id)
        {
            return await _brandRepository.Delete(id);
        }

        #endregion
    }
}