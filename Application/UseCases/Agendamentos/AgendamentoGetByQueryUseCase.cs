using Hospital.Dtos.Input.Agendamentos;
using Hospital.Dtos.Output.Agendamentos;
using Hospital.Enums;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Repository;
using Hospital.Repository.Atendimentos.Interfaces;

namespace Hospital.Services.Agendamentos;
public class AgendamentoConsultaGetByQueryService<T, TAgendamento, TQuery>
where T : Atendimento, new()
where TAgendamento : Agendamento, new()
where TQuery : AgendamentoGetByQueryDto
{
    private readonly UnitOfWork _uow;
    private readonly IConsultaAgendamentoRepository _consultaAgendamentoRepository;
    public AgendamentoConsultaGetByQueryService(
        UnitOfWork uow,
        IConsultaAgendamentoRepository consultaAgendamentoRepository)
    {
        _uow = uow;
        _consultaAgendamentoRepository = consultaAgendamentoRepository;
    }

    public async Task<List<AgendamentoOutputDto>> Handler(
        TQuery query)
    {
        var validator = new Validators(
            "Não foi possível buscar agendamentos");
        validator.Query((int)query.Limit!, (int)query.Page!);

        if (query.Status != null)
            validator.isInEnum(
                query.Status,
                typeof(AgendamentoStatus),
                "Status inválido");

        // NOTE: break code execution if validation fails
        validator.Check();

        var agendamentos = await _consultaAgendamentoRepository
            .GetByQueryDtoAsync(query);

        return agendamentos;
    }
}