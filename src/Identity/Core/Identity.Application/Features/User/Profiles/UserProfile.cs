using AutoMapper;
using CoreBase.Identity.Entities.Base;
using Identity.Application.Features.User.Commands.Create;
using Identity.Application.Features.User.Commands.Update;

namespace Identity.Application.Features.User.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserCommandRequest, UserEntity>();
        CreateMap<UpdateUserCommandRequest, UserEntity>();
        //CreateMap<UserEntity, GetAllUserQueryResponseItemDto>();
    }
}
