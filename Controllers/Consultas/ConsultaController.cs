using Hospital.Controllers.Generics;
using Hospital.Dto.Atendimento.Create;
using Hospital.Dto.Atendimento.Update;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Service.Atendimentos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Consultas;
[ApiController]
[Route("api/[controller]")]
public class ConsultaController
: GenericAtendimentoController<
    Consulta,
    ConsultaAgendamento,
    ConsultaCreationDto,
    ConsultaUpdateDto>
{
    public ConsultaController(
        IConsultaService service)
        : base(service)
    { }
}
