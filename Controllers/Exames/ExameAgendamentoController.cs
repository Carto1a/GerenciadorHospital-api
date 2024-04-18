using Hospital.Controllers.Generics;
using Hospital.Dto.Atendimento.Create;
using Hospital.Dto.Atendimento.Update;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Service.Agendamentos.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Exames;
[ApiController]
[Route("api/Agendamento/Exame")]
public class ExameAgendamentoController
: GenericAgendamentoController<
    Exame,
    ExameAgendamento,
    ExameCreationDto,
    ExameUpdateDto>
{
    public ExameAgendamentoController(
        IExameAgendamentoService service,
        ILogger<GenericAgendamentoController<Exame, ExameAgendamento, ExameCreationDto, ExameUpdateDto>> logger)
        : base(service, logger)
    {
    }
}