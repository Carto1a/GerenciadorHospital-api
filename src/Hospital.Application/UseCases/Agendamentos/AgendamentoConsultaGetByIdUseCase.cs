using Hospital.Application.Dto.Output.Agendamentos;
using Hospital.Domain.Repositories.Agendamentos;

namespace Hospital.Application.UseCases.Agendamentos;
public class AgendamentoConsultaGetByIdUseCase
{
    private readonly IConsultaAgendamentoRepository _repository;
    public AgendamentoConsultaGetByIdUseCase(IConsultaAgendamentoRepository repository)
    {
        _repository = repository;
    }

    public async Task<AgendamentoConsultaOutputDto> Handler(Guid id)
    {
        var agendamento = await _repository.GetByIdDtoAsync(id);
        return agendamento;
    }
}