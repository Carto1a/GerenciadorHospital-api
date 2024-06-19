using Hospital.Application.Dto.Input.Medicamentos;
using Hospital.Application.Dto.Output.Medicamentos;
using Hospital.Domain.Entities.Medicamentos;
using Hospital.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database.Repositories.Medicamentos;
public class MedicamentoRepository : Repository<Medicamento, MedicamentoGetByQueryDto, MedicamentoOutputDto>,
IMedicamentoRepository
{
    private readonly AppDbContext _ctx;
    private readonly IUnitOfWork _uow;
    public MedicamentoRepository(
        AppDbContext context,
        IUnitOfWork uow) : base(context, uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public async Task<Guid> CreateAsync(
        Medicamento medicamento)
    {
        try
        {
            var entity = await _ctx.Medicamentos.AddAsync(medicamento);
            return entity.Entity.Id;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public override Task<List<MedicamentoOutputDto>> GetByQueryDtoAsync(
        MedicamentoGetByQueryDto query)
    {
        try
        {
            var queryCtx = _ctx.Medicamentos.AsQueryable();
            if (query.MinDateCriado != null)
                queryCtx = queryCtx
                    .Where(e => e.Criado >= query.MinDateCriado);

            if (query.MaxDateCriado != null)
                queryCtx = queryCtx
                    .Where(e => e.Criado <= query.MaxDateCriado);

            if (query.Quantidade != null)
                queryCtx = queryCtx
                    .Where(e => e.Quantidade == query.Quantidade);

            if (query.QuantidadeMin != null)
                queryCtx = queryCtx
                    .Where(e => e.Quantidade >= query.QuantidadeMin);

            if (query.PrincipioAtivo != null)
                queryCtx = queryCtx
                    .Where(e => e.PrincipioAtivo == query.PrincipioAtivo);

            if (query.Status != null)
                queryCtx = queryCtx
                    .Where(e => e.Status == query.Status);

            var result = queryCtx
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .Select(e => new MedicamentoOutputDto(e));

            return result.ToListAsync();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}