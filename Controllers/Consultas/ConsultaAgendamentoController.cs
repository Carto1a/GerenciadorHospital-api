using Hospital.Controllers.Generics;
using Hospital.Dto.Atendimento.Create;
using Hospital.Dto.Atendimento.Update;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Service.Agendamentos.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Consultas;

[ApiController]
[Route("api/Agendamento/Consulta")]
public class ConsultaAgendamentoController
: GenericAgendamentoController<
    Consulta,
    ConsultaAgendamento,
    ConsultaCreationDto,
    ConsultaUpdateDto>
{
    public ConsultaAgendamentoController(
        IConsultaAgendamentoService service,
        ILogger<GenericAgendamentoController<Consulta, ConsultaAgendamento, ConsultaCreationDto, ConsultaUpdateDto>> logger)
        : base(service, logger)
    {
    }
}