using Microsoft.AspNetCore.Mvc;

namespace CoreBase.Interfaces.ControllerInterfaces;

public interface IGetByIdController<TGetByIdReq>
{
    Task<IActionResult> GetById([FromBody] TGetByIdReq getByIdRequest);
}

