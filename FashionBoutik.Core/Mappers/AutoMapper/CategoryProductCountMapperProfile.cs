using AutoMapper;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.Mappers
{
    public class CategoryProductCountMapperProfile : Profile
    {
       public CategoryProductCountMapperProfile()
        {
            this.CreateMap<CategoryProductCountModel, CategoryProductCountEntity>()
                    .ForMember(x => x.CategoryId, opts => opts.MapFrom(source => source.CategoryId))
                    .ForMember(x => x.Partition, opts => opts.MapFrom(source => source.Partition))
                    .ForMember(x => x.PublishedProductCount, opts => opts.MapFrom(source => source.PublishedProductCount));
            
            this.CreateMap<CategoryProductCountEntity, CategoryProductCountModel>()
                     .ForMember(x => x.CategoryId, opts => opts.MapFrom(source => source.CategoryId))
                    .ForMember(x => x.Partition, opts => opts.MapFrom(source => source.Partition))
                    .ForMember(x => x.PublishedProductCount, opts => opts.MapFrom(source => source.PublishedProductCount));
            ;
        }
    }
}