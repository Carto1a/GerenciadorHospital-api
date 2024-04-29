using Hospital.Database;
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
}