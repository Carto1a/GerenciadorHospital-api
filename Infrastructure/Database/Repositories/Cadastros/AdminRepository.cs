using Hospital.Application.Dto.Input.Authentications;
using Hospital.Application.Dto.Output.Cadastros;
using Hospital.Domain.Entities.Cadastros;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Cadastros;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database.Repositories.Cadastros;
public class AdminRepository : CadastroRepository<Admin, AdminGetByQueryDto, AdminOutputDto>,
IAdminRepository
{
    private readonly AppDbContext _ctx;
    private readonly IUnitOfWork _uow;
    public AdminRepository(
        AppDbContext context,
        IUnitOfWork uow) : base(context, uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public override Task<List<AdminOutputDto>> GetByQueryDtoAsync(
        AdminGetByQueryDto query)
    {
        try
        {
            var queryCtx = _ctx.Admins.AsQueryable();
            if (query.Ativo != null)
                queryCtx = queryCtx.Where(e => e.Ativo == query.Ativo);

            if (query.MinDateNasc != null)
                queryCtx = queryCtx.Where(e => e.DataNascimento >= DateOnly
                    .FromDateTime((DateTime)query.MinDateNasc));

            if (query.MaxDateNasc != null)
                queryCtx = queryCtx.Where(e => e.DataNascimento <= DateOnly
                    .FromDateTime((DateTime)query.MaxDateNasc));

            if (query.Genero != null)
                queryCtx = queryCtx.Where(e => e.Genero == query.Genero);

            var result = queryCtx
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .Select(e => new AdminOutputDto(e));

            return result.ToListAsync();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}