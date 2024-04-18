using FluentResults;

using Hospital.Models.Cadastro;

namespace Hospital.Service.Interfaces;
public interface IMedicoService
{
    Result<List<Medico>> GetMedicos(int limit, int page = 0);
    Result<Medico?> GetMedicoById(Guid id);
}