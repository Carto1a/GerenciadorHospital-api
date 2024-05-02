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

    public List<Medicamento> GetMedicamentos(
        MedicamentoGetByQueryDto request)
    {
        throw new NotImplementedException();
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