using FluentResults;
using Hospital.Models.Cadastro;

namespace Hospital.Repository.Cadastros.Interfaces;
public interface IMedicoRepository
{
    Result<Medico?> GetMedicoById(Guid id);
    Result<List<Medico>> GetMedicos(int limit, int page = 0); 
}
