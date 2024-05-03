using Hospital.Dtos.Input.Agendamentos;
using Hospital.Dtos.Output.Agendamentos;
using Hospital.Enums;
using Hospital.Models.Agendamentos;
using Hospital.Models.Atendimento;
using Hospital.Repository;

namespace Hospital.Services.Agendamentos;
public class AgendamentoGetByQueryService<T, TAgendamento, TQuery>
where T : Atendimento, new()
where TAgendamento : Agendamento, new()
where TQuery : AgendamentoGetByQueryDto
{
    private readonly UnitOfWork _uow;
    public AgendamentoGetByQueryService(UnitOfWork unitOfWork)
    {
        _uow = unitOfWork;
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

        var agendamentos = await _uow.SetAgendamento<T, TAgendamento>()!
            .GetByQueryDtoAsync(query);

        return agendamentos;
    }
}