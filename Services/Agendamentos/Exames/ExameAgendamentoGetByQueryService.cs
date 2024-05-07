using Hospital.Database;
using Hospital.Dtos.Input.Agendamentos;
using Hospital.Dtos.Output.Agendamentos;
using Hospital.Repository;

namespace Hospital.Services.Agendamentos.Exames;
public class ExameAgendamentoGetByQueryService
{
    private readonly UnitOfWork _uow;
    public ExameAgendamentoGetByQueryService(
        AppDbContext context,
        UnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<AgendamentoOutputDto>> Handler(
        ExameAgendamentoGetByQueryDto request)
    {
        var repo = _uow.ExameAgendamentoRepository;
        var validator = new Validators("Não foi possível buscar exames");
        validator.Query((int)request.Limit!, (int)request.Page!);

        validator.Check();

        var result = await repo.GetByQueryDtoAsync(request);
        return result;
    }
}