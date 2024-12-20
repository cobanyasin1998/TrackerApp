using Microsoft.AspNetCore.Mvc;

namespace CoreBase.Interfaces.ControllerInterfaces;

public interface IUpdateController<TUpdateReq>
{
    Task<IActionResult> Update([FromBody] TUpdateReq request);
}
