using Hospital.Database;
using Hospital.Dtos.Output.Medicamentos;
using Hospital.Models.Medicamentos;
using Hospital.Repository.MedicamentoLotes.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.MedicamentoLotes;
public class MedicamentoLoteRepository
: IMedicamentoLoteRepository
{
    private readonly AppDbContext _context;
    private readonly UnitOfWork _uow;
    public MedicamentoLoteRepository(
        AppDbContext context,
        UnitOfWork uow)
    {
        _context = context;
        _uow = uow;
    }

    public Guid CreateMedicamentoLote(
        MedicamentoLote medicamentoLote)
    {
        try
        {
            var entity = _context.MedicamentoLotes.Add(
                medicamentoLote);
            return entity.Entity.Id;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public MedicamentoLote? GetMedicamentoLoteByCodigo(string codigo)
    {
        try
        {
            return _context.MedicamentoLotes
                .FirstOrDefault(x => x.Codigo == codigo);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
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

    public MedicamentoLoteOutputDto? GetMedicamentoLoteByCodigoDto(string codigo)
    {
        throw new NotImplementedException();
    }

    public MedicamentoLote? GetMedicamentoLoteById(Guid id)
    {
        try
        {
            return _context.MedicamentoLotes.Find(id);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public MedicamentoLoteOutputDto? GetMedicamentoLoteByIdDto(
        Guid id)
    {
        try
        {
            return _context.MedicamentoLotes
                .Where(x => x.Id == id)
                .Select(x => new MedicamentoLoteOutputDto(x))
                .FirstOrDefault();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public void UpdateMedicamentoLote(MedicamentoLote medicamentoLote)
    {
        try
        {
            _context.MedicamentoLotes.Update(medicamentoLote);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}