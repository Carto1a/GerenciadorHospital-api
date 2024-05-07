using Hospital.Dtos.Input.Agendamentos;
using Hospital.Dtos.Output.Agendamentos;
using Hospital.Repository;

namespace Hospital.Services.Agendamentos.Consultas;
public class ConsultaAgendamentoGetByQueryService
{
    private readonly UnitOfWork _uow;
    public ConsultaAgendamentoGetByQueryService(
        UnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<AgendamentoOutputDto>> Handler(
        AgendamentoGetByQueryDto request)
    {
        var repo = _uow.ConsultaAgendamentoRepository;
        var validator = new Validators("Não foi possível buscar consultas");
        validator.Query((int)request.Limit!, (int)request.Page!);

        validator.Check();

        var result = await repo.GetByQueryDtoAsync(request);
        return result;
    }
}