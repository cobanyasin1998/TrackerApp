using Microsoft.AspNetCore.Mvc;

namespace CoreBase.Interfaces.ControllerInterfaces;


public interface IGetAllController<TGetAllReq>
{
    Task<IActionResult> GetAll([FromBody] TGetAllReq request);
}
