using Microsoft.AspNetCore.Mvc;

namespace CoreBase.Interfaces.ControllerInterfaces;

public interface ICreateController<TCreateReq>
{
    Task<IActionResult> Create([FromBody] TCreateReq request);
}
