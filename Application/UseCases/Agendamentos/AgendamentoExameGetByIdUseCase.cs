using Hospital.Application.Dto.Output.Agendamentos;
using Hospital.Domain.Repositories.Agendamentos;

namespace Hospital.Application.UseCases.Agendamentos;
public class AgendamentoExameGetByIdUseCase
{
    private readonly IExameAgendamentoRepository _repository;
    public AgendamentoExameGetByIdUseCase(IExameAgendamentoRepository repository)
    {
        _repository = repository;
    }

    public async Task<AgendamentoExameOutputDto?> Handler(Guid id)
    {
        var agendamento = await _repository.GetByIdDtoAsync(id);
        return agendamento;
    }
}