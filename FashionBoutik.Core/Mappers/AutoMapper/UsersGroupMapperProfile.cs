using AutoMapper;
using FashionBoutik.Entities;
using FashionBoutik.Models;

namespace FashionBoutik.Mappers
{
    public class UsersGroupMapperProfile : Profile
    {
       public UsersGroupMapperProfile()
        {
            this.CreateMap<UsersGroupModel, UsersGroup>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description))
                    .ForMember(x => x.Users, opts => opts.MapFrom(source => source.Users));

            this.CreateMap<UsersGroup, UsersGroupModel>()
                    .ForMember(x => x.Id, opts => opts.MapFrom(source => source.Id))
                    .ForMember(x => x.Name, opts => opts.MapFrom(source => source.Name))
                    .ForMember(x => x.Description, opts => opts.MapFrom(source => source.Description))
                    .ForMember(x => x.Users, opts => opts.MapFrom(source => source.Users));
        }
    }
}