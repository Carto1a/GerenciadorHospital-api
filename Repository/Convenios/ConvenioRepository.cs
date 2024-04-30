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

    public List<Convenio> GetConvenios(
        ConvenioGetByQueryDto request)
    {
        try
        {
            var query = _ctx.Convenios.AsQueryable();
            /* query = (IQueryable<Convenio>)query */
            /*     .GroupJoin(_ctx.Pacientes, c => c.Id, b => b.ConvenioId, (c, patientsGroup) => new { c, patientsGroup }) */
            /*     .SelectMany(x => x.patientsGroup.DefaultIfEmpty(), (x, b) => new */
            /*     { */
            /*         x.c.Id, */
            /*         x.c.CEP, */
            /*         x.c.CNPJ, */
            /*         x.c.Criado, */
            /*         x.c.Deletado, */
            /*         x.c.Desconto, */
            /*         x.c.Descrição, */
            /*         x.c.Email, */
            /*         x.c.Nome, */
            /*         x.c.Numero, */
            /*         x.c.Site, */
            /*         x.c.Telefone, */
            /*         /1* PacientesCount = x.patientsGroup.Count() *1/ */
            /*     }); */
            // TODO: ir atras de full text search no ef core
            /* if (request.Nome != null) */
            /* { */
            /*     query = query.Where(e => e.Nome.Contains(request.Nome)); */
            /* } */

            if (request.CNPJ != null)
                query = query.Where(e => e.CNPJ! == request.CNPJ);

            /* if (request.PessoasCadastradas == true) */
            /*     query = query */
            /*         .Include(e => e.Pacientes).Count(e => e.Pacientes.Count > 0); */

            /* if (request.ListaPessoasCadastradas == true) */
            /*     query = query.Where(e => e.Pacientes.ToList); */

            var queryRequest = query
                .Skip((int)request.Page!)
                .Take((int)request.Limit!);
            var queryString = queryRequest.ToQueryString();
            return queryRequest.ToList();
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