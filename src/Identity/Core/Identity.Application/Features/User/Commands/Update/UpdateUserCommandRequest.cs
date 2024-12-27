using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Dto.Core.EncryptedDto;
using CoreBase.Identity.Enums.Base;
using MediatR;

namespace Identity.Application.Features.User.Commands.Update;

public class UpdateUserCommandRequest : EncryptedRequestDto, IRequest<Result<UpdateUserCommandResponse>>
{
    public long OrganizationEntityId { get; set; }
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Bio { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public EGender Gender { get; set; }
}
