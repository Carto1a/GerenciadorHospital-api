using Hospital.Database;
using Hospital.Dtos.Input.Atendimentos;
using Hospital.Dtos.Output.Atendimentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;


namespace Hospital.Repository.Atendimentos;
public class ConsultaRepository
: AtendimentoRepository<
    Consulta,
    AtendimentoOutputDto,
    AtendimentoGetByQueryDto>,
IConsultaRepository
{
    private readonly AppDbContext _ctx;
    private readonly UnitOfWork _uow;
    public ConsultaRepository(
        AppDbContext context,
        UnitOfWork uow)
    : base(context, uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public new List<AtendimentoOutputDto> GetByQueryDto(
        AtendimentoGetByQueryDto query)
    {
        var queryable = _ctx.Consultas.AsQueryable();
        if (query.MinDateCriado != null)
            queryable = queryable
                .Where(e => e.Criado >= query.MinDateCriado);

        if (query.MaxDateCriado != null)
            queryable = queryable
                .Where(e => e.Criado <= query.MaxDateCriado);

        if (query.MedicoId != null)
            queryable = queryable
                .Where(e => e.MedicoId == query.MedicoId);

        if (query.PacienteId != null)
            queryable = queryable
                .Where(e => e.PacienteId == query.PacienteId);

        if (query.ConvenioId != null)
            queryable = queryable
                .Where(e => e.ConvenioId == query.ConvenioId);

        var result = queryable
            .Skip((int)query.Page!)
            .Take((int)query.Limit!)
            .Select(e => new AtendimentoOutputDto(e))
            .ToList();

        return result;
    }
}