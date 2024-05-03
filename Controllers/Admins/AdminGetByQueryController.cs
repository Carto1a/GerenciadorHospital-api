using Hospital.Dtos.Input.Authentications;
using Hospital.Services.Cadastros.Admins;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Admins;
[ApiController]
[Route("api/Admin")]
[Tags("Admin")]
public class AdminGetByQueryController
: ControllerBase
{
    private readonly AdminGetByQueryService _service;
    public AdminGetByQueryController(
        AdminGetByQueryService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Execute(
        [FromQuery] AdminGetByQueryDto query)
    {
        var admins = _service.Handler(query);
        return Ok(admins);
    }
}