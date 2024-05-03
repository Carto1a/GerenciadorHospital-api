using Hospital.Controllers.Generics.Agendamentos;
using Hospital.Dtos.Input.Agendamentos;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Services.Agendamentos;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Consultas;
[ApiController]
[Route("api/Agendamentos/Consultas")]
[Tags("Agendamentos/Consultas")]
public class ConsultaAgendamentoCreateController
: GenericAgendamentoCreateController<
    Consulta,
    ConsultaAgendamento,
    AgendamentoCreateDto>
{
    public ConsultaAgendamentoCreateController(
        AgendamentoCreateService<
            Consulta,
            ConsultaAgendamento,
            AgendamentoCreateDto> service)
    : base(service) { }
}