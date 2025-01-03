using CoreBase.Dto.Core.CoreResponse;
using MediatR;

namespace Identity.Application.Features.Organization.Commands.Create;

public class CreateOrganizationCommandRequest : IRequest<Result<CreateOrganizationCommandResponse>>
{
    public required String Name { get; set; }
    public required String Code { get; set; }

    public String? Description { get; set; }
    public long? ParentOrganizationId { get; set; }
}
