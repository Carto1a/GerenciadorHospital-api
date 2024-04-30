
using Hospital.Dtos.Output.Convenios;
using Hospital.Repository;

namespace Hospital.Services.Convenios;
public class ConvenioGetByIdService
{
    private readonly UnitOfWork _uow;
    public ConvenioGetByIdService(
        UnitOfWork uow)
    {
        _uow = uow;
    }

    public ConvenioOutputDto? Handler(Guid id)
    {
        var convenio = _uow.ConvenioRepository
            .GetConvenioByIdDto(id);

        return convenio;
    }
}