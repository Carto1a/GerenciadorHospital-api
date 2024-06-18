using Hospital.Database;
using Hospital.Dtos.Input.Medicamentos;
using Hospital.Dtos.Output.Medicamentos;
using Hospital.Models.Medicamentos;
using Hospital.Repository.Medicamentos.Interfaces;

namespace Hospital.Repository.Medicamentos;
public class MedicamentoRepository
: IMedicamentoRepository
{
    private readonly AppDbContext _ctx;
    private readonly UnitOfWork _uow;
    public MedicamentoRepository(
        AppDbContext context,
        UnitOfWork uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public async Task<Guid> CreateMedicamentoAsync(
        Medicamento medicamento)
    {
        try
        {
            var entity = _ctx.Medicamentos.Add(medicamento);
            await _ctx.SaveChangesAsync();
            return entity.Entity.Id;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public void DesativarMedicamento(Guid id)
    {
        throw new NotImplementedException();
    }

    public Medicamento? GetMedicamentoById(Guid id)
    {
        try
        {
            return _ctx.Medicamentos
                .FirstOrDefault(e => e.Id == id);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public MedicamentoOutputDto? GetMedicamentoByIdDto(Guid id)
    {
        try
        {
            return _ctx.Medicamentos
                .Where(e => e.Id == id)
                .Select(e => new MedicamentoOutputDto(e))
                .FirstOrDefault();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public List<MedicamentoOutputDto> GetMedicamentosByQueryDto(
        MedicamentoGetByQueryDto query)
    {
        try
        {
            var queryCtx = _ctx.Medicamentos.AsQueryable();
            if (query.MinDate != null)
                queryCtx = queryCtx
                    .Where(e => e.Criado >= query.MinDate);

            if (query.MaxDate != null)
                queryCtx = queryCtx
                    .Where(e => e.Criado <= query.MaxDate);

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
                .Select(e => new MedicamentoOutputDto(e))
                .ToList();

            return result;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public void UpdateMedicamento(
        Medicamento medicamento)
    {
        try
        {
            _ctx.Medicamentos.Update(medicamento);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}