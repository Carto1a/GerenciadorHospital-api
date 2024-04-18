using Hospital.Dto.Atendimento.Create;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;

namespace Hospital.Service.Atendimentos.Interfaces;
public interface IRetornoService
: IAtendimentoService<Retorno, RetornoAgendamento, RetornoCreationDto>
{
}
