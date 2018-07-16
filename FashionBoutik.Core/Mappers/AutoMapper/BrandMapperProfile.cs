using AutoMapper;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.Core.Mappers
{
    public  class BrandMapperProfile : Profile
    {
        public BrandMapperProfile()
        {
            this.CreateMap<BrandModel, Brand>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.Image, opts => opts.MapFrom(source => source.Image))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.Categories, opts => opts.MapFrom(source => source.Categories))
                    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description));

            this.CreateMap<Brand, BrandModel>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.Image, opts => opts.MapFrom(source => source.Image))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.Categories, opts => opts.MapFrom(source => source.Categories))
                    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description));

            //UI viewModel <-> business model objects (For UI filtrations)
            //this.CreateMap<FilterItemViewModel, BrandModel>()
            //    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
            //    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Label))
            //    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description));

            //this.CreateMap<BrandModel, FilterItemViewModel>()
            //    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
            //    .ForMember(x => x.Label, opts => opts.MapFrom(source => source.Name))
            //    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description));
        }
    }
}