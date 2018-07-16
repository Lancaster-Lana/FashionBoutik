using AutoMapper;
using FashionBoutik.Mappers;

namespace FashionBoutik.Core.Mappers
{
    /// <summary>
    /// TODO:  Config mappings between BusinessObjects (Model)-> Entities (DAO) 
    /// NOTE: also can be used Abp.AutoMapper:
    ///   [AutoMap(typeof(Category))]
    ///   public class CategoryViewModel (OR public class CategoryDto : FullAuditedEntityDto<long>)
    /// </summary>
    public static class MappingConfig
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                // Mappings between Business and DB layer objects
                cfg.AddProfile(new RetailerMapperProfile());
                cfg.AddProfile(new AddressMapperProfile());
                cfg.AddProfile(new UsersGroupMapperProfile());

                cfg.AddProfile(new CategoryMapperProfile());
                cfg.AddProfile(new ColorMapperProfile());
                cfg.AddProfile(new BrandMapperProfile());
                cfg.AddProfile(new SizeMapperProfile());
                cfg.AddProfile(new PriceMapperProfile());
                cfg.AddProfile(new ProductMapperProfile());
                cfg.AddProfile(new BinaryObjectMapperProfile());
                cfg.AddProfile(new OrderMapperProfile());
                cfg.AddProfile(new CartItemMapperProfile());
                cfg.AddProfile(new CurrencyMapperProfile());// PaymentMapperProfile());
                cfg.AddProfile(new RetailerMapperProfile());

                //mapping between Presentation and Business layer objects
            });

            return config;
        }
    }
}
