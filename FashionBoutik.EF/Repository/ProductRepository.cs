using System.Collections.Generic;
using System.Threading.Tasks;
using FashionBoutik.Entities;
using FashionBoutik.EF.DBModel;

namespace FashionBoutik.EntityFramework.Repository
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        //Init related repositories 
        private readonly ImageRepository _imageRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IColorRepository _colorRepository;
        private readonly IRetailerRepository _retailerRepository;

        public ProductRepository(AppDbContext context) : base(context)
        {
            //TODO: INIT additional repositories for other entities
            _imageRepository = new ImageRepository(context);
            _categoryRepository = new CategoryRepository(context);
            _brandRepository = new BrandRepository(context);
            _colorRepository = new ColorRepository(context);
            _retailerRepository = new RetailerRepository(context);
        }

        #region repository methods

        /// <summary>
        /// Include entity PricePerUnit (as related)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<Product> GetById(int id)
        {
            return await base.GetByIdIncluding(id, new string[] { "PricePerUnit", "Attachments" });
        }

        /// <summary>
        /// Get all products number for each category
        /// </summary>
        /// <returns></returns>
        //public Task<IEnumerable<CategoryProductCountEntity>> GetCategoriesProductCount()
        //{
        //    var productsCount = _productCounts;

        //    /// TODO: usage CategoryStorage : [Categories, CategoryProducts]
        //    //var categories = await GetCategories();
        //    //var result = new CategoryStorage(categories, productsCount);

        //    return Task.FromResult(_productCounts);
        //}

        ///// <summary>
        /////Get products number for the category Id 
        ///// </summary>
        ///// <returns></returns>
        //public async Task<CategoryProductCountEntity> GetProductCountByCategoryId(Guid categoryId)
        //{
        //    var categoryProductCounts = (await this.GetCategoriesProductCount()).Where(c => c.CategoryId.Equals(categoryId));
        //    return categoryProductCounts.SingleOrDefault();
        //}

        #endregion

        #region Cached data methods (todo: better not include to this repository, but in Provider\DomainService)

        private IEnumerable<Category> _categories;

        /// <summary>
        ///Load product all categories 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> GetCategories()
        {
            if (_categories == null)
                _categories = await _categoryRepository.GetAll();

            return _categories;
        }

        private IEnumerable<Brand> _brands;
        /// <summary>
        ///Load products all brands 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Brand>> GetBrands()
        {
            if (_brands == null)
                _brands = await _brandRepository.GetAll();

            return _brands;
        }

        private IEnumerable<ColorPallet> _colors;
        /// <summary>
        /// Load product all colors
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ColorPallet>> GetColors()
        {
            if (_colors == null)
                _colors = await _colorRepository.GetAll();

            return _colors;
        }

        private IEnumerable<Retailer> _retailers;

        /// <summary>
        /// Load product retailers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Retailer>> GetRetailers()
        {
            if (_retailers == null)
                _retailers = await _retailerRepository.GetAll();
            return _retailers;
        }

        #endregion
    } 
}