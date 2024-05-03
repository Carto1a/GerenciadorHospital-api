using Hospital.Database;
using Hospital.Dtos.Input.Authentications;
using Hospital.Dtos.Output.Cadastros;
using Hospital.Models.Cadastro;
using Hospital.Repository.Cadastros.Interfaces;

namespace Hospital.Repository.Cadastros;
public class MedicoRepository
: IMedicoRepository
{
    protected readonly AppDbContext _ctx;
    private UnitOfWork _uow;

    public MedicoRepository(
        AppDbContext context,
        UnitOfWork uow)
    {
        _ctx = context;
        _uow = uow;
    }

    public Medico? GetMedicoById(Guid id)
    {
        try
        {
            var medico = _ctx.Medicos
                .FirstOrDefault(e => e.Id == id);
            return medico;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public Medico? GetMedicoByIdAtivo(Guid id)
    {
        try
        {
            var medico = _ctx.Medicos
                .FirstOrDefault(e => e.Id == id && e.Ativo == true);
            return medico;
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public Medico? GetMedicoByCRM(int crm)
    {
        try
        {
            return _ctx.Medicos
                .FirstOrDefault(e => e.CRM == crm);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public Medico? GetMedicoByCPF(string cpf)
    {
        try
        {
            return _ctx.Medicos
                .FirstOrDefault(e => e.CPF == cpf);
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public List<Medico> GetMedicos(int limit, int page = 0)
    {
        try
        {
            return _ctx
                .Medicos
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

    public void UpdateMedico(Medico medico)
    {
        try
        {
            _ctx.Medicos.Update(medico);
            _uow.Save();
        }
        catch (Exception error)
        {
            _uow.Dispose();
            throw new Exception(error.Message);
        }
    }

    public List<MedicoOutputDto> GetMedicoByQueryDto(
        MedicoGetByQueryDto query)
    {
        try
        {
            var queryCtx = _ctx.Medicos.AsQueryable();
            if (query.Especialidade != null)
                queryCtx = queryCtx.Where(x =>
                    x.Especialidade == query.Especialidade);

            if (query.Ativo != null)
                queryCtx = queryCtx.Where(x =>
                    x.Ativo == query.Ativo);

            if (query.MinDate != null)
                queryCtx = queryCtx.Where(x =>
                    x.DataNascimento >= DateOnly.FromDateTime(
                        (DateTime)query.MinDate));

            if (query.MaxDate != null)
                queryCtx = queryCtx.Where(x =>
                    x.DataNascimento <= DateOnly.FromDateTime(
                        (DateTime)query.MaxDate));

            if (query.Genero != null)
                queryCtx = queryCtx.Where(x =>
                    x.Genero == query.Genero);

            var result = queryCtx
                .Skip((int)query.Page!)
                .Take((int)query.Limit!)
                .Select(x => new MedicoOutputDto(x))
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