using Hospital.Dtos.Input.Agendamentos;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Services.Agendamentos;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Generics.Agendamentos;
[ApiController]
[Route("api/Agendamentos/Consultas")]
[Tags("Agendamentos/Consultas")]
public class ConsultaAgendamentoGetByQueryController
: GenericAgendamentoGetByQueryController<
    Consulta,
    ConsultaAgendamento,
    AgendamentoGetByQueryDto>
{
    public ConsultaAgendamentoGetByQueryController(
        AgendamentoGetByQueryService<
            Consulta,
            ConsultaAgendamento,
            AgendamentoGetByQueryDto> service)
    : base(service)
    { }
}