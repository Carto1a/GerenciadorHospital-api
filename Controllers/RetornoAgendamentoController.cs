using Hospital.Controllers.Generics;
using Hospital.Dto.Atividades;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Service.Generics.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers;
[ApiController]
[Route("api/Agendamento/Retorno")]
public class RetornoAgendamentoController :
    GenericAgendamentoController<Retorno, RetornoAgendamento, RetornoCreationDto>
{
    public RetornoAgendamentoController(IGenericAtendimentoService<Retorno, RetornoAgendamento, RetornoCreationDto> service)
        : base(service)
    { }
}
