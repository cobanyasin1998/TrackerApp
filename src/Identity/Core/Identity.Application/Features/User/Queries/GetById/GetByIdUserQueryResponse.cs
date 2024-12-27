using CoreBase.Dto.Core.EncryptedDto;

namespace Identity.Application.Features.User.Queries.GetById;

public class GetByIdUserQueryResponse : EncryptedResponseDto
{
    public GetByIdUserQueryResponse(long Id)
        => this.Id = Id;
    public string UserName { get; set; }
}
