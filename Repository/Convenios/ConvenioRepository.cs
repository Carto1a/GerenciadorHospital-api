/* using FluentResults; */

/* using Hospital.Database; */
/* using Hospital.Dto.Convenios; */
/* using Hospital.Models.Cadastro; */
/* using Hospital.Repository.Convenios.Ineterfaces; */

/* using Microsoft.EntityFrameworkCore; */

/* namespace Hospital.Repository.Convenios; */
/* public class ConvenioRepository */
/* : IConvenioRepository */
/* { */
/*     private readonly ILogger<ConvenioRepository> _logger; */
/*     private readonly AppDbContext _ctx; */
/*     public ConvenioRepository( */
/*         AppDbContext context, */
/*         ILogger<ConvenioRepository> logger) */
/*     { */
/*         _ctx = context; */
/*         _logger = logger; */
/*     } */
/*     public async Task<Result<Convenio>> CreateConvenio( */
/*         Convenio convenio) */
/*     { */
/*         try */
/*         { */
/*             await _ctx.Convenios.AddAsync(convenio); */
/*             await _ctx.SaveChangesAsync(); */
/*             return Result.Ok(convenio); */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             return Result.Fail(error.Message); */
/*         } */
/*     } */

/*     public Result DeleteConvenio(Guid id) */
/*     { */
/*         throw new NotImplementedException(); */
/*     } */

/*     public Result<Convenio?> GetConvenioByCnpj(string cnpj) */
/*     { */
/*         try */
/*         { */
/*             // TODO: fazer o cnpj ser unico */
/*             var convenio = _ctx.Convenios */
/*                 .FirstOrDefault(e => e.CNPJ == cnpj); */
/*             return Result.Ok(convenio); */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             return Result.Fail(error.Message); */
/*         } */
/*     } */

/*     public Result<Convenio?> GetConvenioById(Guid id) */
/*     { */
/*         try */
/*         { */
/*             var convenio = _ctx.Convenios */
/*                 .FirstOrDefault(e => e.Id == id); */
/*             return Result.Ok(convenio); */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             return Result.Fail(error.Message); */
/*         } */
/*     } */

/*     public Result<List<Convenio>> GetConvenios( */
/*         ConvenioGetByQueryDto request, int limit = 1, int page = 0) */
/*     { */
/*         try */
/*         { */
/*             var query = _ctx.Convenios.AsQueryable(); */
/*             /1* query = (IQueryable<Convenio>)query *1/ */
/*             /1*     .GroupJoin(_ctx.Pacientes, c => c.Id, b => b.ConvenioId, (c, patientsGroup) => new { c, patientsGroup }) *1/ */
/*             /1*     .SelectMany(x => x.patientsGroup.DefaultIfEmpty(), (x, b) => new *1/ */
/*             /1*     { *1/ */
/*             /1*         x.c.Id, *1/ */
/*             /1*         x.c.CEP, *1/ */
/*             /1*         x.c.CNPJ, *1/ */
/*             /1*         x.c.Criado, *1/ */
/*             /1*         x.c.Deletado, *1/ */
/*             /1*         x.c.Desconto, *1/ */
/*             /1*         x.c.Descrição, *1/ */
/*             /1*         x.c.Email, *1/ */
/*             /1*         x.c.Nome, *1/ */
/*             /1*         x.c.Numero, *1/ */
/*             /1*         x.c.Site, *1/ */
/*             /1*         x.c.Telefone, *1/ */
/*             /1*         /2* PacientesCount = x.patientsGroup.Count() *2/ *1/ */
/*             /1*     }); *1/ */
/*             // TODO: ir atras de full text search no ef core */
/*             /1* if (request.Nome != null) *1/ */
/*             /1* { *1/ */
/*             /1*     query = query.Where(e => e.Nome.Contains(request.Nome)); *1/ */
/*             /1* } *1/ */
/*             if (request.CNPJ != null) */
/*                 query = query.Where(e => e.CNPJ.Contains(request.CNPJ)); */

/*             /1* if (request.PessoasCadastradas == true) *1/ */
/*             /1*     query = query *1/ */
/*             /1*         .Include(e => e.Pacientes).Count(e => e.Pacientes.Count > 0); *1/ */

/*             /1* if (request.ListaPessoasCadastradas == true) *1/ */
/*             /1*     query = query.Where(e => e.Pacientes.ToList); *1/ */

/*             var listString = query */
/*                 .Skip(page) */
/*                 .Take(limit); */
/*             var stringList = listString.ToQueryString(); */
/*             var list = listString.ToList(); */
/*             return Result.Ok(list); */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             return Result.Fail(error.Message); */
/*         } */
/*     } */

/*     public Result<List<Convenio>> GetConvenios( */
/*         int limit = 1, int page = 0) */
/*     { */
/*         // TODO: pegar as quantidade de pessoas que tem esse convenio */
/*         try */
/*         { */
/*             var list = _ctx.Convenios */
/*                 .Skip(page) */
/*                 .Take(limit) */
/*                 .ToList(); */
/*             return Result.Ok(list); */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             return Result.Fail(error.Message); */
/*         } */
/*     } */

/*     public Result<Convenio> UpdateConvenio( */
/*         Convenio convenio) */
/*     { */
/*         try */
/*         { */
/*             _ctx.Convenios.Update(convenio); */
/*             _ctx.SaveChanges(); */
/*             return Result.Ok(convenio); */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             return Result.Fail(error.Message); */
/*         } */
/*     } */
/* } */