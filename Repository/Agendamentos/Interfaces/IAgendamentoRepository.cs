using Hospital.Dtos.Input.Agendamentos;
using Hospital.Dtos.Output.Agendamentos;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;

namespace Hospital.Repository.Agendamentos.Interfaces;
public interface IAgendamentoRepository<T, TAgendamento>
    where T : Atendimento
    where TAgendamento : Agendamento
{
    Task<Guid> CreateAsync(TAgendamento agentamento);
    Task UpdateAsync(TAgendamento NovoAgendamento);
    Task<TAgendamento?> GetByIdAsync(Guid id);
    AgendamentoOutputDto? GetByIdDto(Guid id);
    Task<List<TAgendamento>> GetByDataHoraMedicoAsync(DateTime dataHora, Guid medicoId);
    Task<List<AgendamentoOutputDto>> GetByQueryDtoAsync(AgendamentoGetByQueryDto query);
}