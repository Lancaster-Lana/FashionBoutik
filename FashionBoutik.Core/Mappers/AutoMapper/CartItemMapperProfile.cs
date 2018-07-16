using AutoMapper;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.Core.Mappers
{
    public class CartItemMapperProfile : Profile
    {
        public CartItemMapperProfile()
        {
            this.CreateMap<CartItemModel, CartItem>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.Product, opts => opts.MapFrom(source => source.Product))
                    .ForMember(x => x.Quantity, opts => opts.MapFrom(source => source.Count));

            this.CreateMap<CartItem, CartItemModel>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.Product, opts => opts.MapFrom(source => source.Product))
                    .ForMember(x => x.Count, opts => opts.MapFrom(source => source.Quantity));
        }
    }
}