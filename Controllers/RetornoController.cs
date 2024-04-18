using Hospital.Dto.Atividades;
using Hospital.Models;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Generics.Interfaces;
using Hospital.Service.Generics.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RetornoController :
    GenericAtendimentoController<Retorno, RetornoAgendamento, RetornoCreationDto>
{
    public RetornoController(IGenericAtendimentoService<Retorno, RetornoAgendamento, RetornoCreationDto> service,
        IGenericAtendimentoRepository<Retorno, RetornoAgendamento> repository)
        : base(service, repository)
    { }
}
