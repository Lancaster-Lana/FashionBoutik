using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using FashionBoutik.Core.Mappers;
using FashionBoutik.Entities;
using FashionBoutik.EntityFramework.Repository;
using FashionBoutik.Models;
using System;

namespace FashionBoutik.DomainServices
{
    /// <summary>
    /// Product manager - methods for product:
    /// - get all products (also add, edit, view details)
    /// - search product by name, id, brand, color, etc.
    /// - find product number per store, location, etc.
    /// </summary>
    public class ProductManager : DomainService, IProductManager
    {

        #region ctor

        private readonly IProductRepository _productRepository;
        private readonly IImageRepository _imageRepository;

        private readonly ICategoryManager _categoryManager;
        private readonly IBrandManager _brandManager;
        private readonly IColorManager _colorManager;
        private readonly ICurrencyManager _currencyManager;
        private readonly ISizeManager _sizeManager;
        private readonly IRetailerManager _retailerManager;

        public ProductManager(IProductRepository productRepository, IImageRepository imageRepository,
                                ICurrencyManager currencyManager = null,
                                ICategoryManager categoryManager = null,
                                IBrandManager brandManager = null,
                                IColorManager colorManager = null,
                                ISizeManager sizeManager = null,
                                IRetailerManager retailerManager = null)
        {
            _productRepository = productRepository;
            _imageRepository = imageRepository;
            //init separate Managers
            _currencyManager = currencyManager;
            _categoryManager = categoryManager;
            _brandManager = brandManager;
            _colorManager = colorManager;
            _sizeManager = sizeManager;
            _retailerManager = retailerManager;
        }

        #endregion

        #region implementation IProductManager

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            var allProducts = await _productRepository.GetAll();
            return allProducts?.MapTo<ProductModel>();
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            var entity = await _productRepository.GetById(id);

            return entity?.MapTo<ProductModel>();
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepository.Delete(id);
        }

        //[UnitOfWork]
        public async Task<bool> SaveProduct(ProductModel model)
        {
            var entity = model?.MapTo<Product>();

            //TODO: if there are new attached images - create in DB
            var newAttachedImages = entity.Attachments.Where(a =>  a.Id <= 0);
            foreach (var image in newAttachedImages)
            {
                image.ProductId = entity.Id;
                //image.Product = entity;
                await _imageRepository.Insert(image);
            }

            if (model.Id < 1)
                await _productRepository.Insert(entity);
            else
                await _productRepository.Update(entity);

            return true;
        }

        #region Additinal collections

        //public async Task<IEnumerable<CategoryModel>> GetProductCategories(int productId)
        //{
        //    return 
        //}

        public async Task<IEnumerable<BrandModel>> GetAllBrands()
        {
            return await _brandManager.GetAllBrands();
        }

        public async Task<IEnumerable<ProductModel>> GetBrandProducts(int brandId)
        {
            return (await GetAllProducts()).Where(prop => prop.Brand != null && prop.Brand.Id == brandId);
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            return await _categoryManager.GetAllCategories();
        }

        public async Task<IEnumerable<ColorModel>> GetAllColors()
        {
            return await _colorManager.GetAllColors();
        }

        public async Task<IEnumerable<CurrencyModel>> GetAllCurrencies()
        {
            return await _currencyManager.GetAllCurrencies();
        }

        public async Task<IEnumerable<SizeModel>> GetAllSizes()
        {
            return await _sizeManager.GetAllSizes();
        }

        #endregion

        #endregion
    }
}