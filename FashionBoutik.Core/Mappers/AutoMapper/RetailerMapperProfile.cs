using AutoMapper;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.Core.Mappers
{
    public class RetailerMapperProfile : Profile
    {
        public RetailerMapperProfile()
        {
            this.CreateMap<RetailerModel, Retailer>()
                    //.ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id)) //TODO: ? FashionPartnerId = Retailer.Id ? 
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description))
                    .ForMember(x => x.Address, opts => opts.MapFrom(source => source.Address))
                    .ForMember(x => x.RetailerUrl, opts => opts.MapFrom(source => source.RetailerUrl));
            //.ForMember(x => x.Info, opts => opts.MapFrom(source => source.Info))

            this.CreateMap<Retailer, RetailerModel>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id)) //TODO: ? FashionPartnerId = Retailer.Id ? 
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description))
                    .ForMember(x => x.Address, opts => opts.MapFrom(source => source.Address))
                    .ForMember(x => x.RetailerUrl, opts => opts.MapFrom(source => source.RetailerUrl));
        }
    }
}