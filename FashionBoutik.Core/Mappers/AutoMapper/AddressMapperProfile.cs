using AutoMapper;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.Core.Mappers
{
    public class AddressMapperProfile : Profile
    {
        public AddressMapperProfile()
        {
            this.CreateMap<AddressModel, Address>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.ZipCode, opts => opts.MapFrom(source => source.ZipCode))
                    .ForMember(x => x.City, opts => opts.MapFrom(source => source.City))
                    .ForMember(x => x.Country, opts => opts.MapFrom(source => source.Country))
                    .ForMember(x => x.State, opts => opts.MapFrom(source => source.State))
                    .ForMember(x => x.Street, opts => opts.MapFrom(source => source.Street));

            this.CreateMap<Address, AddressModel>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.ZipCode, opts => opts.MapFrom(source => source.ZipCode))
                    .ForMember(x => x.City, opts => opts.MapFrom(source => source.City))
                    .ForMember(x => x.Country, opts => opts.MapFrom(source => source.Country))
                    .ForMember(x => x.State, opts => opts.MapFrom(source => source.State))
                    .ForMember(x => x.Street, opts => opts.MapFrom(source => source.Street));
        }
    }
}