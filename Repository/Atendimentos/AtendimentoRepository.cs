using Hospital.Database;
using Hospital.Dtos.Input.Atendimentos;
using Hospital.Dtos.Output.Atendimentos;
using Hospital.Models.Atendimento;
using Hospital.Repository.Atendimentos.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.Atendimentos;
public class AtendimentoRepository<T, TOut, TQuery>
: IAtendimentoRepository<T, TOut, TQuery>
    where T : Atendimento, new()
    where TOut : AtendimentoOutputDto
    where TQuery : AtendimentoGetByQueryDto
{
    private readonly AppDbContext _ctx;
    private readonly UnitOfWork _uow;
    public AtendimentoRepository(
        AppDbContext context,
        UnitOfWork uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public async Task<Guid> CreateAsync(T etity)
    {
        try
        {
            var result = await _ctx.Set<T>().AddAsync(etity);
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
            var result = await _ctx.Set<T>()
                .FirstOrDefaultAsync(e => e.Id == id);
            return result;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public Task<TOut?> GetByIdDtoAsync(Guid id)
    {
        throw new NotImplementedException();
        /* try */
        /* { */
        /*     var result = await _ctx.Set<T>() */
        /*         .Select(e => TOut.Create(e)) */
        /*         .Where(e => e.Id == id) */
        /*         .FirstOrDefaultAsync(); */
        /*     return (TOut?)result; */
        /* } */
        /* catch (Exception error) */
        /* { */
        /*     _uow.Dispose(); */
        /*     throw new Exception(error.Message); */
        /* } */
    }

    public async Task UpdateAsync(T entity)
    {
        try
        {
            _ctx.Set<T>().Update(entity);
            await _ctx.SaveChangesAsync();
            return;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public List<TOut> GetByQueryDto(
        TQuery query)
    {
        throw new NotImplementedException();
    }

    /* public List<T> GetByQueryDto( */
    /*     TQuery query) */
    /* { */
    /*     try */
    /*     { */
    /*         var queryList = _ctx.Set<T>().AsQueryable(); */
    /*         if (query.MedicoId != null) */
    /*             queryList = queryList.Where(e => */
    /*                 e.MedicoId == query.MedicoId); */

    /*         if (query.PacienteId != null) */
    /*             queryList = queryList.Where(e => */
    /*                 e.PacienteId == query.PacienteId); */

    /*         if (query.MinDate != null) */
    /*             queryList = queryList.Where( */
    /*                 e => e.Inicio >= query.MinDate */
    /*                 && e.Inicio <= query.MaxDate); */

    /*         var result = queryList */
    /*             .Skip((int)query.Page!) */
    /*             .Take((int)query.Limit!) */
    /*             .ToList(); */

    /*         return result; */
    /*     } */
    /*     catch (Exception error) */
    /*     { */
    /*         _uow.Dispose(); */
    /*         throw new Exception(error.Message); */
    /*     } */
    /* } */
}