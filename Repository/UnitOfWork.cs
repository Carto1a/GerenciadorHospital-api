using Hospital.Database;
using Hospital.Repository.Cadastros;
using Hospital.Repository.Cadastros.Authentications.Interfaces;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Repository.Convenios;
using Hospital.Repository.Convenios.Ineterfaces;
using Hospital.Repository.MedicamentoLotes;
using Hospital.Repository.MedicamentoLotes.Interfaces;
using Hospital.Repository.Medicamentos;
using Hospital.Repository.Medicamentos.Interfaces;

namespace Hospital.Repository;
public class UnitOfWork
: IDisposable
{
    private IAuthAdminRepository? _authAdminRepository;
    private IAuthMedicoRepository? _authMedicoRepository;
    private IAuthPacienteRepository? _authPacienteRepository;
    private IMedicoRepository? _medicoRepository;
    private IPacienteRepository? _pacienteRepository;
    private IAdminRepository? _adminRepository;
    private IConvenioRepository? _convenioRepository;
    private IMedicamentoRepository? _medicamentoRepository;
    private IMedicamentoLoteRepository? _medicamentoLoteRepository;
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

    public IAdminRepository AdminRepository
    {
        get
        {
            if (_adminRepository == null)
            {
                _adminRepository =
                    new AdminRepository(_ctx, this);
            }
            return _adminRepository;
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

    public IMedicamentoRepository MedicamentoRepository
    {
        get
        {
            if (_medicamentoRepository == null)
            {
                _medicamentoRepository =
                    new MedicamentoRepository(_ctx, this);
            }
            return _medicamentoRepository;
        }
    }

    public IMedicamentoLoteRepository MedicamentoLoteRepository
    {
        get
        {
            if (_medicamentoLoteRepository == null)
            {
                _medicamentoLoteRepository =
                    new MedicamentoLoteRepository(_ctx, this);
            }
            return _medicamentoLoteRepository;
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