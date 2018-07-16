using AutoMapper;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.Core.Mappers
{
    public  class SizeMapperProfile : Profile
    {
        public SizeMapperProfile()
        {
            this.CreateMap<SizeModel, Size>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description))
                    .ForMember(x => x.Acronym, opts => opts.MapFrom(source => source.Acronym));
            this.CreateMap<Size, SizeModel>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description))
                    .ForMember(x => x.Acronym, opts => opts.MapFrom(source => source.Acronym));
        }
    }
}