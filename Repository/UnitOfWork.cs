using Hospital.Database;
using Hospital.Repository.Cadastros;
using Hospital.Repository.Cadastros.Authentications.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Repository.Convenios;
using Hospital.Repository.Convenios.Ineterfaces;

namespace Hospital.Repository;
public class UnitOfWork
: IDisposable
{
    private IAuthAdminRepository? _authAdminRepository;
    private IAuthMedicoRepository? _authMedicoRepository;
    private IAuthPacienteRepository? _authPacienteRepository;
    private IMedicoRepository? _medicoRepository;
    private IPacienteRepository? _pacienteRepository;
    private IConvenioRepository? _convenioRepository;
    private readonly AppDbContext _ctx;
    private bool disposed = false;
    public UnitOfWork(
        AppDbContext context)
    {
        _ctx = context;
    }

    public IPacienteRepository PacienteRepository
    {
        get
        {
            if (_pacienteRepository == null)
            {
                _pacienteRepository =
                    new PacienteRepository(_ctx, this);
            }
            return _pacienteRepository;
        }
    }

    public IMedicoRepository MedicoRepository
    {
        get
        {
            if (_medicoRepository == null)
            {
                _medicoRepository =
                    new MedicoRepository(_ctx, this);
            }
            return _medicoRepository;
        }
    }

    public IConvenioRepository ConvenioRepository
    {
        get
        {
            if (_convenioRepository == null)
            {
                _convenioRepository =
                    new ConvenioRepository(_ctx, this);
            }
            return _convenioRepository;
        }
    }

    public void Save()
    {
        _ctx.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _ctx.Dispose();
            }
        }
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}