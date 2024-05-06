using Hospital.Database;
using Hospital.Models.Agendamentos;
using Hospital.Repository.Agendamentos;
using Hospital.Repository.Atendimentos;
using Hospital.Repository.Atendimentos.Interfaces;
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
    // TODO: usar o DI para injetar esses repositorios
    private IAuthAdminRepository? _authAdminRepository;
    private IAuthMedicoRepository? _authMedicoRepository;
    private IAuthPacienteRepository? _authPacienteRepository;
    private IMedicoRepository? _medicoRepository;
    private IPacienteRepository? _pacienteRepository;
    private IAdminRepository? _adminRepository;
    private IConvenioRepository? _convenioRepository;
    private IMedicamentoRepository? _medicamentoRepository;
    private IMedicamentoLoteRepository? _medicamentoLoteRepository;
    private IConsultaAgendamentoRepository? _consultaAgendamentoRepository;
    private IExameAgendamentoRepository? _exameAgendamentoRepository;
    private IRetornoAgendamentoRepository? _retornoAgendamentoRepository;
    private IConsultaRepository? _consultaRepository;

    private IDictionary<string, object?> _agendamentoRepositories;

    private readonly AppDbContext _ctx;
    private bool disposed = false;
    public UnitOfWork(
        AppDbContext context)
    {
        _ctx = context;
        _agendamentoRepositories = new Dictionary<
            string, object?>
        {
            { nameof(ExameAgendamento), null },
            { nameof(ConsultaAgendamento), null },
            { nameof(RetornoAgendamento), null }
        };
    }

    /* // NOTE: não questione os meus metodos, mas sim a minha sanidade */
    /* public IAgendamentoRepository<T, TAgendamento, OutputDto>? */
    /* SetAgendamento<T, TAgendamento, OutputDto>() */
    /* where T : Atendimento */
    /* where TAgendamento : Agendamento */
    /* where OutputDto : AgendamentoOutputDto */
    /* { */
    /*     var key = typeof(TAgendamento).Name; */
    /*     var repository = _agendamentoRepositories.ContainsKey(key) ? */
    /*         _agendamentoRepositories[key] : null; */
    /*     var teste = nameof(ExameAgendamento); */
    /*     if (repository != null) */
    /*     { */
    /*         return repository as */
    /*         IAgendamentoRepository<T, TAgendamento, OutputDto>; */
    /*     } */

    /*     if (key == nameof(ExameAgendamento)) */
    /*     { */
    /*         var repo = */
    /*             new ExameAgendamentoRepository(_ctx, this) as */
    /*             IAgendamentoRepository<T, TAgendamento, OutputDto>; */
    /*         _agendamentoRepositories[key] = repo; */
    /*         return repo; */
    /*     } */

    /*     if (key == nameof(ConsultaAgendamento)) */
    /*     { */
    /*         var repo = */
    /*             new ConsultaAgendamentoRepository(_ctx, this) as */
    /*             IAgendamentoRepository<T, TAgendamento, OutputDto>; */
    /*         _agendamentoRepositories[key] = repo; */
    /*         return repo; */
    /*     } */

    /*     if (key == nameof(RetornoAgendamento)) */
    /*     { */
    /*         var repo = */
    /*             new RetornoAgendamentoRepository(_ctx, this) as */
    /*             IAgendamentoRepository<T, TAgendamento, OutputDto>; */
    /*         _agendamentoRepositories[key] = repo; */
    /*         return repo; */
    /*     } */

    /*     throw new RequestError( */
    /*         $"AgendamentoRepository<{key}> not found", */
    /*         "Erro interno, contate o suporte", */
    /*         StatusCodes.Status500InternalServerError); */
    /* } */

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

    public IConsultaAgendamentoRepository ConsultaAgendamentoRepository
    {
        get
        {
            if (_consultaAgendamentoRepository == null)
            {
                _consultaAgendamentoRepository =
                    new ConsultaAgendamentoRepository(_ctx, this);
            }
            return _consultaAgendamentoRepository;
        }
    }

    public IExameAgendamentoRepository ExameAgendamentoRepository
    {
        get
        {
            if (_exameAgendamentoRepository == null)
            {
                _exameAgendamentoRepository =
                    new ExameAgendamentoRepository(_ctx, this);
            }
            return _exameAgendamentoRepository;
        }
    }

    public IRetornoAgendamentoRepository RetornoAgendamentoRepository
    {
        get
        {
            if (_retornoAgendamentoRepository == null)
            {
                _retornoAgendamentoRepository =
                    new RetornoAgendamentoRepository(_ctx, this);
            }
            return _retornoAgendamentoRepository;
        }
    }

    public IConsultaRepository ConsultaRepository
    {
        get
        {
            if (_consultaRepository == null)
            {
                _consultaRepository =
                    new ConsultaRepository(_ctx, this);
            }
            return _consultaRepository;
        }
    }

    public Task Save()
    {
        return _ctx.SaveChangesAsync();
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