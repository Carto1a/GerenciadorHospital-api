using Hospital.Dtos.Input.Agendamentos;
using Hospital.Dtos.Output.Agendamentos;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;

namespace Hospital.Repository.Agendamentos.Interfaces;
public interface IAgendamentoRepository<T, TAgendamento, OutputDto>
    where T : Atendimento
    where TAgendamento : Agendamento
    where OutputDto : AgendamentoOutputDto
{
    Task<Guid> CreateAsync(TAgendamento agentamento);
    Task UpdateAsync(TAgendamento NovoAgendamento);
    Task<TAgendamento?> GetByIdAsync(Guid id);
    OutputDto? GetByIdDto(Guid id);
    Task<List<TAgendamento>> GetByDataHoraMedicoAsync(DateTime dataHora, Guid medicoId);
    Task<List<AgendamentoOutputDto>> GetByQueryDtoAsync(AgendamentoGetByQueryDto query);
}