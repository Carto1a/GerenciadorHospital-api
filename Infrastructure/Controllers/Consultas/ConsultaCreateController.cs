using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Application.UseCases.Atendimentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Consultas;
[ApiController]
[Route("api/Atendimentos/Consulta")]
[Tags("Consulta")]
public class ConsultaCreateController : ControllerBase
{
    [HttpPost]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] ConsultaCreateUseCase _service,
        [FromBody] ConsultaCreateDto request)
    {
        var response = await _service.Handler(request);
        return Ok(response);
    }
}