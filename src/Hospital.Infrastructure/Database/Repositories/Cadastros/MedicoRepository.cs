using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.Dto.Output.Cadastros;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Cadastros;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database.Repositories.Cadastros;
public class MedicoRepository : CadastroRepository<Medico, MedicoGetByQueryDto, MedicoOutputDto>,
IMedicoRepository
{
    protected readonly AppDbContext _ctx;
    private readonly IUnitOfWork _uow;

    public MedicoRepository(
        AppDbContext context,
        IUnitOfWork uow) : base(context, uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public Task<Medico?> GetByCRMAsync(int crm)
    {
        try
        {
            return _ctx.Medicos
                .FirstOrDefaultAsync(e => e.CRM == crm);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public Task<Medico?> GetByCPFAsync(string cpf)
    {
        try
        {
            return _ctx.Medicos
                .FirstOrDefaultAsync(e => e.CPF == cpf);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public override Task<List<MedicoOutputDto>> GetByQueryDtoAsync(
        MedicoGetByQueryDto query)
    {
        try
        {
            var queryCtx = _ctx.Medicos.AsQueryable();
            if (query.Especialidade != null)
                queryCtx = queryCtx.Where(x =>
                    x.Especialidade == query.Especialidade);

            if (query.Ativo != null)
                queryCtx = queryCtx.Where(x =>
                    x.Ativo == query.Ativo);

            if (query.MinDateNasc != null)
                queryCtx = queryCtx.Where(x =>
                    x.DataNascimento >= DateOnly.FromDateTime(
                        (DateTime)query.MinDateNasc));

            if (query.MaxDateNasc != null)
                queryCtx = queryCtx.Where(x =>
                    x.DataNascimento <= DateOnly.FromDateTime(
                        (DateTime)query.MaxDateNasc));

            if (query.Genero != null)
                queryCtx = queryCtx.Where(x =>
                    x.Genero == query.Genero);

            var result = queryCtx
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .Select(x => new MedicoOutputDto(x));

            return result.ToListAsync();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}