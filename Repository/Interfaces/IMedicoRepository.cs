using FluentResults;
using Hospital.Models;

namespace Hospital.Repository.Interfaces;
public interface IMedicoRepository
{
    Result<Medico?> GetMedicoById(int id);
    Result<List<Medico>> GetMedicos(int limit, int page = 0); 
}
