using AutoMapper;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.Core.Mappers
{
    public class CurrencyMapperProfile : Profile
    {
        public CurrencyMapperProfile()
        {
            this.CreateMap<CurrencyModel, Currency>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.CurrencyCode, opts => opts.MapFrom(source => source.CurrencyCode))
                    .ForMember(x => x.CurrencyBase, opts => opts.MapFrom(source => source.CurrencyBase))
                    .ForMember(x => x.Decimals, opts => opts.MapFrom(source => source.Decimals))
                    .ForMember(x => x.Symbol, opts => opts.MapFrom(source => source.Symbol))
                    .ForMember(x => x.ConversionRate, opts => opts.MapFrom(source => source.ConversionRate));
            this.CreateMap<Currency, CurrencyModel>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.CurrencyCode, opts => opts.MapFrom(source => source.CurrencyCode))
                    .ForMember(x => x.CurrencyBase, opts => opts.MapFrom(source => source.CurrencyBase))
                    .ForMember(x => x.Decimals, opts => opts.MapFrom(source => source.Decimals))
                    .ForMember(x => x.Symbol, opts => opts.MapFrom(source => source.Symbol))
                    .ForMember(x => x.ConversionRate, opts => opts.MapFrom(source => source.ConversionRate));
        }
    }
}