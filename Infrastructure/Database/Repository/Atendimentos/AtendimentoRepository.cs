using Hospital.Database;
using Hospital.Dtos.Input.Atendimentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.Atendimentos;
public class AtendimentoRepository<T>
: IAtendimentoRepository<T>
    where T : Atendimento, new()
{
    private readonly ILogger<AtendimentoRepository<T>> _logger;
    private readonly UnitOfWork _uow;
    private readonly AppDbContext _ctx;
    public AtendimentoRepository(
        AppDbContext context,
        ILogger<AtendimentoRepository<T>> logger,
        UnitOfWork uow)
    {
        _ctx = context;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into AtendimentoRepository {nameof(T)}");
        _uow = uow;
    }

    public async Task<Guid> Create(T entity)
    {
        try
        {
            var result = await _ctx.Set<T>().AddAsync(entity);
            await _ctx.SaveChangesAsync();
            return result.Entity.Id;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        try
        {
            var list = await _ctx.Set<T>()
                .FirstOrDefaultAsync(e => e.Id == id);

            return list;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public List<T> GetByQueryDtoAsync(
        AtendimentoGetByQueryDto query)
    {
        try
        {
            var queryList = _ctx.Set<T>().AsQueryable();
            if (query.MedicoId != null)
                queryList = queryList.Where(e =>
                    e.MedicoId == query.MedicoId);

            if (query.PacienteId != null)
                queryList = queryList.Where(e =>
                    e.PacienteId == query.PacienteId);

            if (query.MinDateCriado != null && query.MaxDateCriado != null)
                queryList = queryList.Where(
                    e => e.Inicio >= query.MinDateCriado
                    && e.Inicio <= query.MaxDateCriado);

            var result = queryList
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .ToList();

            return result;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public async Task Update(T entity)
    {
        try
        {
            _ctx.Set<T>().Update(entity);
            await _ctx.SaveChangesAsync();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}