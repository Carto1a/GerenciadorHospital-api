using Hospital.Dto.Atividades;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Generics.Interfaces;
using Hospital.Service.Generics.Interfaces;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ConsultaController :
    GenericAtendimentoController<Consulta, ConsultaAgendamento, ConsultaCreationDto>
{
    public ConsultaController(
        IGenericAtendimentoService<Consulta, ConsultaAgendamento, ConsultaCreationDto> service,
        IGenericAtendimentoRepository<Consulta, ConsultaAgendamento> repository)
        : base(service, repository)
    {}
}
