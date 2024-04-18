using Hospital.Controllers.Generics;
using Hospital.Dto.Atendimento.Create;
using Hospital.Dto.Atendimento.Update;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Service.Atendimentos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers.Retornos;
[ApiController]
[Route("api/[controller]")]
public class RetornoController
: GenericAtendimentoController<
    Retorno,
    RetornoAgendamento,
    RetornoCreationDto,
    RetornoUpdateDto>
{
    public RetornoController(
        IRetornoService service)
        : base(service)
    { }
}
