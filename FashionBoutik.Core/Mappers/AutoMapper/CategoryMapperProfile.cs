using AutoMapper;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.Mappers
{
    public class CategoryMapperProfile : Profile
    {
       public CategoryMapperProfile()
        {
            this.CreateMap<CategoryModel, Category>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.ParentId, opts => opts.MapFrom(source => source.ParentCategoryId))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.CategoryName))
                    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description))
                    .ForMember(x => x.Image, opts => opts.MapFrom(source => source.Image));
                    //.ForMember(x => x.HierarchicalLevel, opts => opts.MapFrom(source => source.HierarchicalLevel))
                    //.ForMember(x => x.CortexicaCategoryId, opts => opts.MapFrom(source => source.CortexicaCategoryId))
                    //.ForMember(x => x.ExploreColorModuleRatio, opts => opts.MapFrom(source => source.ExploreColorModuleRatio))
                    //.ForMember(x => x.ExploreMotifModuleRatio, opts => opts.MapFrom(source => source.ExploreMotifModuleRatio));

            this.CreateMap<Category, CategoryModel>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.ParentCategoryId, opts => opts.MapFrom(source => source.ParentId))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.CategoryName, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description))
                    .ForMember(x => x.Image, opts => opts.MapFrom(source => source.Image));
        }
    }
}