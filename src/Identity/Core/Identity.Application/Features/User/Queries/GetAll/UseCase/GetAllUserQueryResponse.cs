namespace Identity.Application.Features.User.Queries.GetAll.UseCase;

public class GetAllUserQueryResponse(List<GetAllUserQueryResponseItemDto> users)
{
    public List<GetAllUserQueryResponseItemDto> Users { get; private set; } = users;

}
public class GetAllUserQueryResponseItemDto
{
    public string? FirstName { get; set; }
}
