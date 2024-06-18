using Hospital.Database;
using Hospital.Dtos.Input.Medicamentos;
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

    public List<MedicamentoLoteOutputDto> GetMedicamentoLotesByQueryDto(MedicamentoLoteGetByQueryDto query)
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

            if (query.MinDateCadastro != null)
                queryCtx = queryCtx
                    .Where(e => e.DataCadastro >= query.MinDateCadastro);

            if (query.MaxDateCadastro != null)
                queryCtx = queryCtx
                    .Where(e => e.DataCadastro <= query.MaxDateCadastro);

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

            if (query.Status != null)
                queryCtx = queryCtx
                    .Where(e => e.Status == query.Status);

            var result = queryCtx
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .Select(e => new MedicamentoLoteOutputDto(e))
                .ToList();

            return result;
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