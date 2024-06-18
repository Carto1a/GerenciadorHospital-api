using Hospital.Database;
using Hospital.Dtos.Input.Authentications;
using Hospital.Dtos.Output.Cadastros;
using Hospital.Infrastructure.Database.Repositories;
using Hospital.Repository.Cadastros.Interfaces;

namespace Hospital.Repository.Cadastros;
public class AdminRepository
: IAdminRepository
{
    private readonly AppDbContext _ctx;
    private UnitOfWork _uow;
    public AdminRepository(
        AppDbContext context,
        UnitOfWork uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public List<AdminOutputDto> GetAdminByQueryDto(
        AdminGetByQueryDto query)
    {
        try
        {
            var queryCtx = _ctx.Admins.AsQueryable();
            if (query.Ativo != null)
                queryCtx = queryCtx.Where(e => e.Ativo == query.Ativo);

            if (query.MinDate != null)
                queryCtx = queryCtx.Where(e => e.DataNascimento >= DateOnly
                    .FromDateTime((DateTime)query.MinDate));

            if (query.MaxDate != null)
                queryCtx = queryCtx.Where(e => e.DataNascimento <= DateOnly
                    .FromDateTime((DateTime)query.MaxDate));

            if (query.Genero != null)
                queryCtx = queryCtx.Where(e => e.Genero == query.Genero);

            var result = queryCtx
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .Select(e => new AdminOutputDto(e))
                .ToList();

            return result;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}