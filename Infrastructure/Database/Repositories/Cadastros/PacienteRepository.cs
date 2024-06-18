using Hospital.Database;
using Hospital.Dtos.Input.Authentications;
using Hospital.Dtos.Output.Cadastros;
using Hospital.Infrastructure.Database.Repositories;
using Hospital.Models.Cadastro;
using Hospital.Repository.Cadastros.Interfaces;


namespace Hospital.Repository.Cadastros;
public class PacienteRepository
: IPacienteRepository
{
    private readonly AppDbContext _ctx;
    private UnitOfWork _uow;
    public PacienteRepository(
        AppDbContext context,
        UnitOfWork uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public Paciente? GetPacienteById(Guid id)
    {
        try
        {
            return _ctx.Pacientes
                .FirstOrDefault(e => e.Id == id);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public Paciente? GetPacienteByIdAtivo(Guid id)
    {
        try
        {
            return _ctx.Pacientes
                .FirstOrDefault(e => e.Id == id && e.Ativo == true);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public PacienteOutputDto? GetPacienteByIdDto(Guid id)
    {
        try
        {
            return _ctx.Pacientes
                .Where(e => e.Id == id)
                .Select(e => new PacienteOutputDto(e))
                .FirstOrDefault();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public Paciente? GetPacienteByCPF(string cpf)
    {
        try
        {
            return _ctx.Pacientes
                .FirstOrDefault(e => e.CPF == cpf);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public List<Paciente> GetPacientes(
        int limit, int page = 0)
    {
        try
        {
            return _ctx.Pacientes
                .Skip(page)
                .Take(limit)
                .ToList();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public List<PacienteOutputDto> GetPacienteByQueryDto(
        PacienteGetByQueryDto query)
    {
        try
        {
            var queryCtx = _ctx.Pacientes.AsQueryable();
            if (query.ConvenioId != null)
                queryCtx = queryCtx.Where(x =>
                    x.ConvenioId == query.ConvenioId);

            if (query.Ativo != null)
                queryCtx = queryCtx.Where(x =>
                    x.Ativo == query.Ativo);

            if (query.MinDateNasc != null)
                queryCtx = queryCtx.Where(x =>
                    x.DataNascimento >= DateOnly.FromDateTime(
                        (DateTime)query.MinDateNasc!));

            if (query.MaxDateNasc != null)
                queryCtx = queryCtx.Where(x =>
                    x.DataNascimento <= DateOnly.FromDateTime(
                        (DateTime)query.MaxDateNasc!));

            if (query.Genero != null)
                queryCtx = queryCtx.Where(x =>
                    x.Genero == query.Genero);

            /* var queryString = queryCtx.ToQueryString(); */
            var result = queryCtx
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .Select(e => new PacienteOutputDto(e))
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