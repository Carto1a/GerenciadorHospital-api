/* using Hospital.Application.Dto.Input.Authentications; */
/* using Hospital.Application.Dto.Output.Cadastros; */
/* using Hospital.Domain.Entities.Cadastros; */
/* using Hospital.Domain.Repositories; */
/* using Hospital.Domain.Repositories.Cadastros; */

/* using Microsoft.EntityFrameworkCore; */

/* namespace Hospital.Infrastructure.Database.Repositories.Cadastros; */
/* public class PacienteRepository : CadastroRepository<Paciente, PacienteGetByQueryDto, PacienteOutputDto>, */
/* IPacienteRepository */
/* { */
/*     private readonly AppDbContext _ctx; */
/*     private IUnitOfWork _uow; */
/*     public PacienteRepository( */
/*         AppDbContext context, */
/*         IUnitOfWork uow) : base(context, uow) */
/*     { */
/*         _ctx = context; */
/*         _uow = uow; */
/*     } */

/*     public Task<Paciente?> GetByCPFAsync(string cpf) */
/*     { */
/*         try */
/*         { */
/*             return _ctx.Pacientes */
/*                 .FirstOrDefaultAsync(e => e.CPF == cpf); */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             _uow.Dispose(); */
/*             throw new Exception(error.Message); */
/*         } */
/*     } */

/*     public override Task<List<PacienteOutputDto>> GetByQueryDtoAsync( */
/*         PacienteGetByQueryDto query) */
/*     { */
/*         try */
/*         { */
/*             var queryCtx = _ctx.Pacientes.AsQueryable(); */
/*             if (query.ConvenioId != null) */
/*                 queryCtx = queryCtx.Where(x => */
/*                     x.ConvenioId == query.ConvenioId); */

/*             if (query.Ativo != null) */
/*                 queryCtx = queryCtx.Where(x => */
/*                     x.Ativo == query.Ativo); */

/*             if (query.MinDateNasc != null) */
/*                 queryCtx = queryCtx.Where(x => */
/*                     x.DataNascimento >= DateOnly.FromDateTime( */
/*                         (DateTime)query.MinDateNasc!)); */

/*             if (query.MaxDateNasc != null) */
/*                 queryCtx = queryCtx.Where(x => */
/*                     x.DataNascimento <= DateOnly.FromDateTime( */
/*                         (DateTime)query.MaxDateNasc!)); */

/*             if (query.Genero != null) */
/*                 queryCtx = queryCtx.Where(x => */
/*                     x.Genero == query.Genero); */

/*             /1* var queryString = queryCtx.ToQueryString(); *1/ */
/*             var result = queryCtx */
/*                 .Skip((int)query.Page!) */
/*                 .Take((int)query.Limit!) */
/*                 .Select(e => new PacienteOutputDto(e)); */

/*             return result.ToListAsync(); */
/*         } */
/*         catch (Exception error) */
/*         { */
/*             _uow.Dispose(); */
/*             throw new Exception(error.Message); */
/*         } */
/*     } */
/* } */