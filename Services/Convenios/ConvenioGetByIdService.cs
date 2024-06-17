
using Hospital.Dtos.Output.Convenios;
using Hospital.Repository;
using Hospital.Repository.Convenios.Ineterfaces;

namespace Hospital.Services.Convenios;
public class ConvenioGetByIdService
{
    private readonly UnitOfWork _uow;
    private readonly IConvenioRepository _convenioRepository;
    public ConvenioGetByIdService(
        UnitOfWork uow)
    {
        _uow = uow;
    }

    public ConvenioOutputDto? Handler(Guid id)
    {
        var convenio = _convenioRepository
            .GetConvenioByIdDto(id);

        return convenio;
    }
}