using Hospital.Application.Dto.Input.Medicamentos;
using Hospital.Application.Dto.Output.Medicamentos;
using Hospital.Domain.Entities.Medicamentos;
using Hospital.Domain.Enums;
using Hospital.Domain.Repositories;
using Hospital.Infrastructure.Database;
using Hospital.Infrastructure.Database.Repositories;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.MedicamentoLotes;
public class MedicamentoLoteRepository : Repository<MedicamentoLote, MedicamentoLoteGetByQueryDto, MedicamentoLoteOutputDto>,
IMedicamentoLoteRepository
{
    private readonly AppDbContext _context;
    private readonly IUnitOfWork _uow;
    public MedicamentoLoteRepository(
        AppDbContext context,
        UnitOfWork uow) : base(context, uow)
    {
        _context = context;
        _uow = uow;
    }

    public async Task<Guid> CreateAsync(
        MedicamentoLote medicamentoLote)
    {
        try
        {
            var entity = await _context.MedicamentoLotes.AddAsync(
                medicamentoLote);
            return entity.Entity.Id;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public Task<MedicamentoLote?> GetByCodigoAsync(string codigo)
    {
        try
        {
            return _context.MedicamentoLotes
                .FirstOrDefaultAsync(x => x.Codigo == codigo);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public Task<MedicamentoLote?> GetByCodigoByMedicamentoIdAsync(string codigo, Guid medicamentoId)
    {
        throw new NotImplementedException();
    }

    public Task<MedicamentoLoteOutputDto?> GetByCodigoDtoAsync(string codigo)
    {
        throw new NotImplementedException();
    }

    public MedicamentoLote? GetMedicamentoLoteByCodigoByMedicamentoId(
        string codigo, Guid medicamentoId)
    {
        try
        {
            var query = _context.MedicamentoLotes
                .Where(x => x.Codigo == codigo)
                .Where(x => x.MedicamentoId == medicamentoId);

            var queryString = query.ToQueryString();
            return query.FirstOrDefault();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public override Task<List<MedicamentoLoteOutputDto>> GetByQueryDtoAsync(MedicamentoLoteGetByQueryDto query)
    {
        try
        {
            var queryCtx = _context.MedicamentoLotes.AsQueryable();
            if (query.MedicamentoId != null)
                queryCtx = queryCtx
                    .Where(e => e.MedicamentoId == query.MedicamentoId);

            if (query.MinDateFabricacao != null)
                queryCtx = queryCtx
                    .Where(e => e.DataFabricacao >= DateOnly
                        .FromDateTime((DateTime)query.MinDateFabricacao));

            if (query.MaxDateFabricacao != null)
                queryCtx = queryCtx
                    .Where(e => e.DataFabricacao <= DateOnly
                        .FromDateTime((DateTime)query.MaxDateFabricacao));

            if (query.MinDateVencimento != null)
                queryCtx = queryCtx
                    .Where(e => e.DataVencimento >= DateOnly
                        .FromDateTime((DateTime)query.MinDateVencimento));

            if (query.MaxDateVencimento != null)
                queryCtx = queryCtx
                    .Where(e => e.DataVencimento <= DateOnly
                        .FromDateTime((DateTime)query.MaxDateVencimento));

            if (query.MinDateCriado != null)
                queryCtx = queryCtx
                    .Where(e => e.DataCadastro >= query.MinDateCriado);

            if (query.MaxDateCriado != null)
                queryCtx = queryCtx
                    .Where(e => e.DataCadastro <= query.MaxDateCriado);

            if (query.Fabricante != null)
                queryCtx = queryCtx
                    .Where(e => e.Fabricante == query.Fabricante);

            if (query.QuantidadeDisponivel != null)
                queryCtx = queryCtx
                    .Where(e => e.QuantidadeDisponivel == query.QuantidadeDisponivel);

            if (query.Quantidade != null)
                queryCtx = queryCtx
                    .Where(e => e.Quantidade == query.Quantidade);

            if (query.PrecoUnitario != null)
                queryCtx = queryCtx
                    .Where(e => e.PrecoUnitario == query.PrecoUnitario);

            if (query.Status is not null)
                queryCtx = queryCtx
                    .Where(e => e.Status == (MedicamentoLoteStatus)query.Status);

            var result = queryCtx
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .Select(e => new MedicamentoLoteOutputDto(e));

            return result.ToListAsync();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}