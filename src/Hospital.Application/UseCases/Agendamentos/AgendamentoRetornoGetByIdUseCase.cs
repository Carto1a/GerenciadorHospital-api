using Hospital.Application.Dto.Output.Agendamentos;
using Hospital.Domain.Repositories.Agendamentos;

namespace Hospital.Application.UseCases.Agendamentos;
public class AgendamentoRetornoGetByIdUseCase
{
    private readonly IRetornoAgendamentoRepository _repository;
    public AgendamentoRetornoGetByIdUseCase(IRetornoAgendamentoRepository repository)
    {
        _repository = repository;
    }

    public async Task<AgendamentoRetornoOutputDto?> Handler(Guid id)
    {
        var agendamento = await _repository.GetByIdDtoAsync(id);
        return agendamento;
    }
}