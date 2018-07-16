using AutoMapper;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.Core.Mappers
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            this.CreateMap<ProductModel, Product>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description))
                    .ForMember(x => x.Attachments, opts => opts.MapFrom(source => source.Attachments))
                    .ForMember(x => x.Brand, opts => opts.MapFrom(source => source.Brand))
                    .ForMember(x => x.Category, opts => opts.MapFrom(source => source.Category))
                    .ForMember(x => x.Color, opts => opts.MapFrom(source => source.Color))
                    .ForMember(x => x.Sizes, opts => opts.MapFrom(source => source.Sizes))
                    .ForMember(x => x.PriceHistory, opts => opts.MapFrom(source => source.PriceHistory))
                    .ForMember(x => x.PricePerUnit, opts => opts.MapFrom(source => source.PricePerUnit));
                    //.ForMember(x => x.PricePerUnitId, opts => opts.MapFrom(source => source.PricePerUnit.Id))

            this.CreateMap<Product, ProductModel>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description))
                    .ForMember(x => x.Category, opts => opts.MapFrom(source => source.Category))
                    .ForMember(x => x.Attachments, opts => opts.MapFrom(source => source.Attachments))
                    .ForMember(x => x.Brand, opts => opts.MapFrom(source => source.Brand))
                    .ForMember(x => x.Color, opts => opts.MapFrom(source => source.Color))
                    .ForMember(x => x.Sizes, opts => opts.MapFrom(source => source.Sizes))
                    .ForMember(x => x.PriceHistory, opts => opts.MapFrom(source => source.PriceHistory))
                    .ForMember(x => x.PricePerUnit, opts => opts.MapFrom(source => source.PricePerUnit));
                    //.ForMember(x => x.PricePerUnit.Id, opts => opts.MapFrom(source => source.PricePerUnitId));
        }
    }
}