using Hospital.Dtos.Input.Convenios;
using Hospital.Dtos.Output.Convenios;
using Hospital.Models.Cadastro;

namespace Hospital.Repository.Convenios.Ineterfaces;
public interface IConvenioRepository
{
    Task<Guid> CreateConvenioAsync(Convenio convenio);
    Convenio? GetConvenioById(Guid id);
    ConvenioOutputDto? GetConvenioByIdDto(Guid id);
    Convenio? GetConvenioByCnpj(string cnpj);
    List<ConvenioOutputDto> GetConveniosGetByQueryDto(ConvenioGetByQueryDto query);
    Convenio UpdateConvenio(Convenio convenio);
    void DesativarConvenio(Guid id);
}