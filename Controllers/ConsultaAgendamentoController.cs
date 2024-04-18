using Hospital.Controllers.Generics;
using Hospital.Dto.Atividades;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Service.Generics.Interfaces;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers;
[ApiController]
[Route("api/Agendamento/Consulta")]
public class ConsultaAgendamentoController :
    GenericAgendamentoController<Consulta, ConsultaAgendamento, ConsultaCreationDto>
{
    public ConsultaAgendamentoController(IGenericAtendimentoService<Consulta, ConsultaAgendamento, ConsultaCreationDto> service)
        : base(service)
    {
    }
}
