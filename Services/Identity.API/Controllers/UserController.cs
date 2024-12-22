using CoreOnion.Presentation.Controllers;
using Identity.Application.Features.User.Commands.Create;
using Identity.Application.Features.User.Commands.Delete;
using Identity.Application.Features.User.Commands.Update;
using Identity.Application.Features.User.Queries.GetAll;
using Identity.Application.Features.User.Queries.GetById;

namespace Identity.API.Controllers;

public class UserController : AbstractController<CreateUserCommandRequest, UpdateUserCommandRequest, DeleteUserCommandRequest, GetByIdUserQueryRequest, GetAllUserQueryRequest>
{
}
