using Hospital.Dtos.Input.Convenios;
using Hospital.Models.Cadastro;

namespace Hospital.Repository.Convenios.Ineterfaces;
public interface IConvenioRepository
{
    Task<Guid> CreateConvenioAsync(Convenio convenio);
    Convenio? GetConvenioById(Guid id);
    Convenio? GetConvenioByCnpj(string cnpj);
    List<Convenio> GetConvenios(ConvenioGetByQueryDto request);
    Convenio UpdateConvenio(Convenio convenio);
    void DesativarConvenio(Guid id);
}