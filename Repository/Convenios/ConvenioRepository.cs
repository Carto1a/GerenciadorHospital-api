using Hospital.Database;
using Hospital.Dtos.Input.Convenios;
using Hospital.Dtos.Output.Convenios;
using Hospital.Models.Cadastro;
using Hospital.Repository.Convenios.Ineterfaces;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.Convenios;
public class ConvenioRepository
: IConvenioRepository
{
    private readonly AppDbContext _ctx;
    private UnitOfWork _uow;
    public ConvenioRepository(
        AppDbContext context,
        UnitOfWork uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public async Task<Guid> CreateConvenioAsync(
        Convenio convenio)
    {
        try
        {
            var entity = _ctx.Convenios.Add(convenio);
            await _ctx.SaveChangesAsync();
            return entity.Entity.Id;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public void DesativarConvenio(Guid id)
    {
        throw new NotImplementedException();
    }

    public Convenio? GetConvenioByCnpj(string cnpj)
    {
        try
        {
            var convenio = _ctx.Convenios
                .FirstOrDefault(e => e.CNPJ == cnpj);
            return convenio;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public Convenio? GetConvenioById(Guid id)
    {
        try
        {
            var convenio = _ctx.Convenios
                .FirstOrDefault(e => e.Id == id);
            return convenio;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public ConvenioOutputDto? GetConvenioByIdDto(Guid id)
    {
        try
        {
            var convenio = _ctx.Convenios
                .Where(e => e.Id == id)
                .Select(e => new ConvenioOutputDto(e))
                .FirstOrDefault();
            return convenio;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public List<ConvenioOutputDto> GetConveniosGetByQueryDto(
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
                queryCtx = queryCtx.Where(x => x.Deletado == !query.Ativo);

            var queryString = queryCtx.ToQueryString();
            var result = queryCtx
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .Select(e => new ConvenioOutputDto(e))
                .ToList();
            return result;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public Convenio UpdateConvenio(
        Convenio convenio)
    {
        try
        {
            _ctx.Convenios.Update(convenio);
            _ctx.SaveChanges();
            return convenio;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}