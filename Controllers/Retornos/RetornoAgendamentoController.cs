using Hospital.Controllers.Generics;
using Hospital.Dto.Atendimento.Create;
using Hospital.Dto.Atendimento.Update;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Service.Agendamentos.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Retornos;
[ApiController]
[Route("api/Agendamento/Retorno")]
public class RetornoAgendamentoController
: GenericAgendamentoController<
    Retorno,
    RetornoAgendamento,
    RetornoCreationDto,
    RetornoUpdateDto>
{
    public RetornoAgendamentoController(
        IRetornoAgendamentoService service,
        ILogger<GenericAgendamentoController<Retorno, RetornoAgendamento, RetornoCreationDto, RetornoUpdateDto>> logger)
        : base(service, logger)
    { }
}