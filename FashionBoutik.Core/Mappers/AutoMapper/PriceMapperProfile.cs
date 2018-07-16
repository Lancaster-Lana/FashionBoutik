using AutoMapper;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.Core.Mappers
{
    public class PriceMapperProfile : Profile
    {
        public PriceMapperProfile()
        {
            this.CreateMap<PriceModel, Price>()
                    .ForMember(x => x.ProductId, opts => opts.MapFrom(source => source.Id))
                    //.ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.PriceDate, opts => opts.MapFrom(source => source.PriceDate))
                    .ForMember(x => x.Currency, opts => opts.MapFrom(source => source.Currency))
                    //.ForMember(x => x.CurrencyId, opts => opts.MapFrom(source => source.Currency.Id))
                    .ForMember(x => x.Value, opts => opts.MapFrom(source => source.Value));

            this.CreateMap<Price, PriceModel>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.ProductId))
                    //.ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.PriceDate, opts => opts.MapFrom(source => source.PriceDate))
                    .ForMember(x => x.Currency, opts => opts.MapFrom(source => source.Currency))
                    //.ForMember(x => x.Currency.Id, opts => opts.MapFrom(source => source.CurrencyId))
                    .ForMember(x => x.Value, opts => opts.MapFrom(source => source.Value));
        }
    }
}