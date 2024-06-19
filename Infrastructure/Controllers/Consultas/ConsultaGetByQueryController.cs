using Hospital.Application.Consts;
using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Application.UseCases.Atendimentos;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Infrastructure.Controllers.Consultas;
[ApiController]
[Route("api/Atendimentos/Consulta")]
[Tags("Consulta")]
public class ConsultaGetByQueryController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = PoliciesConsts.Operational)]
    public async Task<IActionResult> Execute(
        [FromServices] ConsultaGetByQueryUseCase _service,
        [FromQuery]  ConsultaGetByQueryDto query)
    {
        var response = await _service.Handler(query);
        return Ok(response);
    }
}