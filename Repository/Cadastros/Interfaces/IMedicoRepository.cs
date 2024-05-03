using Hospital.Dtos.Input.Authentications;
using Hospital.Dtos.Output.Cadastros;
using Hospital.Models.Cadastro;

namespace Hospital.Repository.Cadastros.Interfaces;
public interface IMedicoRepository
{
    Medico? GetMedicoById(Guid id);
    Medico? GetMedicoByIdAtivo(Guid id);
    List<Medico> GetMedicos(int limit, int page = 0);
    List<MedicoOutputDto> GetMedicoByQueryDto(MedicoGetByQueryDto query);
    void UpdateMedico(Medico medico);
}