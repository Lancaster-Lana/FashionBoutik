using AutoMapper;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.Core.Mappers
{
    public class BinaryObjectMapperProfile : Profile
    {
        public BinaryObjectMapperProfile()
        {
            this.CreateMap<BinaryObjectModel, BinaryObject>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.ContentType, opts => opts.MapFrom(source => source.ContentType))
                    .ForMember(x => x.CreatorUser, opts => opts.MapFrom(source => source.CreatorUser))
                    .ForMember(x => x.ProductId, opts => opts.MapFrom(source => source.ProductId))
                    .ForMember(x => x.Product, opts => opts.MapFrom(source => source.Product))
                    //.ForMember(x => x.TenantId, opts => opts.MapFrom(source => source.TenantId))
                    .ForMember(x => x.Bytes, opts => opts.MapFrom(source => source.Bytes));

            this.CreateMap<BinaryObject, BinaryObjectModel>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.CreatedDate, opts => opts.MapFrom(source => source.CreatedDate))
                    .ForMember(x => x.ContentType, opts => opts.MapFrom(source => source.ContentType))
                    .ForMember(x => x.CreatorUser, opts => opts.MapFrom(source => source.CreatorUser))
                    .ForMember(x => x.ProductId, opts => opts.MapFrom(source => source.ProductId))
                    .ForMember(x => x.Product, opts => opts.MapFrom(source => source.Product))
                    //.ForMember(x => x.TenantId, opts => opts.MapFrom(source => source.TenantId))
                    .ForMember(x => x.Bytes, opts => opts.MapFrom(source => source.Bytes));
        }
    }
}