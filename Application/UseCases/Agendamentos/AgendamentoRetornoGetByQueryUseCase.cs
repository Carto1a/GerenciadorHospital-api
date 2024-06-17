using Hospital.Dtos.Input.Agendamentos;
using Hospital.Dtos.Output.Agendamentos;
using Hospital.Enums;
using Hospital.Repository.Atendimentos.Interfaces;

namespace Hospital.Services.Agendamentos;
public class AgendamentoRetornoGetByQueryService
{
    private readonly IRetornoAgendamentoRepository _retornoAgendamentoRepository;
    public AgendamentoRetornoGetByQueryService(
        IRetornoAgendamentoRepository retornoAgendamentoRepository)
    {
        _retornoAgendamentoRepository = retornoAgendamentoRepository;
    }

    public async Task<IEnumerable<AgendamentoOutputDto>> Handler(
        AgendamentoGetByQueryDto request)
    {
        var validator = new Validators("Não foi possível buscar agendamentos");
        validator.Query((int)request.Limit!, (int)request.Page!);

        if (request.Status != null)
            validator.isInEnum(
                request.Status,
                typeof(AgendamentoStatus),
                "Status inválido");

        validator.Check();

        var agendamento = await _retornoAgendamentoRepository
            .GetByQueryDtoAsync(request);
        return agendamento;
    }
}