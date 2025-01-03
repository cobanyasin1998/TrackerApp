using CoreBase.Dto.Core.EncryptedDto;

namespace Identity.Application.Features.Organization.Queries.GetById;

public class GetByIdOrganizationQueryResponse
 : EncryptedResponseDto
{
    public GetByIdOrganizationQueryResponse(long Id)
        => this.Id = Id;
}
