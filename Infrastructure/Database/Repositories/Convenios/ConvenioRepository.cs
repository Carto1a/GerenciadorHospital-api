using Hospital.Application.Dto.Input.Convenios;
using Hospital.Application.Dto.Output.Convenios;
using Hospital.Domain.Entities;
using Hospital.Domain.Repositories;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database.Repositories.Convenios;
public class ConvenioRepository : Repository<Convenio, ConvenioGetByQueryDto, ConvenioOutputDto>,
IConvenioRepository
{
    private readonly AppDbContext _ctx;
    private readonly IUnitOfWork _uow;
    public ConvenioRepository(
        AppDbContext context,
        IUnitOfWork uow) : base(context, uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public async Task<Guid> CreateAsync(
        Convenio convenio)
    {
        try
        {
            var entity = await _ctx.Convenios.AddAsync(convenio);
            return entity.Entity.Id;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public Task<Convenio?> GetByCnpjAsync(string cnpj)
    {
        try
        {
            var convenio = _ctx.Convenios
                .FirstOrDefaultAsync(e => e.CNPJ == cnpj);
            return convenio;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public override Task<List<ConvenioOutputDto>> GetByQueryDtoAsync(
        ConvenioGetByQueryDto query)
    {
        try
        {
            var queryCtx = _ctx.Convenios.AsQueryable();
            if (query.CNPJ != null)
                queryCtx = queryCtx.Where(x => x.CNPJ == query.CNPJ);

            if (query.Nome != null)
                queryCtx = queryCtx.Where(x => x.Nome == query.Nome);

            // TODO: mudar no futuro para ativo
            if (query.Ativo != null)
                queryCtx = queryCtx.Where(x => x.Ativo == query.Ativo);

            var queryString = queryCtx.ToQueryString();
            var result = queryCtx
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .Select(e => new ConvenioOutputDto(e));

            return result.ToListAsync();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}