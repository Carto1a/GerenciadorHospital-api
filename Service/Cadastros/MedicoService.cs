using FluentResults;
using Hospital.Models.Cadastro;
using Hospital.Repository.Cadastros.Interfaces;
using Hospital.Service.Interfaces;

namespace Hospital.Service.Cadastros;
public class MedicoService
: IMedicoService
{
    private readonly ILogger<MedicoService> _logger;
    private readonly IMedicoRepository _medicoRepository;

    public MedicoService(
        IMedicoRepository medicoRepository,
        ILogger<MedicoService> logger)
    {
        _medicoRepository = medicoRepository;
        _logger = logger;
        _logger.LogDebug(1, $"NLog injected into MedicoService");
    }
    public Result<Medico?> GetMedicoById(Guid id)
    {
        // NOTE: talvez verificar o uuid?
        var response = _medicoRepository.GetMedicoById(id);
        if (response.IsFailed)
            return Result.Fail("Não foi possivel achar o Medico");

        return Result.Ok(response.Value);
    }

    public Result<List<Medico>> GetMedicos(
        int limit, int page = 0)
    {
        var response = _medicoRepository.GetMedicos(limit, page);
        if (response.IsFailed)
            return Result.Fail("Erro ao buscar medicos");

        return Result.Ok(response.Value);
    }
}
