using Hospital.Application.Dto.Input.Atendimentos;
using Hospital.Application.Dto.Output.Atendimentos;
using Hospital.Domain.Entities.Atendimentos;
using Hospital.Domain.Repositories;
using Hospital.Domain.Repositories.Atendimentos;

using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database.Repositories.Atendimentos;
public class RetornoRepository
: AtendimentoRepository<Retorno, RetornoGetByQueryDto, RetornoOutputDto>,
IRetornoRepository
{
    private readonly AppDbContext _ctx;
    private readonly IUnitOfWork _uow;
    public RetornoRepository(
        AppDbContext context,
        IUnitOfWork uow)
    : base(context, uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public override Task<List<RetornoOutputDto>> GetByQueryDtoAsync(RetornoGetByQueryDto query)
    {
        try
        {
            var queryList = _ctx.Retornos.AsQueryable();
            if (query.MedicoId != null)
                queryList = queryList.Where(e =>
                    e.MedicoId == query.MedicoId);

            if (query.PacienteId != null)
                queryList = queryList.Where(e =>
                    e.PacienteId == query.PacienteId);

            if (query.MinDateCriado != null && query.MaxDateCriado != null)
                queryList = queryList.Where(
                    e => e.Inicio >= query.MinDateCriado
                    && e.Inicio <= query.MaxDateCriado);

            var result = queryList
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .Select(e => new RetornoOutputDto(e));

            return result.ToListAsync();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }
}