using Hospital.Application.Dto.Input.Agendamentos;
using Hospital.Application.Dto.Output.Agendamentos;
using Hospital.Domain.Enums;
using Hospital.Domain.Repositories.Agendamentos;
using Hospital.Domain.Validators;

namespace Hospital.Application.UseCases.Agendamentos;
public class AgendamentoConsultaGetByQueryUseCase
{
    private readonly IConsultaAgendamentoRepository _consultaAgendamentoRepository;
    public AgendamentoConsultaGetByQueryUseCase(
        IConsultaAgendamentoRepository consultaAgendamentoRepository)
    {
        _consultaAgendamentoRepository = consultaAgendamentoRepository;
    }

    public async Task<IEnumerable<AgendamentoConsultaOutputDto>> Handler(
        AgendamentoConsultaGetByQuery request)
    {
        var validator = new DomainValidator("Não foi possível buscar agendamentos");
        validator.Query((int)request.Limit!, (int)request.Page!);

        if (request.Status != null)
            validator.isInEnum(
                request.Status,
                typeof(AgendamentoStatus),
                "Status inválido");

        validator.Check();

        var agendamento = await _consultaAgendamentoRepository
            .GetByQueryDtoAsync(request);
        return agendamento;
    }
}