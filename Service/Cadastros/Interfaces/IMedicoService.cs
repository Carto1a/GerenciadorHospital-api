using Hospital.Models.Cadastro;
using FluentResults;

namespace Hospital.Service.Interfaces;
public interface IMedicoService
{
    Result<List<Medico>> GetMedicos(int limit, int page = 0);
    Result<Medico?> GetMedicoById(string id);
}
