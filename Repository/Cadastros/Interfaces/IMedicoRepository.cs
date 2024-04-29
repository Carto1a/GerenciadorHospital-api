using Hospital.Models.Cadastro;

namespace Hospital.Repository.Cadastros.Interfaces;
public interface IMedicoRepository
{
    Medico? GetMedicoById(Guid id);
    List<Medico> GetMedicos(int limit, int page = 0);
}