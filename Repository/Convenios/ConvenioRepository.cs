using FluentResults;

using Hospital.Database;
using Hospital.Dto.Convenios;
using Hospital.Models.Cadastro;
using Hospital.Repository.Convenios.Ineterfaces;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Repository.Convenios;
public class ConvenioRepository
: IConvenioRepository
{
    private readonly ILogger<ConvenioRepository> _logger;
    private readonly AppDbContext _ctx;
    public ConvenioRepository(
        AppDbContext context,
        ILogger<ConvenioRepository> logger)
    {
        _ctx = context;
        _logger = logger;
    }
    public async Task<Result<Convenio>> CreateConvenio(
        Convenio convenio)
    {
        try
        {
            await _ctx.Convenios.AddAsync(convenio);
            await _ctx.SaveChangesAsync();
            return Result.Ok(convenio);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result DeleteConvenio(Guid id)
    {
        throw new NotImplementedException();
    }

    public Result<Convenio?> GetConvenioByCnpj(string cnpj)
    {
        try
        {
            // TODO: fazer o cnpj ser unico
            var convenio = _ctx.Convenios
                .FirstOrDefault(e => e.CNPJ == cnpj);
            return Result.Ok(convenio);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<Convenio?> GetConvenioById(Guid id)
    {
        try
        {
            var convenio = _ctx.Convenios
                .FirstOrDefault(e => e.Id == id);
            return Result.Ok(convenio);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<Convenio>> GetConvenios(
        ConvenioGetByQueryDto request, int limit = 1, int page = 0)
    {
        try
        {
            var query = _ctx.Convenios.AsQueryable();
            query = (IQueryable<Convenio>)query
                .GroupJoin(_ctx.Pacientes, c => c.Id, b => b.ConvenioId, (c, patientsGroup) => new { c, patientsGroup })
                .SelectMany(x => x.patientsGroup.DefaultIfEmpty(), (x, b) => new
                {
                    x.c.Id,
                    x.c.CEP,
                    x.c.CNPJ,
                    x.c.Criado,
                    x.c.Deletado,
                    x.c.Desconto,
                    x.c.Descrição,
                    x.c.Email,
                    x.c.Nome,
                    x.c.Numero,
                    x.c.Site,
                    x.c.Telefone,
                    /* PacientesCount = x.patientsGroup.Count() */
                });
            // TODO: ir atras de full text search no ef core
            /* if (request.Nome != null) */
            /* { */
            /*     query = query.Where(e => e.Nome.Contains(request.Nome)); */
            /* } */
            /* if (request.CNPJ != null) */
            /*     query = query.Where(e => e.CNPJ.Contains(request.CNPJ)); */

            /* if (request.PessoasCadastradas == true) */
            /*     query = query */
            /*         .Include(e => e.Pacientes).Count(e => e.Pacientes.Count > 0); */

            /* if (request.ListaPessoasCadastradas == true) */
            /*     query = query.Where(e => e.Pacientes.Count > 0); */

            var listString = query
                .Skip(page)
                .Take(limit);
            var stringList = listString.ToQueryString();
            var list = listString.ToList();
            return Result.Ok(list);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<List<Convenio>> GetConvenios(
        int limit = 1, int page = 0)
    {
        // TODO: pegar as quantidade de pessoas que tem esse convenio
        try
        {
            var list = _ctx.Convenios
                .Skip(page)
                .Take(limit)
                .ToList();
            return Result.Ok(list);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }

    public Result<Convenio> UpdateConvenio(
        Convenio convenio)
    {
        try
        {
            _ctx.Convenios.Update(convenio);
            _ctx.SaveChanges();
            return Result.Ok(convenio);
        }
        catch (Exception error)
        {
            return Result.Fail(error.Message);
        }
    }
}