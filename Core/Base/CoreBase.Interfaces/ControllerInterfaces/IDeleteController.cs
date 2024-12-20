using Microsoft.AspNetCore.Mvc;

namespace CoreBase.Interfaces.ControllerInterfaces;

public interface IDeleteController<TDeleteReq>
{
    Task<IActionResult> Delete([FromBody] TDeleteReq deleteRequest);
}
