using CoreOnion.Presentation.Controllers;
using Identity.Application.Features.Organization.Commands.Create;
using Identity.Application.Features.Organization.Commands.Delete;
using Identity.Application.Features.Organization.Commands.Update;
using Identity.Application.Features.Organization.Queries.GetAll.UseCase;
using Identity.Application.Features.Organization.Queries.GetById;

namespace Identity.API.Controllers;


public class OrganizationController : AbstractController<CreateOrganizationCommandRequest, UpdateOrganizationCommandRequest, DeleteOrganizationCommandRequest, GetByIdOrganizationQueryRequest, GetAllOrganizationQueryRequest>
{
}