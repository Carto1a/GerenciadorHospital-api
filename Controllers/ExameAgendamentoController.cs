using Hospital.Controllers.Generics;
using Hospital.Dto.Atividades;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Service.Generics.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers;
[ApiController]
[Route("api/Agendamento/Exame")]
public class ExameAgendamentoController :
    GenericAgendamentoController<Exame, ExameAgendamento, ExameCreationDto>
{
    public ExameAgendamentoController(IGenericAtendimentoService<Exame, ExameAgendamento, ExameCreationDto> service)
        : base(service)
    {
    }
}
