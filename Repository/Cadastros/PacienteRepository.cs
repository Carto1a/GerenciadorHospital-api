using Hospital.Database;
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
}