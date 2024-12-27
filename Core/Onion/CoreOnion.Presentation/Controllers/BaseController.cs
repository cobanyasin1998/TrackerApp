using CoreBase.Interfaces.RequestInterfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CoreOnion.Presentation.Controllers;

public class BaseController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator =>
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    protected IActionResult HandleResponse<T>(T result) where T : ICoreResponse
    {
        return result.HttpStatusCode switch
        {
            StatusCodes.Status400BadRequest => BadRequest(result),
            StatusCodes.Status404NotFound => NotFound(result),
            StatusCodes.Status401Unauthorized => Unauthorized(result),
            StatusCodes.Status200OK => Ok(result),
            _ => StatusCode(result.HttpStatusCode, new { result })
        };
    }
}
