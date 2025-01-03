using AutoMapper;
using CoreBase.Identity.Entities.Base;
using Identity.Application.Features.Organization.Commands.Create;
using Identity.Application.Features.Organization.Commands.Update;

namespace Identity.Application.Features.Organization.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateOrganizationCommandRequest, OrganizationEntity>();
        CreateMap<UpdateOrganizationCommandRequest, OrganizationEntity>();
    }
}
