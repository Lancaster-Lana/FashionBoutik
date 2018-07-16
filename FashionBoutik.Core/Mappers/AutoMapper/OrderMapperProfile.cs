using AutoMapper;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.Core.Mappers
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            this.CreateMap<OrderModel, Order>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    //.ForMember(x => x.OrderDate, opts => opts.MapFrom(source => source.OrderDate))
                    .ForMember(x => x.OrderItems, opts => opts.MapFrom(source => source.OrderItems))
                    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description))
                    .ForMember(x => x.BuyerId, opts => opts.MapFrom(source => source.BuyerId))
                    .ForMember(x => x.Payment, opts => opts.MapFrom(source => source.Payment))
                    .ForMember(x => x.BillingAddress, opts => opts.MapFrom(source => source.BillingAddress))
                    .ForMember(x => x.ShippingAddress, opts => opts.MapFrom(source => source.ShippingAddress))
                    .ForMember(x => x.Delivered, opts => opts.MapFrom(source => source.Delivered))
                    .ForMember(x => x.DeliveryDate, opts => opts.MapFrom(source => source.DeliveryDate))
                    .ForMember(x => x.Total, opts => opts.MapFrom(source => source.Total));

            this.CreateMap<Order, OrderModel>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    //.ForMember(x => x.OrderDate, opts => opts.MapFrom(source => source.OrderDate))
                    .ForMember(x => x.OrderItems, opts => opts.MapFrom(source => source.OrderItems))
                    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description))
                    .ForMember(x => x.BuyerId, opts => opts.MapFrom(source => source.BuyerId))
                    .ForMember(x => x.Payment, opts => opts.MapFrom(source => source.Payment))
                    .ForMember(x => x.BillingAddress, opts => opts.MapFrom(source => source.BillingAddress))
                    .ForMember(x => x.ShippingAddress, opts => opts.MapFrom(source => source.ShippingAddress))
                    .ForMember(x => x.Delivered, opts => opts.MapFrom(source => source.Delivered))
                    .ForMember(x => x.DeliveryDate, opts => opts.MapFrom(source => source.DeliveryDate))
                    .ForMember(x => x.Total, opts => opts.MapFrom(source => source.Total));
        }
    }
}