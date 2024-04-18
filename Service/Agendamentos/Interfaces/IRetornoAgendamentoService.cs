using Hospital.Dto.Atendimento.Create;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;

namespace Hospital.Service.Agendamentos.Interfaces;
public interface IRetornoAgendamentoService
: IAgendamentoService<Retorno, RetornoAgendamento, RetornoCreationDto>
{
}