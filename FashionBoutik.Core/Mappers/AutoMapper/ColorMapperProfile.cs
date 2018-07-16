using AutoMapper;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.Core.Mappers
{
    public class ColorMapperProfile : Profile
    {
        public ColorMapperProfile()
        {
            this.CreateMap<ColorModel, ColorPallet>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.ColorValue, opts => opts.MapFrom(source => source.ColorValue));
            //.ForMember(x => x.PublishStatus, opts => opts.MapFrom(source => source.Status));
            //.ForMember(x => x.ContractVersion, opts => opts.MapFrom(source => source.ContractVersion))

            this.CreateMap<ColorPallet, ColorModel>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.ColorValue, opts => opts.MapFrom(source => source.ColorValue));
            //.ForMember(x => x.Status, opts => opts.MapFrom(source => source.PublishStatus))
            //ForMember(x => x.ContractVersion, opts => opts.MapFrom(source => source.ContractVersion))
        }
    }
}